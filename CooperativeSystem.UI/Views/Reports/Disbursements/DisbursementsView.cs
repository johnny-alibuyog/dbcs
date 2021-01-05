using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.UI.Views.Reports.Disbursements.DailyDisbursements;
using CooperativeSystem.UI.Views.Reports.Disbursements.MonthlyDisbursements;
using CooperativeSystem.UI.Views.Reports.Disbursements.YearlyDisbursements;

namespace CooperativeSystem.UI.Views.Reports.Disbursements
{
    public partial class DisbursementsView : FormTemplate
    {
        public DisbursementsView()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var date = _monthCalendar.SelectionStart;
                if (_dailyDisbursementRadioButton.Checked)
                {
                    using (var ddrv = new DailyDisbursementReportView())
                    {
                        ddrv.Date = date;
                        ddrv.ShowDialog(this);
                    }
                }
                else if (_monthlyDisbursementRadioButton.Checked)
                { 
                    using (var mdrv = new MonthlyDisbursementReportView())
                    {
                        mdrv.Date = date;
                        mdrv.ShowDialog(this);
                    }
                }
                else if (_yearlyDisbursementRadioButton.Checked)
                {
                    using (var ydrv = new YearlyDisbursementReportView())
                    {
                        ydrv.Date = date;
                        ydrv.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }
    }
}
