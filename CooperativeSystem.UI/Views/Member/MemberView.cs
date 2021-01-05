using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Models.Projections;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.UI.Views.Maintenance;
using CooperativeSystem.UI.Views.Utilities;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;
using CooperativeSystem.Service.Presenters.Lookups.MembershipCategories;

namespace CooperativeSystem.UI.Views.Member
{
    public partial class MemberView : DetailsFormTemplate, IMemberView
    {
        private readonly MemberPresenter _presenter;
        private readonly DependentView _dependentView;
        private readonly EducationalAttainmentView _educationalAttainmentView;

        public MemberView()
        {
            InitializeComponent();

            _dependentsDataGridView.AutoGenerateColumns = false;
            _dependentsDataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn() { DataPropertyName = "FullName", FillWeight = Width * .6F /* 137.0558F */, HeaderText = "Name", ReadOnly = true },
                new DataGridViewTextBoxColumn() { DataPropertyName = "RelationName", FillWeight = Width * .45F /* 96.97487F */, HeaderText = "Category", ReadOnly = true }
            );

            _educationalAttainmentDataGridView.AutoGenerateColumns = false;
            _educationalAttainmentDataGridView.Columns.AddRange(
                new DataGridViewTextBoxColumn() { DataPropertyName = "Level", FillWeight = Width * .3F /* 137.0558F */, HeaderText = "Level", ReadOnly = true },
                new DataGridViewTextBoxColumn() { DataPropertyName = "School", FillWeight = Width * .3F /* 96.97487F */, HeaderText = "School", ReadOnly = true },
                new DataGridViewTextBoxColumn() { DataPropertyName = "Year", FillWeight = Width * .65F /* 96.97487F */, HeaderText = "Year", ReadOnly = true }
            );

            _openFileDialog.Filter =
                "Image Files(JPEG, GIF, BMP)|*.jpg;*.jpeg;*.gif;*.bmp|" +
                "JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg;|" +
                "GIF Files(*.gif)|*.gif;|" +
                "BMP Files(*.bmp)|*.bmp";

            _dependentView = new DependentView();
            _educationalAttainmentView = new EducationalAttainmentView();

            _presenter = new MemberPresenter(this, _dependentView, _educationalAttainmentView);
            _presenter.Success += new SuccessHandler(NotifyInformation);
            _presenter.Error += new ErrorHandler(NotifyError);

            // register controls to validate
            ControlValidator.RegisterControl(_membershipCategoryComboBox, InputType.Normal, true, "Category");
            ControlValidator.RegisterControl(_applicationDateDateTimePicker, InputType.NumericOnly, false, "Date Applied");
            ControlValidator.RegisterControl(_lastNameTextBox, InputType.Normal, true, "Last Name", 30);
            ControlValidator.RegisterControl(_firstNameTextBox, InputType.Normal, true, "First Name", 30);
            ControlValidator.RegisterControl(_middleNameTextBox, InputType.Normal, false, "Middle Name", 30);
            ControlValidator.RegisterControl(_dateOfBirthDateTimePicker, InputType.Normal, false, "Date of Birth");
            ControlValidator.RegisterControl(_placeOfBirthTextBox, InputType.Normal, false, "Place of Birth", 80);
            ControlValidator.RegisterControl(_maritalStatusComboBox, InputType.Normal, false, "Marital Status");
            ControlValidator.RegisterControl(_sexComboBox, InputType.Normal, false, "Sex");
            ControlValidator.RegisterControl(_addressTextBox, InputType.Normal, false, "Address", 80);
            ControlValidator.RegisterControl(_provinceTextBox, InputType.Normal, false, "Provine", 80);
            ControlValidator.RegisterControl(_homePhoneTextBox, InputType.Normal, false, "Home Phone", 50);
            ControlValidator.RegisterControl(_mobilePhoneTextBox, InputType.Normal, false, "Mobile Phone", 50);
            ControlValidator.RegisterControl(_motherMaidenNameTextBox, InputType.Normal, false, "Mother's Maiden Name", 90);
            ControlValidator.RegisterControl(_languageDialectsTextBox, InputType.Normal, false, "Language/Dialects", 60);
            ControlValidator.RegisterControl(_highestEducationalAttainmentTextBox, InputType.Normal, false, "Highest Educational Attainment", 60);
            ControlValidator.RegisterControl(_occupationTextBox, InputType.Normal, false, "Occupation", 50);
            ControlValidator.RegisterControl(_employerTextBox, InputType.Normal, false, "Employer", 60);
            ControlValidator.RegisterControl(_monthlySalaryTextBox, InputType.Currency, false, "Monthly Salary", 16, 2);
            ControlValidator.RegisterControl(_officeAddressTextBox, InputType.Normal, false, "Office Address", 80);
            ControlValidator.RegisterControl(_officePhoneTextBox, InputType.Normal, false, "Office Phone", 50);
            ControlValidator.RegisterControl(_spouseLastNameTextBox, InputType.Normal, false, "Spouse Last Name", 30);
            ControlValidator.RegisterControl(_spouseFirstNameTextBox, InputType.Normal, false, "Spouse First Name", 30);
            ControlValidator.RegisterControl(_spouseMiddleNameTextBox, InputType.Normal, false, "Spouse Middle Name", 30);
            ControlValidator.RegisterControl(_spouseContactNumberTextBox, InputType.Normal, false, "Spouse Contact Number", 15);
            ControlValidator.RegisterControl(_spouseOccupationTextBox, InputType.Normal, false, "Spouse Occupation", 50);
            ControlValidator.RegisterControl(_spouseEmployerTextBox, InputType.Normal, false, "Spouse Employer", 50);
            ControlValidator.RegisterControl(_spouseOfficeAddressTextBox, InputType.Normal, false, "Spouse Office Address", 80);
            ControlValidator.RegisterControl(_spouseOfficePhoneTextBox, InputType.Normal, false, "Spouse Office Phone", 50);
            ControlValidator.RegisterControl(_nearestRelativeLastNameTextBox, InputType.Normal, false, "Nearest Relative Last Name", 30);
            ControlValidator.RegisterControl(_nearestRelativeFirstNameTextBox, InputType.Normal, false, "Nearest Relative First Name", 30);
            ControlValidator.RegisterControl(_nearestRelativeMiddleNameTextBox, InputType.Normal, false, "Nearest Relative Middle Name", 30);
            ControlValidator.RegisterControl(_nearestRelativeContactNumberTextBox, InputType.Normal, false, "Nearest Relative Contact Number", 15);
            ControlValidator.RegisterControl(_motherLastNameTextBox, InputType.Normal, false, "Mother's Last Name", 50);
            ControlValidator.RegisterControl(_motherFirstNameTextBox, InputType.Normal, false, "Mother's First Name", 50);
            ControlValidator.RegisterControl(_motherMiddleNameTextBox, InputType.Normal, false, "Mother's Middle Name", 50);
            ControlValidator.RegisterControl(_motherContactNumberTextBox, InputType.Normal, false, "Mother's Contact Number", 50);
            ControlValidator.RegisterControl(_motherOccupationTextBox, InputType.Normal, false, "Mother's Occupation", 50);
            ControlValidator.RegisterControl(_motherAddressTextBox, InputType.Normal, false, "Mother's Address", 80);
            ControlValidator.RegisterControl(_fatherLastNameTextBox, InputType.Normal, false, "Father's Last Name", 50);
            ControlValidator.RegisterControl(_fatherFirstNameTextBox, InputType.Normal, false, "Father's First Name", 50);
            ControlValidator.RegisterControl(_fatherMiddleNameTextBox, InputType.Normal, false, "Father's Middle Name", 50);
            ControlValidator.RegisterControl(_fatherContactNumberTextBox, InputType.Normal, false, "Father's Contact Number", 50);
            ControlValidator.RegisterControl(_fatherOccupationTextBox, InputType.Normal, false, "Father's Occupation", 50);
            ControlValidator.RegisterControl(_fatherAddressTextBox, InputType.Normal, false, "Father's Address", 80);
        }

        #region IMemberView Members

        public event MembershipCategoryChangedEventHandler MembershipCategoryChangedEvent;

        public long MemberID { get; set; }

        public string AccountNumber
        {
            get { return _accountNumberTextBox.Text; }
            set { _accountNumberTextBox.Text = value; }
        }

        public string AccountStatusID { get; set; }

        public string MembershipCategoryID
        {
            get { return _membershipCategoryComboBox.SelectedValue.ToString(); }
            set { _membershipCategoryComboBox.SelectedValue = value; }
        }

        public string MembershipCategoryName
        {
            get { return ((MembershipCategory)_membershipCategoryComboBox.SelectedItem).MembershipCategoryName; }
        }

        public DateTime ApplicationDate
        {
            get { return _applicationDateDateTimePicker.Value; }
            set { _applicationDateDateTimePicker.Value = value; }
        }

        public string LastName
        {
            get { return _lastNameTextBox.Text; }
            set { _lastNameTextBox.Text = value; }
        }

        public string FirstName
        {
            get { return _firstNameTextBox.Text; }
            set { _firstNameTextBox.Text = value; }
        }

        public string MiddleName
        {
            get { return _middleNameTextBox.Text; }
            set { _middleNameTextBox.Text = value; }
        }

        public string FullName
        {
            get { return LastName + ", " + FirstName + " " + MiddleName; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirthDateTimePicker.Value; }
            set { _dateOfBirthDateTimePicker.Value = value; }
        }

        public string PlaceOfBirth
        {
            get { return _placeOfBirthTextBox.Text; }
            set { _placeOfBirthTextBox.Text = value; }
        }

        public char MaritalStatusID
        {
            get { return Convert.ToChar(_maritalStatusComboBox.SelectedValue); }
            set { _maritalStatusComboBox.SelectedValue = value; }
        }

        public char SexTypeID
        {
            get { return Convert.ToChar(_sexComboBox.SelectedValue); }
            set { _sexComboBox.SelectedValue = value; }
        }

        public string Address
        {
            get { return _addressTextBox.Text; }
            set { _addressTextBox.Text = value; }
        }

        public string Province
        {
            get { return _provinceTextBox.Text; }
            set { _provinceTextBox.Text = value; }
        }

        public string HomePhone
        {
            get { return _homePhoneTextBox.Text; }
            set { _homePhoneTextBox.Text = value; }
        }

        public string MobilePhone
        {
            get { return _mobilePhoneTextBox.Text; }
            set { _mobilePhoneTextBox.Text = value; }
        }

        public string MotherMaidenName
        {
            get { return _motherMaidenNameTextBox.Text; }
            set { _motherMaidenNameTextBox.Text = value; }
        }

        public string LanguageDialects
        {
            get { return _languageDialectsTextBox.Text; }
            set { _languageDialectsTextBox.Text = value; }
        }

        public string HighestEducationalAttainment
        {
            get { return _highestEducationalAttainmentTextBox.Text; }
            set { _highestEducationalAttainmentTextBox.Text = value; }
        }

        public string Occupation
        {
            get { return _occupationTextBox.Text; }
            set { _occupationTextBox.Text = value; }
        }

        public string Employer
        {
            get { return _employerTextBox.Text; }
            set { _employerTextBox.Text = value; }
        }

        public decimal MonthlySalary
        {
            get { return Convert.ToDecimal(_monthlySalaryTextBox.Text); }
            set { _monthlySalaryTextBox.Text = value.ToString("N2"); }
        }

        public string OfficeAddress
        {
            get { return _officeAddressTextBox.Text; }
            set { _officeAddressTextBox.Text = value; }
        }

        public string OfficePhone
        {
            get { return _officePhoneTextBox.Text; }
            set { _officePhoneTextBox.Text = value; }
        }

        public string SpouseLastName
        {
            get { return _spouseLastNameTextBox.Text; }
            set { _spouseLastNameTextBox.Text = value; }
        }

        public string SpouseFirstName
        {
            get { return _spouseFirstNameTextBox.Text; }
            set { _spouseFirstNameTextBox.Text = value; }
        }

        public string SpouseMiddleName
        {
            get { return _spouseMiddleNameTextBox.Text; }
            set { _spouseMiddleNameTextBox.Text = value; }
        }

        public string SpouseContactNumber
        {
            get { return _spouseContactNumberTextBox.Text; }
            set { _spouseContactNumberTextBox.Text = value; }
        }

        public string SpouseOccupation
        {
            get { return _spouseOccupationTextBox.Text; }
            set { _spouseOccupationTextBox.Text = value; }
        }

        public string SpouseEmployer
        {
            get { return _spouseEmployerTextBox.Text; }
            set { _spouseEmployerTextBox.Text = value; }
        }

        public string SpouseOfficeAddress
        {
            get { return _spouseOfficeAddressTextBox.Text; }
            set { _spouseOfficeAddressTextBox.Text = value; }
        }

        public string SpouseOfficePhone
        {
            get { return _spouseOfficePhoneTextBox.Text; }
            set { _spouseOfficePhoneTextBox.Text = value; }
        }

        public string NearestRelativeLastName
        {
            get { return _nearestRelativeLastNameTextBox.Text; }
            set { _nearestRelativeLastNameTextBox.Text = value; }
        }

        public string NearestRelativeFirstName
        {
            get { return _nearestRelativeFirstNameTextBox.Text; }
            set { _nearestRelativeFirstNameTextBox.Text = value; }
        }

        public string NearestRelativeMiddleName
        {
            get { return _nearestRelativeMiddleNameTextBox.Text; }
            set { _nearestRelativeMiddleNameTextBox.Text = value; }
        }

        public string NearestRelativeContactNumber
        {
            get { return _nearestRelativeContactNumberTextBox.Text; }
            set { _nearestRelativeContactNumberTextBox.Text = value; }
        }

        public string MotherLastName
        {
            get { return _motherLastNameTextBox.Text; }
            set { _motherLastNameTextBox.Text = value; }
        }

        public string MotherFirstName
        {
            get { return _motherFirstNameTextBox.Text; }
            set { _motherFirstNameTextBox.Text = value; }
        }

        public string MotherMiddleName
        {
            get { return _motherMiddleNameTextBox.Text; }
            set { _motherMiddleNameTextBox.Text = value; }
        }

        public string MotherContactNumber
        {
            get { return _motherContactNumberTextBox.Text; }
            set { _motherContactNumberTextBox.Text = value; }
        }

        public string MotherOccupation
        {
            get { return _motherOccupationTextBox.Text; }
            set { _motherOccupationTextBox.Text = value; }
        }

        public string MotherAddress
        {
            get { return _motherAddressTextBox.Text; }
            set { _motherAddressTextBox.Text = value; }
        }

        public string FatherLastName
        {
            get { return _fatherLastNameTextBox.Text; }
            set { _fatherLastNameTextBox.Text = value; }
        }

        public string FatherFirstName
        {
            get { return _fatherFirstNameTextBox.Text; }
            set { _fatherFirstNameTextBox.Text = value; }
        }

        public string FatherMiddleName
        {
            get { return _fatherMiddleNameTextBox.Text; }
            set { _fatherMiddleNameTextBox.Text = value; }
        }

        public string FatherContactNumber
        {
            get { return _fatherContactNumberTextBox.Text; }
            set { _fatherContactNumberTextBox.Text = value; }
        }

        public string FatherOccupation
        {
            get { return _fatherOccupationTextBox.Text; }
            set { _fatherOccupationTextBox.Text = value; }
        }

        public string FatherAddress
        {
            get { return _fatherAddressTextBox.Text; }
            set { _fatherAddressTextBox.Text = value; }
        }

        public byte[] Picture
        {
            get
            {
                if (_picturePictureBox.Image == null)
                    return null;

                // save image from PictureBox into MemoryStream object
                var stream = new MemoryStream();
                _picturePictureBox.Image.Save(stream, ImageFormat.Jpeg);
                var blob = stream.ToArray();

                return blob;
            }
            set
            {
                if (value != null)
                    _picturePictureBox.Image = Image.FromStream(new MemoryStream(value));
                else
                    _picturePictureBox.Image = null;
            }
        }

        public byte[] Signature
        {
            get
            {
                if (_signaturePictureBox.Image == null)
                    return null;

                // save image from PictureBox into MemoryStream object
                var stream = new MemoryStream();
                _signaturePictureBox.Image.Save(stream, ImageFormat.Jpeg);
                var blob = stream.ToArray();

                return blob;
            }
            set
            {
                if (value != null)
                    _signaturePictureBox.Image = Image.FromStream(new MemoryStream(value));
                else
                    _signaturePictureBox.Image = null;
            }
        }

        public IList<DependentModel> Dependents
        {
            get
            {
                var list = new List<DependentModel>();
                if (this._dependentsDataGridView.DataSource != null)
                    list = ((SearchableSortableBindingList<DependentModel>)this._dependentsDataGridView.DataSource).ToList<DependentModel>();
                return list;
            }
            set
            {
                SearchableSortableBindingList<DependentModel> list = null;
                if (value != null)
                    list = new SearchableSortableBindingList<DependentModel>((IList<DependentModel>)value);
                this._dependentsDataGridView.DataSource = list;
            }
        }

        public IList<EducationalAttainmentModel> EducationalAttainments
        {
            get
            {
                var list = new List<EducationalAttainmentModel>();
                if (this._educationalAttainmentDataGridView.DataSource != null)
                    list = ((SearchableSortableBindingList<EducationalAttainmentModel>)this._educationalAttainmentDataGridView.DataSource).ToList<EducationalAttainmentModel>();
                return list;
            }
            set
            {
                SearchableSortableBindingList<EducationalAttainmentModel> list = null;
                if (value != null)
                    list = new SearchableSortableBindingList<EducationalAttainmentModel>((IList<EducationalAttainmentModel>)value);
                this._educationalAttainmentDataGridView.DataSource = list;
            }

        }

        public IAvailedServicesView AvailedServices
        {
            get { return _availedServiceView; }
        }

        public void PopulateAccountStatusPulldown(IList<AccountStatus> accountStatuses)
        {
            //throw new NotImplementedException();
        }

        public void PopulateMembershipCategoryPulldown(IList<MembershipCategory> membershipCategories)
        {
            _membershipCategoryComboBox.DataSource = membershipCategories;
            _membershipCategoryComboBox.ValueMember = "MembershipCategoryID";
            _membershipCategoryComboBox.DisplayMember = "MembershipCategoryName";
        }

        public void PopulateMaritalStatusPulldown(IList<MaritalStatus> maritalStatuses)
        {
            _maritalStatusComboBox.DataSource = maritalStatuses;
            _maritalStatusComboBox.ValueMember = "MaritalStatusID";
            _maritalStatusComboBox.DisplayMember = "MaritalStatusName";
        }

        public void PopulateSexTypePulldown(IList<SexType> sexTypes)
        {
            _sexComboBox.DataSource = sexTypes;
            _sexComboBox.ValueMember = "SexTypeID";
            _sexComboBox.DisplayMember = "SexTypeName";
        }

        public void PopulateRelationPulldown(IList<Relation> relations)
        {
            //relationBindingSource.DataSource = relations;
        }

        public void LoadMember(long memberID)
        {
            _presenter.LoadMember(memberID);
        }

        public void NewMember()
        {
            _presenter.NewMember();
        }

        public void RefreshMembershipCategoryServices(IServicesAdapter services)
        {
            _availedServiceView.GetValuesFrom(services);
        }

        #endregion

        #region Routine Helpers

        private DependentModel GetSelectedDependent()
        {
            DependentModel item = null;

            if (this._dependentsDataGridView.CurrentRow != null)
                item = (DependentModel)this._dependentsDataGridView.CurrentRow.DataBoundItem;
            else
                this.NotifyError(this, "There is no selected item.");

            return item;
        }

        private void PassDependentValuesToView(IDependentView view, DependentModel item)
        {
            view.MemberID = item.MemberID;
            view.LineNumber = item.LineNumber;
            view.LastName = item.LastName;
            view.FirstName = item.FirstName;
            view.MiddleName = item.MiddleName;
            view.RelationID = item.RelationID;
        }

        private EducationalAttainmentModel GetSelectedEducationalAttainment()
        {
            EducationalAttainmentModel item = null;

            if (this._educationalAttainmentDataGridView.CurrentRow != null)
                item = (EducationalAttainmentModel)this._educationalAttainmentDataGridView.CurrentRow.DataBoundItem;
            else
                this.NotifyError(this, "There is no selected item.");

            return item;
        }

        private void PassEducationalAttainmentValuesToView(IEducationalAttainmentView view, EducationalAttainmentModel item)
        {
            view.MemberID = item.MemberID;
            view.LineNumber = item.LineNumber;
            view.Level = item.Level;
            view.School = item.School;
            view.Year = item.Year;
        }

        protected virtual void OnMembershipCategoryChanged(EventArgs e)
        {
            RaiseMembershipCategoryChangedEvent(this, e);
        }

        private void RaiseMembershipCategoryChangedEvent(object sender, EventArgs e)
        {
            if (MembershipCategoryChangedEvent != null)
                MembershipCategoryChangedEvent.Invoke(sender, e);
        }

        #endregion

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!ControlValidator.Validate())
                return;

            if (ActionType == ActionType.Insert)
            {
                if (AskConfirmation(this, "Do you want to add new member?") == DialogResult.Yes)
                {
                    if (_presenter.Insert())
                    {
                        OnItemAdded(new EventArgs());
                        Close();
                    }
                }
            }
            else if (ActionType == ActionType.Update)
            {
                if (AskConfirmation(this, "Do you want to modify member information?") == DialogResult.Yes)
                {
                    if (_presenter.Update())
                    {
                        OnItemModified(new EventArgs());
                        Close();
                    }
                }
            }
            else if (ActionType == ActionType.Delete)
            {
                if (AskConfirmation(this, "Do you want to delete member?") == DialogResult.Yes)
                {
                    if (_presenter.Delete())
                    {
                        OnItemDeleted(new EventArgs());
                        Close();
                    }
                }
            }
        }

        private void CloseAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (AskConfirmation(this, "Do you want to close this account?") != DialogResult.Yes)
                    return;

                _presenter.CloseAccount();
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }

        private void MembershipCategoryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnMembershipCategoryChanged(new EventArgs());
        }

        private void MembershipCategoryComboBox_BindingContextChanged(object sender, EventArgs e)
        {
            if (sender == null || ((ComboBox)sender).SelectedValue == null)
                return;

            OnMembershipCategoryChanged(new EventArgs());
        }

        private void AddDependentButton_Click(object sender, EventArgs e)
        {
            _dependentView.ActionType = ActionType.Insert;
            PassDependentValuesToView(_dependentView, new DependentModel());
            _dependentView.ShowDialog(this);
        }

        private void ModifyDependentButton_Click(object sender, EventArgs e)
        {
            var item = GetSelectedDependent();
            if (item != null)
            {
                _dependentView.ActionType = ActionType.Update;
                PassDependentValuesToView(_dependentView, item);
                _dependentView.ShowDialog(this);
            }
        }

        private void DeleteDependentButton_Click(object sender, EventArgs e)
        {
            var item = GetSelectedDependent();
            if (item != null)
            {
                _dependentView.ActionType = ActionType.Delete;
                PassDependentValuesToView(_dependentView, item);
                _dependentView.ShowDialog(this);
            }
        }

        private void MembershipCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _tabControl1.TabPages.Clear();

            if (this.MembershipCategoryID == MembershipCategoryCodes.JuniorSaver)
            {
                _tabControl1.TabPages.AddRange(new TabPage[]
                {
                    _memberTabPage,
                    _parentsTabPage,
                    _educationTabPage,
                    _relativesTabPage,
                    _availedServicesTabPage,
                    _signatureTabPage
                });
            }
            else
            {
                _tabControl1.TabPages.AddRange(new TabPage[]
                {
                    _memberTabPage,
                    _spouseTabPage,
                    _educationTabPage,
                    _employmentTabPage,
                    _relativesTabPage,
                    _availedServicesTabPage,
                    _signatureTabPage
                });
            }
        }

        private void AddEducationButton_Click(object sender, EventArgs e)
        {
            _educationalAttainmentView.ActionType = ActionType.Insert;
            PassEducationalAttainmentValuesToView(_educationalAttainmentView, new EducationalAttainmentModel());
            _educationalAttainmentView.ShowDialog(this);

        }

        private void ModifyEducationButton_Click(object sender, EventArgs e)
        {
            var item = GetSelectedEducationalAttainment();
            if (item != null)
            {
                _educationalAttainmentView.ActionType = ActionType.Update;
                PassEducationalAttainmentValuesToView(_educationalAttainmentView, item);
                _educationalAttainmentView.ShowDialog(this);
            }
        }

        private void DeleteEducationButton_Click(object sender, EventArgs e)
        {
            var item = GetSelectedEducationalAttainment();
            if (item != null)
            {
                _educationalAttainmentView.ActionType = ActionType.Delete;
                PassEducationalAttainmentValuesToView(_educationalAttainmentView, item);
                _educationalAttainmentView.ShowDialog(this);
            }

        }

        private void LoadPictureButton_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                var file = _openFileDialog.FileName;
                _picturePictureBox.Image = Image.FromFile(file);
            }
        }

        private void LoadSignatureButton_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                var file = _openFileDialog.FileName;
                _signaturePictureBox.Image = Image.FromFile(file);
            }
        }

        //private void MemberView_Shown(object sender, EventArgs e)
        //{
        //    _accountNumberTextBox.ReadOnly = true;
        //    if (ActionType == ActionType.Insert)
        //    {
        //        _autoGenerateCeckBox.Enabled = true;
        //        _autoGenerateCeckBox.Checked = true;
        //    }
        //    else
        //    {
        //        _autoGenerateCeckBox.Enabled = false;
        //        _autoGenerateCeckBox.Checked = false;
        //    }
        //}

        //private void AutoGenerateCeckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    _accountNumberTextBox.ReadOnly = ((CheckBox)sender).Checked;
        //}
    }
}
