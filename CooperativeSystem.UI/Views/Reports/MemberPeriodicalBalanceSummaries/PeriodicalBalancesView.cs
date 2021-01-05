using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Models;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Reports.MemberPeriodicalBalanceSummaries;
using CooperativeSystem.UI.Views.Reports.MemberPeriodicalBalanceSummaries.QuarterlyBalances;
using CooperativeSystem.UI.Views.Reports.MemberPeriodicalBalanceSummaries.YearlyBalances;
using CooperativeSystem.UI.Views.Reports.MemberPeriodicalBalanceSummaries.MonthlyBalances;

namespace CooperativeSystem.UI.Views.Reports.MemberPeriodicalBalanceSummaries
{
    public partial class PeriodicalBalancesView : FormTemplate, IPeriodicalBalancesView
    {
        private PeriodicalBalancePresenter _presenter;

        #region IPeriodicalBalancesView Members

        public DateTime MonthlyBalanceDate
        {
            get { return _monthlyBalanceDateTimePicker.Value; }
            set { _monthlyBalanceDateTimePicker.Value = value; }
        }

        public int QuarterlyBalanceYear
        {
            get { return Convert.ToInt32(_quarterlyBalanceYearNumericUpDown.Value); }
            set { _quarterlyBalanceYearNumericUpDown.Value = value; }
        }

        public Quarter QuarterlyBalanceQuarter
        {
            get { return _quarterlyBalanceQuarterComboBox.SelectedItem as Quarter; }
            set { _quarterlyBalanceQuarterComboBox.SelectedItem = value; }
        }

        public int YearlyBalanceYear
        {
            get { return Convert.ToInt32(_yearlyBalanceYearNumericUpDown.Value); }
            set { _yearlyBalanceYearNumericUpDown.Value = value; }
        }

        public void PopulateQuarters(IList<Quarter> quarters)
        {
            _quarterlyBalanceQuarterComboBox.DataSource = quarters;
            _quarterlyBalanceQuarterComboBox.ValueMember = "QuarterID";
            _quarterlyBalanceQuarterComboBox.DisplayMember = "Name";
        }

        #endregion

        public PeriodicalBalancesView()
        {
            InitializeComponent();

            _presenter = new PeriodicalBalancePresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void PeriodicalBalancesView_Load(object sender, EventArgs e)
        {
            _presenter.InitializeView();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (_tabControl.SelectedTab == _monthlyBalancesTabPage)
            {
                using (var view = new MonthlyBalanceReportView())
                {
                    view.Date = MonthlyBalanceDate;
                    view.ShowDialog(this);
                }
            }
            else if (_tabControl.SelectedTab == _quarterlyBalancesTabPage)
            {
                using (var view = new QuarterlyBalanceReportView())
                {
                    view.Year = QuarterlyBalanceYear;
                    view.Quarter = QuarterlyBalanceQuarter;
                    view.ShowDialog(this);
                }
            }
            else if (_tabControl.SelectedTab == _yearlyBalancesTabPage)
            {
                using (var view = new YearlyBalanceReportView())
                {
                    view.Year = YearlyBalanceYear;
                    view.ShowDialog(this);
                }
            }
        }
    }
}
