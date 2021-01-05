using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Lookups.MembershipCategoryServices;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters.Lookups.AccountStatuses;
using CooperativeSystem.Service.Presenters.Lookups.MaritalStatuses;
using CooperativeSystem.Service.Presenters.Lookups.MembershipCategories;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Lookups.SexTypes;

namespace CooperativeSystem.Service.Presenters.Members
{
    public class MemberPresenter : PresenterTemplate
    {
        private DataContext _db;
        private IRepository<Member> _repository;

        private Member _model;
        private AvailedServicesAdapter _availedServices;
        //private IList<Dependent> _dependents;

        private readonly IMemberView _memberView;
        private readonly IDependentView _dependentView;
        private readonly IEducationalAttainmentView _educationalAttainmentView;

        public MemberPresenter(IMemberView memberView, IDependentView dependentView, IEducationalAttainmentView educationalAttainmentView)
        {
            InitializePresistenceManager();

            _memberView = memberView;
            _dependentView = dependentView;
            _educationalAttainmentView = educationalAttainmentView;

            // wire events
            _dependentView.AddingDependent += new EventHandler(DependentView_AddingDependent);
            _dependentView.ModifyingDependent += new EventHandler(DependentView_ModifyingDependent);
            _dependentView.RemovingDependent += new EventHandler(DependentView_RemovingDependent);

            _educationalAttainmentView.AddingEducationalAttainment += new EventHandler(EducationalAttainmentView_AddingEducationalAttainment);
            _educationalAttainmentView.ModifyingEducationalAttainment += new EventHandler(EducationalAttainmentView_ModifyingEducationalAttainment);
            _educationalAttainmentView.RemovingEducationalAttainment += new EventHandler(_educationalAttainmentView_RemovingEducationalAttainment);
            _memberView.MembershipCategoryChangedEvent += new MembershipCategoryChangedEventHandler(MemberView_MembershipCategoryChangedEvent);

            _memberView.PopulateAccountStatusPulldown(_db.GetTable<AccountStatus>().ToList());
            _memberView.PopulateMaritalStatusPulldown(_db.GetTable<MaritalStatus>().ToList());
            _memberView.PopulateMembershipCategoryPulldown(_db.GetTable<MembershipCategory>().ToList());
            _memberView.PopulateSexTypePulldown(_db.GetTable<SexType>().ToList());
            _memberView.PopulateRelationPulldown(_db.GetTable<Relation>().ToList());

            //_dependents = new List<Dependent>();

            // initailize
            NewMember();
        }

        public bool CloseAccount()
        {
            try
            {
                var loan = _model.Loans
                    .Where(x => x.Settled == false);

                if (loan.Any())
                {
                    var message = new StringBuilder();
                    message.AppendLine("You cannot close your account yet.");
                    message.AppendLine("You still have the following unsettled loans:");

                    var loanNames = loan
                        .Select(x => x.Service.ServiceName)
                        .ToArray();

                    for (var i = 0; i < loanNames.Count(); i++)
                        message.AppendLine((i + 1).ToString() + ". " + loanNames[i]);

                    RaiseErrorEvent(message.ToString());
                    return false;
                }

                _model.AccountStatusID = AccountStatusCodes.Closed;
                _model.WithdrawalDate = DateTime.Today;
                _repository.SaveAll();

                RaiseSusccessEvent("Account successfully closed.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool NewMember()
        {
            try
            {
                InitializePresistenceManager();
                _model = _repository.CreateEntity();
                _model.AccountNumber = new AccountNumberGenerator(_db).GenerateAccountNumber();
                _availedServices = new AvailedServicesAdapter(_model.AvailedServices);
                _availedServices.SetValues(false);
                SetValuesToView(_memberView, _model);
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool LoadMember(long memberID)
        {
            try
            {
                InitializePresistenceManager();
                _model = _repository.GetEntity(m => m.MemberID == memberID);
                SetValuesToView(_memberView, _model);
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Insert()
        {
            try
            {
                //if (string.IsNullOrEmpty(_memberView.AccountNumber))
                //    _memberView.AccountNumber = new AccountNumberGenerator(_db).GenerateAccountNumber();

                var memberWithSameName = _db.GetTable<Member>()
                    .Where(x =>
                        x.LastName == _memberView.LastName &&
                        x.FirstName == _memberView.FirstName &&
                        x.MiddleName == _memberView.MiddleName)
                    .Any();

                if (memberWithSameName)
                {
                    RaiseErrorEvent("Member exist with the same name.");
                    return false;
                }

                SetValuesToModel(_model, _memberView);
                _repository.SaveAll();

                // reflect generated member id
                _memberView.MemberID = _model.MemberID;

                RaiseSusccessEvent("Successful saving.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                SetValuesToModel(_model, _memberView);
                _repository.SaveAll();
                RaiseSusccessEvent("Successful saving.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                //SetValuesToModel(_model, _memberView);
                _repository.MarkForDeletion(_model);
                _repository.SaveAll();
                RaiseSusccessEvent("Successful deleting.");
                return true;
            }
            catch (Exception ex)
            {
                RaiseErrorEvent(ex.Message, ex);
                return false;
            }
        }

        #region Handled Events

        void MemberView_MembershipCategoryChangedEvent(object sender, EventArgs e)
        {
            var allowableServices = new MembershipCategoryServicesAdapter(_memberView.MembershipCategoryID);

            _memberView.AvailedServices.EnableServicesBasedOnMembershipCategoyAndServicesAvailed(allowableServices, _availedServices);
        }

        private void DependentView_AddingDependent(object sender, EventArgs e)
        {
            var value = (IDependentView)sender;
            var exists = GetDependent(value) != null;
            if (exists)
            {
                DependentView_ModifyingDependent(value, e);
            }
            else
            {
                var entity = new Dependent();
                SetDependentValue(entity, value);
                _model.Dependents.Add(entity);
            }

            //reflect 
            _memberView.Dependents = GetDependentsFromMemberEntity(_model);
        }

        private void DependentView_ModifyingDependent(object sender, EventArgs e)
        {
            var value = (IDependentView)sender;
            var entity = GetDependent(value);
            if (entity == null)
                DependentView_AddingDependent(value, e);
            else
                SetDependentValue(entity, value);

            //reflect 
            _memberView.Dependents = GetDependentsFromMemberEntity(_model);
        }

        private void DependentView_RemovingDependent(object sender, EventArgs e)
        {
            var value = (IDependentView)sender;
            var entity = GetDependent(value);
            if (entity != null)
                _model.Dependents.Remove(entity);

            //reflect 
            _memberView.Dependents = GetDependentsFromMemberEntity(_model);
        }

        private void EducationalAttainmentView_AddingEducationalAttainment(object sender, EventArgs e)
        {
            var value = (IEducationalAttainmentView)sender;
            var exists = GetEducationalAttainment(value) != null;
            if (exists)
            {
                EducationalAttainmentView_ModifyingEducationalAttainment(value, e);
            }
            else
            {
                var entity = new EducationalAttainment();
                SetEducationalAttainmentValue(entity, value);
                _model.EducationalAttainments.Add(entity);
            }

            //reflect 
            _memberView.EducationalAttainments = GetEducationalAttainmentsFromMemberEntity(_model);
        }

        private void EducationalAttainmentView_ModifyingEducationalAttainment(object sender, EventArgs e)
        {
            var value = (IEducationalAttainmentView)sender;
            var entity = GetEducationalAttainment(value);
            if (entity == null)
                EducationalAttainmentView_AddingEducationalAttainment(value, e);
            else
                SetEducationalAttainmentValue(entity, value);

            //reflect 
            _memberView.EducationalAttainments = GetEducationalAttainmentsFromMemberEntity(_model);
        }

        private void _educationalAttainmentView_RemovingEducationalAttainment(object sender, EventArgs e)
        {
            var value = (IEducationalAttainmentView)sender;
            var entity = GetEducationalAttainment(value);
            if (entity != null)
                _model.EducationalAttainments.Remove(entity);

            //reflect 
            _memberView.EducationalAttainments = GetEducationalAttainmentsFromMemberEntity(_model);
        }

        #endregion

        #region Routine Helpers

        private void InitializePresistenceManager()
        {
            _db = null;
            _repository = null;

            _db = new DataContextFactory().CreateDataContext();
            _repository = new GenericRepository<Member>(_db);
        }

        private Dependent GetDependent(IDependentView value)
        {
            Dependent item = null;
            if (_model != null)
            {
                item = _model.Dependents.FirstOrDefault(x =>
                    x.MemberID == value.MemberID &&
                    x.LineNumber == value.LineNumber
                );
            }
            return item;
        }

        private EducationalAttainment GetEducationalAttainment(IEducationalAttainmentView value)
        {
            EducationalAttainment item = null;
            if (_model != null)
            {
                item = _model.EducationalAttainments.FirstOrDefault(x =>
                    x.MemberID == value.MemberID &&
                    x.LineNumber == value.LineNumber
                );
            }
            return item;
        }

        private void SetDependentValue(Dependent entity, IDependentView value)
        {
            Func<Member, int> AssignLineNumber = x =>
                {
                    int result = 0;
                    if (value.LineNumber == 0)
                    {
                        if (x.Dependents.Any())
                            result = x.Dependents.Max(o => o.LineNumber) + 1;
                        else
                            result = 1;
                    }
                    else
                        result = value.LineNumber;

                    return result;
                };

            entity.MemberID = value.MemberID;
            entity.LineNumber = AssignLineNumber(_model);
            entity.LastName = value.LastName;
            entity.FirstName = value.FirstName;
            entity.MiddleName = value.MiddleName;
            entity.Relation = _db.GetTable<Relation>().Single(r => r.RelationID == value.RelationID);
            //entity.RelationID = value.RelationID;
        }

        private void SetEducationalAttainmentValue(EducationalAttainment entity, IEducationalAttainmentView value)
        {
            Func<Member, int> AssignLineNumber = x =>
            {
                int result = 0;
                if (value.LineNumber == 0)
                {
                    if (x.EducationalAttainments.Any())
                        result = x.EducationalAttainments.Max(o => o.LineNumber) + 1;
                    else
                        result = 1;
                }
                else
                    result = value.LineNumber;

                return result;
            };

            entity.MemberID = value.MemberID;
            entity.LineNumber = AssignLineNumber(_model);
            entity.Level = value.Level;
            entity.School = value.School;
            entity.Year = value.Year;
        }

        private void SetValuesToView(IMemberView view, Member entity)
        {
            view.MemberID = entity.MemberID;
            view.AccountNumber = entity.AccountNumber;
            view.AccountStatusID = entity.AccountStatusID;
            view.MembershipCategoryID = entity.MembershipCategoryID;
            view.ApplicationDate = entity.ApplicationDate;
            view.LastName = entity.LastName;
            view.FirstName = entity.FirstName;
            view.MiddleName = entity.MiddleName;
            view.DateOfBirth = entity.DateOfBirth;
            view.PlaceOfBirth = entity.PlaceOfBirth;
            view.MaritalStatusID = entity.MaritalStatusID;
            view.SexTypeID = entity.SexTypeID;
            view.Address = entity.Address;
            view.Province = entity.Province;
            view.HomePhone = entity.HomePhone;
            view.MobilePhone = entity.MobilePhone;
            view.MotherMaidenName = entity.MotherMaidenName;
            view.LanguageDialects = entity.LanguageDialects;
            view.HighestEducationalAttainment = entity.HighestEducationalAttainment;
            view.Occupation = entity.Occupation;
            view.Employer = entity.Employer;
            view.MonthlySalary = entity.MonthlySalary ?? 0M;
            view.OfficeAddress = entity.OfficeAddress;
            view.OfficePhone = entity.OfficePhone;
            view.SpouseLastName = entity.SpouseLastName;
            view.SpouseFirstName = entity.SpouseFirstName;
            view.SpouseMiddleName = entity.SpouseMiddleName;
            view.SpouseContactNumber = entity.SpouseContactNumber;
            view.SpouseOccupation = entity.SpouseOccupation;
            view.SpouseEmployer = entity.SpouseEmployer;
            view.SpouseOfficeAddress = entity.SpouseOfficeAddress;
            view.SpouseOfficePhone = entity.SpouseOfficePhone;
            view.NearestRelativeLastName = entity.NearestRelativeLastName;
            view.NearestRelativeFirstName = entity.NearestRelativeFirstName;
            view.NearestRelativeMiddleName = entity.NearestRelativeMiddleName;
            view.NearestRelativeContactNumber = entity.NearestRelativeContactNumber;
            view.MotherLastName = entity.MotherLastName;
            view.MotherFirstName = entity.MotherFirstName;
            view.MotherMiddleName = entity.MotherMiddleName;
            view.MotherContactNumber = entity.MotherContactNumber;
            view.MotherOccupation = entity.MotherOccupation;
            view.MotherAddress = entity.MotherAddress;
            view.FatherLastName = entity.FatherLastName;
            view.FatherFirstName = entity.FatherFirstName;
            view.FatherMiddleName = entity.FatherMiddleName;
            view.FatherContactNumber = entity.FatherContactNumber;
            view.FatherOccupation = entity.FatherOccupation;
            view.FatherAddress = entity.FatherAddress;
            view.Picture = entity.Picture.Image != null ? entity.Picture.Image.ToArray() : null;
            view.Signature = entity.Picture.Signature != null ? entity.Picture.Signature.ToArray() : null;
            view.Dependents = GetDependentsFromMemberEntity(entity);
            view.EducationalAttainments = GetEducationalAttainmentsFromMemberEntity(entity);

            _availedServices = new AvailedServicesAdapter(entity.AvailedServices);
            view.AvailedServices.GetValuesFrom(_availedServices);
        }

        private IList<DependentModel> GetDependentsFromMemberEntity(Member member)
        {
            var query = member.Dependents
                .Select(x => new DependentModel()
                {
                    MemberID = x.MemberID,
                    LineNumber = x.LineNumber,
                    LastName = x.LastName,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    RelationID = x.RelationID,
                    RelationName = x.Relation.RelationName
                });

            return query.Any() ? query.ToList() : new List<DependentModel>();
        }

        private IList<EducationalAttainmentModel> GetEducationalAttainmentsFromMemberEntity(Member member)
        {
            var query = member.EducationalAttainments
                .Select(x => new EducationalAttainmentModel()
                {
                    MemberID = x.MemberID,
                    LineNumber = x.LineNumber,
                    Level = x.Level,
                    School = x.School,
                    Year = x.Year,
                });

            return query.Any() ? query.ToList() : new List<EducationalAttainmentModel>();
        }

        private void SetValuesToModel(Member entity, IMemberView view)
        {
            entity.MemberID = view.MemberID;
            entity.AccountNumber = view.AccountNumber;
            entity.AccountStatusID = view.AccountStatusID;
            entity.MembershipCategoryID = view.MembershipCategoryID;
            entity.ApplicationDate = view.ApplicationDate;
            entity.LastName = view.LastName;
            entity.FirstName = view.FirstName;
            entity.MiddleName = view.MiddleName;
            entity.DateOfBirth = view.DateOfBirth;
            entity.PlaceOfBirth = view.PlaceOfBirth;
            entity.MaritalStatusID = view.MaritalStatusID;
            entity.SexTypeID = view.SexTypeID;
            entity.Address = view.Address;
            entity.Province = view.Province;
            entity.HomePhone = view.HomePhone;
            entity.MobilePhone = view.MobilePhone;
            entity.MotherMaidenName = view.MotherMaidenName;
            entity.LanguageDialects = view.LanguageDialects;
            entity.HighestEducationalAttainment = view.HighestEducationalAttainment;
            entity.Occupation = view.Occupation;
            entity.Employer = view.Employer;
            entity.MonthlySalary = view.MonthlySalary;
            entity.OfficeAddress = view.OfficeAddress;
            entity.OfficePhone = view.OfficePhone;
            entity.SpouseLastName = view.SpouseLastName;
            entity.SpouseFirstName = view.SpouseFirstName;
            entity.SpouseMiddleName = view.SpouseMiddleName;
            entity.SpouseContactNumber = view.SpouseContactNumber;
            entity.SpouseOccupation = view.SpouseOccupation;
            entity.SpouseEmployer = view.SpouseEmployer;
            entity.SpouseOfficeAddress = view.SpouseOfficeAddress;
            entity.SpouseOfficePhone = view.SpouseOfficePhone;
            entity.NearestRelativeLastName = view.NearestRelativeLastName;
            entity.NearestRelativeFirstName = view.NearestRelativeFirstName;
            entity.NearestRelativeMiddleName = view.NearestRelativeMiddleName;
            entity.NearestRelativeContactNumber = view.NearestRelativeContactNumber;
            entity.MotherLastName = view.MotherLastName;
            entity.MotherFirstName = view.MotherFirstName;
            entity.MotherMiddleName = view.MotherMiddleName;
            entity.MotherContactNumber = view.MotherContactNumber;
            entity.MotherOccupation = view.MotherOccupation;
            entity.MotherAddress = view.MotherAddress;
            entity.FatherLastName = view.FatherLastName;
            entity.FatherFirstName = view.FatherFirstName;
            entity.FatherMiddleName = view.FatherMiddleName;
            entity.FatherContactNumber = view.FatherContactNumber;
            entity.FatherOccupation = view.FatherOccupation;
            entity.FatherAddress = view.FatherAddress;
            entity.Picture.Image = view.Picture != null ? new Binary(view.Picture) : null;
            entity.Picture.Signature = view.Signature != null ? new Binary(view.Signature) : null;

            _availedServices.GetValuesFrom(view.AvailedServices);

            //model.Dependents = _dependents;
            //model.AvailedServices.GetValuesFrom(view.AvailedServices);
        }

        private void InitializeViewValue(IMemberView view)
        {
            view.AccountNumber = string.Empty;
            view.AccountStatusID = AccountStatusCodes.Active;
            view.MembershipCategoryID = MembershipCategoryCodes.Regular;
            view.ApplicationDate = DateTime.Today;
            view.LastName = string.Empty;
            view.FirstName = string.Empty;
            view.MiddleName = string.Empty;
            view.DateOfBirth = DateTime.Today;
            view.PlaceOfBirth = string.Empty;
            view.MaritalStatusID = MaritalStatusCodes.Single;
            view.SexTypeID = SexTypeCodes.Male;
            view.Address = string.Empty;
            view.Province = string.Empty;
            view.HomePhone = string.Empty;
            view.MobilePhone = string.Empty;
            view.MotherMaidenName = string.Empty;
            view.LanguageDialects = string.Empty;
            view.HighestEducationalAttainment = string.Empty;
            view.Occupation = string.Empty;
            view.Employer = string.Empty;
            view.MonthlySalary = 0M;
            view.OfficeAddress = string.Empty;
            view.OfficePhone = string.Empty;
            view.SpouseLastName = string.Empty;
            view.SpouseFirstName = string.Empty;
            view.SpouseMiddleName = string.Empty;
            view.SpouseContactNumber = string.Empty;
            view.SpouseOccupation = string.Empty;
            view.SpouseEmployer = string.Empty;
            view.SpouseOfficeAddress = string.Empty;
            view.SpouseOfficePhone = string.Empty;
            view.NearestRelativeLastName = string.Empty;
            view.NearestRelativeFirstName = string.Empty;
            view.NearestRelativeMiddleName = string.Empty;
            view.NearestRelativeContactNumber = string.Empty;
            view.MotherLastName = string.Empty;
            view.MotherFirstName = string.Empty;
            view.MotherMiddleName = string.Empty;
            view.MotherContactNumber = string.Empty;
            view.MotherOccupation = string.Empty;
            view.MotherAddress = string.Empty;
            view.FatherLastName = string.Empty;
            view.FatherFirstName = string.Empty;
            view.FatherMiddleName = string.Empty;
            view.FatherContactNumber = string.Empty;
            view.FatherOccupation = string.Empty;
            view.FatherAddress = string.Empty;
            view.Picture = null;
            view.Signature = null;
            view.Dependents = new List<DependentModel>();
            view.EducationalAttainments = new List<EducationalAttainmentModel>();

            view.AvailedServices.SetValues(false);

            _availedServices = null;
        }

        #endregion
    }
}
