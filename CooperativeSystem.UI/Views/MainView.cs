using System;
using System.Linq;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Lookups.UserCategories;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.Service.Utilities.Logs;
using CooperativeSystem.UI.Views.Loans;
using CooperativeSystem.UI.Views.Lookups;
using CooperativeSystem.UI.Views.Maintenance;
using CooperativeSystem.UI.Views.Member;
using CooperativeSystem.UI.Views.MiscellaneousIncomes;
using CooperativeSystem.UI.Views.Plans.CollegeInsurancePlan;
using CooperativeSystem.UI.Views.Plans.PensionPlan;
using CooperativeSystem.UI.Views.Reports.Adjustments;
using CooperativeSystem.UI.Views.Reports.AgingLoans;
using CooperativeSystem.UI.Views.Reports.CashFlows;
using CooperativeSystem.UI.Views.Reports.Collections;
using CooperativeSystem.UI.Views.Reports.DelinquentAccounts;
using CooperativeSystem.UI.Views.Reports.Disbursements;
using CooperativeSystem.UI.Views.Reports.IndividualLedgers;
using CooperativeSystem.UI.Views.Reports.IndividualLedgersRevision;
using CooperativeSystem.UI.Views.Reports.MemberBalanceSummaries;
using CooperativeSystem.UI.Views.Reports.MemberPeriodicalBalanceSummaries;
using CooperativeSystem.UI.Views.Reports.MembersInformations;
using CooperativeSystem.UI.Views.Reports.MemberSummaries;
using CooperativeSystem.UI.Views.Reports.MiscellaneousIncomes;
using CooperativeSystem.UI.Views.Reports.Notices;
using CooperativeSystem.UI.Views.Reports.WithdrawnMembers;
using CooperativeSystem.UI.Views.Savings;
using CooperativeSystem.UI.Views.Savings.CapitalShare;
using CooperativeSystem.UI.Views.Savings.SavingsDeposit;
using CooperativeSystem.UI.Views.Savings.TimeDeposit;
using CooperativeSystem.UI.Views.SpecialFunds.DeathAidFund;
using CooperativeSystem.UI.Views.SpecialFunds.TulunganFund;
using CooperativeSystem.UI.Views.User;
using CooperativeSystem.UI.Views.Utilities;
using CooperativeSystem.Service.Presenters.Loans;

namespace CooperativeSystem.UI.Views
{
    public partial class MainView : FormTemplate, IServicesAdapter
    {
        private ErrorLogger _errorLogger;
        private TabControlHelper _tabControlHelper;
        private Service.Models.User _user;
        private Service.Models.Application _application;
        private AgingLoanTask _agingLoanTask;
        private DelinquentLoanTask _delinquentLoanTask;

        #region Routine Helpers

        /// <summary>
        /// Shows all tabs
        /// </summary>
        private void ShowServices()
        {
            // get currently selected tab
            var selectedMainTabPage = _serviceCategoryTabControl.SelectedTab;
            TabControl selectedSubTabControl = null;
            if (selectedMainTabPage == _savingsTabPage)
                selectedSubTabControl = _savingsTabControl;
            else if (selectedMainTabPage == _loansTabPage)
                selectedSubTabControl = _loansTabControl;
            else if (selectedMainTabPage == _plansTabPage)
                selectedSubTabControl = _plansTabControl;
            else if (selectedMainTabPage == _specialFundsTabPage)
                selectedSubTabControl = _specialFundsTabControl;

            TabPage selectedSubTabPage = null;
            if (selectedSubTabControl != null)
                selectedSubTabPage = selectedSubTabControl.SelectedTab;

            // clear all tab first then show
            // when clearing, selected tab will be changed
            ((IServicesAdapter)this).SetValues(false);
            ((IServicesAdapter)this).SetValues(true);

            // show what was selected 
            if (selectedSubTabControl != null && selectedSubTabPage != null)
                selectedSubTabControl.SelectedTab = selectedSubTabPage;
        }

        /// <summary>
        /// Shows tabs based on availed services
        /// </summary>
        /// <param name="availedServices"></param>
        private void ShowServices(IServicesAdapter availedServices)
        {
            ((IServicesAdapter)this).GetValuesFrom(availedServices);
        }

        public void ClearServicesData()
        {
            // loans
            _applianceLoansSummaryView.ClearSummary();
            _easyLoansSummaryView.ClearSummary();
            _emergencyLoansSummaryView.ClearSummary();
            _equityLoansSummaryView.ClearSummary();
            _pensionLoansSummaryView.ClearSummary();
            _regularLoansSummaryView.ClearSummary();

            // plans
            _cipSummaryView.ClearSummary();
            _pensionPlanSummaryView.ClearSummary();

            // savings
            _capitalSharesSummaryView.ClearSummary();
            _savingsDepositSummaryView.ClearSummary();
            _timeDepositSummaryView.ClearSummary();

            // special funds
            _deathAidFundSummaryView.ClearSummary();
            _tulunganFundSummaryView.ClearSummary();
        }

        private void LoadDisplayedServiceData()
        {
            var service = GetCurrentlyDispalyedService();
            var memberID = _memberInquiryDetailsView.MemberID;

            if (memberID == 0)
                return;

            if (service == null)
                return;

            service.LoadSummary(memberID);
        }

        private ISummaryView GetCurrentlyDispalyedService()
        {
            TabPage serviceCategoryTab = _serviceCategoryTabControl.SelectedTab;
            TabPage serviceTab = null;
            ISummaryView service = null;
            if (serviceCategoryTab == _savingsTabPage)
            {
                serviceTab = _savingsTabControl.SelectedTab;
                if (serviceTab == _capitalShareTabPage)
                    service = _capitalSharesSummaryView;
                else if (serviceTab == _savingsDepositTabPage)
                    service = _savingsDepositSummaryView;
                else if (serviceTab == _timeDepositTabPage)
                    service = _timeDepositSummaryView;
            }
            else if (serviceCategoryTab == _loansTabPage)
            {
                serviceTab = _loansTabControl.SelectedTab;
                if (serviceTab == _applianceLoanTabPage)
                    service = _applianceLoansSummaryView;
                else if (serviceTab == _easyLoanTabPage)
                    service = _easyLoansSummaryView;
                else if (serviceTab == _emergencyLoanTabPage)
                    service = _emergencyLoansSummaryView;
                else if (serviceTab == _equityLoanTabPage)
                    service = _equityLoansSummaryView;
                else if (serviceTab == _pensionLoanTabPage)
                    service = _pensionLoansSummaryView;
                else if (serviceTab == _regularLoanTabPage)
                    service = _regularLoansSummaryView;
            }
            else if (serviceCategoryTab == _plansTabPage)
            {
                serviceTab = _plansTabControl.SelectedTab;
                if (serviceTab == _collegeInsurancePlanTabPage)
                    service = _cipSummaryView;
                else if (serviceTab == _pensionPlanTabPage)
                    service = _pensionPlanSummaryView;
            }
            else if (serviceCategoryTab == _specialFundsTabPage)
            {
                serviceTab = _specialFundsTabControl.SelectedTab;
                if (serviceTab == _deathAidFundTabPage)
                    service = _deathAidFundSummaryView;
                else if (serviceTab == _tulunganFundTabPage)
                    service = _tulunganFundSummaryView;
            }

            return service;
        }

        #endregion

        #region IServicesAdapter Members

        bool IServicesAdapter.CapitalShare
        {
            get
            {
                _tabControlHelper.TabControl = _savingsTabControl;
                return _tabControlHelper.IsVisible(_capitalShareTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _savingsTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_capitalShareTabPage);
                else
                    _tabControlHelper.HideTabPage(_capitalShareTabPage);
            }
        }

        bool IServicesAdapter.SavingsDeposit
        {
            get
            {
                _tabControlHelper.TabControl = _savingsTabControl;
                return _tabControlHelper.IsVisible(_savingsDepositTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _savingsTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_savingsDepositTabPage);
                else
                    _tabControlHelper.HideTabPage(_savingsDepositTabPage);
            }
        }

        bool IServicesAdapter.TimeDeposit
        {
            get
            {
                _tabControlHelper.TabControl = _savingsTabControl;
                return _tabControlHelper.IsVisible(_timeDepositTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _savingsTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_timeDepositTabPage);
                else
                    _tabControlHelper.HideTabPage(_timeDepositTabPage);
            }
        }

        bool IServicesAdapter.ApplianceLoan
        {
            get
            {
                _tabControlHelper.TabControl = _loansTabControl;
                return _tabControlHelper.IsVisible(_applianceLoanTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _loansTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_applianceLoanTabPage);
                else
                    _tabControlHelper.HideTabPage(_applianceLoanTabPage);
            }
        }

        bool IServicesAdapter.EasyLoan
        {
            get
            {
                _tabControlHelper.TabControl = _loansTabControl;
                return _tabControlHelper.IsVisible(_easyLoanTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _loansTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_easyLoanTabPage);
                else
                    _tabControlHelper.HideTabPage(_easyLoanTabPage);
            }
        }

        bool IServicesAdapter.EmergencyLoan
        {
            get
            {
                _tabControlHelper.TabControl = _loansTabControl;
                return _tabControlHelper.IsVisible(_emergencyLoanTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _loansTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_emergencyLoanTabPage);
                else
                    _tabControlHelper.HideTabPage(_emergencyLoanTabPage);
            }
        }

        bool IServicesAdapter.EquityLoan
        {
            get
            {
                _tabControlHelper.TabControl = _loansTabControl;
                return _tabControlHelper.IsVisible(_equityLoanTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _loansTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_equityLoanTabPage);
                else
                    _tabControlHelper.HideTabPage(_equityLoanTabPage);
            }
        }

        bool IServicesAdapter.PensionLoan
        {
            get
            {
                _tabControlHelper.TabControl = _loansTabControl;
                return _tabControlHelper.IsVisible(_pensionLoanTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _loansTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_pensionLoanTabPage);
                else
                    _tabControlHelper.HideTabPage(_pensionLoanTabPage);
            }
        }

        bool IServicesAdapter.RegularLoan
        {
            get
            {
                _tabControlHelper.TabControl = _loansTabControl;
                return _tabControlHelper.IsVisible(_regularLoanTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _loansTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_regularLoanTabPage);
                else
                    _tabControlHelper.HideTabPage(_regularLoanTabPage);
            }
        }

        bool IServicesAdapter.DTILoan { get; set; }

        bool IServicesAdapter.MEDPLoan { get; set; }

        bool IServicesAdapter.PensionPlan
        {
            get
            {
                _tabControlHelper.TabControl = _plansTabControl;
                return _tabControlHelper.IsVisible(_pensionPlanTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _plansTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_pensionPlanTabPage);
                else
                    _tabControlHelper.HideTabPage(_pensionPlanTabPage);
            }
        }

        bool IServicesAdapter.CollegeInsurancePlan
        {
            get
            {
                _tabControlHelper.TabControl = _plansTabControl;
                return _tabControlHelper.IsVisible(_collegeInsurancePlanTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _plansTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_collegeInsurancePlanTabPage);
                else
                    _tabControlHelper.HideTabPage(_collegeInsurancePlanTabPage);
            }
        }

        bool IServicesAdapter.TulunganFund
        {
            get
            {
                _tabControlHelper.TabControl = _specialFundsTabControl;
                return _tabControlHelper.IsVisible(_tulunganFundTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _specialFundsTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_tulunganFundTabPage);
                else
                    _tabControlHelper.HideTabPage(_tulunganFundTabPage);
            }
        }

        bool IServicesAdapter.DeathAidFund
        {
            get
            {
                _tabControlHelper.TabControl = _specialFundsTabControl;
                return _tabControlHelper.IsVisible(_deathAidFundTabPage);
            }
            set
            {
                _tabControlHelper.TabControl = _specialFundsTabControl;
                if (value)
                    _tabControlHelper.ShowTabPage(_deathAidFundTabPage);
                else
                    _tabControlHelper.HideTabPage(_deathAidFundTabPage);
            }
        }

        #endregion

        public MainView()
        {
            InitializeComponent();

            Text = Text + " v" + Application.ProductVersion;

            _errorLogger = new ErrorLogger();
            _tabControlHelper = new TabControlHelper();
            _agingLoanTask = new AgingLoanTask();
            _delinquentLoanTask = new DelinquentLoanTask();

            _memberInquiryDetailsView.MemberInquiryChanged += new MemberInquiryChangeEventHandler(MemberInquiryDetailsView_MemberInquiryChanged);
            _memberInquiryDetailsView.MemberInquiryCleared += new MemberInquiryClearEventHandler(MemberInquiryDetailsView_MemberInquiryCleared);

            ClearServicesData();
        }

        protected override void OnLoad(EventArgs e)
        {
            using (var login = new LoginView())
            {
                if (login.ShowDialog(this) != DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }

                _user = login.GetUser();
                _application = login.GetApplication();

                Program.AppData.UserID = _user.UserID;
                Program.AppData.OrganizationName = _application.OrganizationName;
                Program.AppData.TelephoneNumber = _application.TelephoneNumber;
                Program.AppData.Address = _application.Address;
                Program.AppData.Roles = _user.GetRoles();

                // access rights
                //_menuStrip.Enabled = (_user.UserCategoryID != UserCategoryCodes.RegularUser);

                InitializeAccessRights();
                RunBackgroundTasks();
            }
        }

        private void MemberInquiryDetailsView_MemberInquiryCleared(object sender, EventArgs e)
        {
            ShowServices();
            ClearServicesData();
        }

        private void MemberInquiryDetailsView_MemberInquiryChanged(object sender, MemberInquiryEventArgs e)
        {
            ShowServices(_memberInquiryDetailsView.AvailedServices);
            ClearServicesData();
            LoadDisplayedServiceData();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            InitializeAccessRights();
        }

        private void RunBackgroundTasks()
        {
            _agingLoanTask.Execute();
            _delinquentLoanTask.Execute();
        }

        private void InitializeAccessRights()
        {
            // loan service rates
            _applianceLoanToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _easyLoanToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _emergencyLoanToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _equityLoanToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();

            // savings interest rate
            _timeDepositToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _savingsDepositToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();

            // configuration
            _loanSettingsToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _capitalShareMinimumAmountToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _timeDepositMinimumAmountToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _savingsDepositMaintainingBalanceToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _collegeInsurancePlanSettingsToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _pensionPlanSettingsToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _deathAidFundConfigurationToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _tulunganFundSettingsToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _refundRatioToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _gracePeriodToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();

            // reports
            _adjustmentsToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _collectionsToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _disbursementsToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _miscellaneousIncomeReportToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _cashFlowToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _agingLoansToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _agingLoansByDaysToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _agingLoansHistoryToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _delinquentAccountsToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _delinquentLoansHistoryToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _individualLedgersToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _memberBalanceSummariesToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _memberSummaryToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _membersInformationsToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _withdrawnMembersToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _memberPeriodicalBalanceSummariesToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();
            _noticesToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator() || _user.IsReceiver() || _user.IsDisburser();

            // mainteance
            _membersToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _pensionPlanAvailOptionsToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _relationsToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _usersToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();

            // services
            _cashRecieptsToolStripMenuItem.Enabled = _user.IsReceiver();
            _cashDisbursementToolStripMenuItem.Enabled = _user.IsDisburser();
            _adjustmentToolStripMenuItem.Enabled = _user.IsAdjuster();

            // miscellaneous income
            _miscellaneousIncomeCashReceiptToolStripMenuItem.Enabled = _user.IsReceiver();
            _miscellaneousIncomeCashDisbursementToolStripMenuItem.Enabled = _user.IsDisburser();
            _miscellaneousIncomeAdjustmentToolStripMenuItem.Enabled = _user.IsReceiver() || _user.IsDisburser() || _user.IsManager();

            // posting
            _netSurplusToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _dividendDistributionToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _dividendDepositorySelectionToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _patronageRefundToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _loanInterestRebateToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
            _savingsQuarterlyInterestComputationToolStripMenuItem.Enabled = _user.IsManager() || _user.IsAdministrator();
        }

        private void LoanServiceRatesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                var loanType = default(LoanType);
                if (e.ClickedItem == _applianceLoanToolStripMenuItem)
                    loanType = LoanType.ApplianceLoan;
                else if (e.ClickedItem == _easyLoanToolStripMenuItem)
                    loanType = LoanType.EasyLoan;
                else if (e.ClickedItem == _emergencyLoanToolStripMenuItem)
                    loanType = LoanType.EmergencyLoan;
                else if (e.ClickedItem == _equityLoanToolStripMenuItem)
                    loanType = LoanType.EquityLoan; // | LoanType.PensionLoan | LoanType.RegularLoan;
                else
                    throw new Exception(string.Format("Implementation for {0} not yet defined.", e.ClickedItem.Name));

                using (var view = new Loans.Factories.ServiceRateFormFactory().CreateForm(loanType))
                    view.ShowDialog(this);
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.Message);
            }
        }

        private void MaintenanceToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                RegistrationType rt;
                if (e.ClickedItem == _membersToolStripMenuItem)
                    rt = RegistrationType.Member;
                else if (e.ClickedItem == _pensionPlanAvailOptionsToolStripMenuItem)
                    rt = RegistrationType.PensionPlanAvailOption;
                else if (e.ClickedItem == _relationsToolStripMenuItem)
                    rt = RegistrationType.Relation;
                else if (e.ClickedItem == _usersToolStripMenuItem)
                    rt = RegistrationType.User;
                else
                    throw new Exception(string.Format("Implementation for {0} not yet defined.", e.ClickedItem.Name));

                using (var view = new Maintenance.Factories.ListingFormFactory().CreateForm(rt))
                    view.ShowDialog(this);
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.Message);
            }
        }

        private void ServicesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == _cashRecieptsToolStripMenuItem)
            {
                using (var view = new CashReceiptView(_memberInquiryDetailsView, _user.UserID))
                {
                    view.TransactionCommitted += new EventHandler(Service_TransactionCommitted);
                    view.ShowDialog(this);
                }
            }
            else if (e.ClickedItem == _cashDisbursementToolStripMenuItem)
            {
                using (var view = new CashDisbursementView(_memberInquiryDetailsView, _user.UserID))
                {
                    view.TransactionCommitted += new EventHandler(Service_TransactionCommitted);
                    view.ShowDialog(this);
                }
            }
            else if (e.ClickedItem == _adjustmentToolStripMenuItem)
            {
                using (var view = new AdjustmentView(_memberInquiryDetailsView, _user.UserID))
                {
                    view.TransactionCommitted += new EventHandler(Service_TransactionCommitted);
                    view.ShowDialog(this);
                }
            }
        }

        private void Service_TransactionCommitted(object sender, EventArgs e)
        {
            // refresh
            ClearServicesData();
            LoadDisplayedServiceData();
        }

        private void ConfigurationsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == _loanSettingsToolStripMenuItem)
            {
                using (var view = new LoanSettingsView())
                    view.ShowDialog(this);
            }
            else if (e.ClickedItem == _capitalShareMinimumAmountToolStripMenuItem)
            {
                using (var view = new CapitalShareMinimumAmountView())
                    view.ShowDialog(this);
            }
            else if (e.ClickedItem == _timeDepositMinimumAmountToolStripMenuItem)
            {
                using (var view = new TimeDepositMinimumAmountView())
                    view.ShowDialog(this);
            }
            else if (e.ClickedItem == _savingsDepositMaintainingBalanceToolStripMenuItem)
            {
                using (var view = new SavingsDepositMaintainingBalanceView())
                    view.ShowDialog(this);
            }
            else if (e.ClickedItem == _collegeInsurancePlanSettingsToolStripMenuItem)
            {
                using (var view = new CIPSettingsView())
                    view.ShowDialog(this);
            }
            else if (e.ClickedItem == _pensionPlanSettingsToolStripMenuItem)
            {
                using (var view = new PensionPlanSettingsView())
                    view.ShowDialog(this);
            }
            else if (e.ClickedItem == _deathAidFundConfigurationToolStripMenuItem)
            {
                using (var view = new DeathAidFundConfigurationView())
                    view.ShowDialog(this);
            }
            else if (e.ClickedItem == _tulunganFundSettingsToolStripMenuItem)
            {
                using (var view = new TulunganFundSettingsView())
                    view.ShowDialog(this);
            }
            else if (e.ClickedItem == _refundRatioToolStripMenuItem)
            {
                using (var view = new RefundRatioView())
                    view.ShowDialog(this);
            }
            else if (e.ClickedItem == _gracePeriodToolStripMenuItem)
            {
                using (var view = new GracePeriodView())
                    view.ShowDialog(this);
            }
        }

        private void SavingsInterestRatesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                SavingsType st;
                if (e.ClickedItem == _timeDepositToolStripMenuItem)
                    st = SavingsType.TimeDeposit;
                else if (e.ClickedItem == _savingsDepositToolStripMenuItem)
                    st = SavingsType.SavingsDeposit;
                else
                    throw new Exception(string.Format("Implementation for {0} not yet defined.", e.ClickedItem.Name));

                using (var view = new Savings.Factories.InterestRateFormFactory().CreateForm(st))
                    view.ShowDialog(this);
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.Message);
            }
        }

        private void TabControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDisplayedServiceData();
        }

        private void ReportsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem == _adjustmentsToolStripMenuItem)
                {
                    using (var view = new AdjustmentsView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _collectionsToolStripMenuItem)
                {
                    using (var view = new CollectionsView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _disbursementsToolStripMenuItem)
                {
                    using (var view = new DisbursementsView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _miscellaneousIncomeReportToolStripMenuItem)
                {
                    using (var view = new MiscellaneousIncomeReportView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _cashFlowToolStripMenuItem)
                {
                    using (var view = new CashFlowsView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _agingLoansToolStripMenuItem)
                {
                    using (var view = new AgingLoansReportView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _agingLoansByDaysToolStripMenuItem)
                {
                    using (var view = new AgingLoansByDaysReportView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _agingLoansHistoryToolStripMenuItem)
                {
                    using (var view = new AgingLoansHistoryView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _delinquentAccountsToolStripMenuItem)
                {
                    using (var view = new DelinquentAccountReportView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _delinquentLoansHistoryToolStripMenuItem)
                {
                    using (var view = new DelinquentLoansHistoryView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _individualLedgersToolStripMenuItem)
                {
                    //using (var view = new IndividualLedgerView())
                    //    view.ShowDialog(this);

                    using (var view = new IndividualLedgerRevisionView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _memberBalanceSummariesToolStripMenuItem)
                {
                    using (var view = new MemberBalanceSummariesView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _memberSummaryToolStripMenuItem)
                {
                    using (var view = new MemberSummaryReportView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _membersInformationsToolStripMenuItem)
                {
                    using (var view = new MembersInformationsReportView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _withdrawnMembersToolStripMenuItem)
                {
                    using (var view = new WithdrawnMembersReportView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _memberPeriodicalBalanceSummariesToolStripMenuItem)
                {
                    using (var view = new PeriodicalBalancesView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _noticesToolStripMenuItem)
                {
                    using (var view = new NoticeReportView())
                        view.ShowDialog(this);
                }

            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.ToString());
            }
        }

        private void PositngsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem == _netSurplusToolStripMenuItem)
                {
                    using (var view = new NetSurplusView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _dividendDistributionToolStripMenuItem)
                {
                    using (var view = new DividendDistributionView(_user.UserID))
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _dividendDepositorySelectionToolStripMenuItem)
                {
                    using (var view = new DividendDepositorySelectionView())
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _patronageRefundToolStripMenuItem)
                {
                    using (var view = new PatronageRefundView(_user.UserID))
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _loanInterestRebateToolStripMenuItem)
                {
                    using (var view = new InterestRebateView(_memberInquiryDetailsView, _user.UserID))
                    {
                        view.TransactionCommitted += new EventHandler(Service_TransactionCommitted);
                        view.ShowDialog(this);
                    }
                }
                else if (e.ClickedItem == _savingsQuarterlyInterestComputationToolStripMenuItem)
                {
                    using (var view = new QuarterlyInterestComputationView(_user.UserID))
                        view.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.ToString());
            }
        }

        private void MiscellaneousIncomeToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem == _miscellaneousIncomeCashReceiptToolStripMenuItem)
                {
                    using (var view = new MiscellaneousIncomeCashReceiptView(_user.UserID))
                        view.ShowDialog(this);
                }
                if (e.ClickedItem == _miscellaneousIncomeCashDisbursementToolStripMenuItem)
                {
                    using (var view = new MiscellaneousIncomeCashDisbursementView(_user.UserID))
                        view.ShowDialog(this);
                }
                else if (e.ClickedItem == _miscellaneousIncomeAdjustmentToolStripMenuItem)
                {
                    using (var view = new MiscellaneousIncomeAdjustmentView(_user.UserID))
                        view.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                _errorLogger.Log(ex.ToString());
            }
        }
    }
}