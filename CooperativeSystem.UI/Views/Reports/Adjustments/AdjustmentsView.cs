using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.UI.Views.Reports.Adjustments.DailyAdjustments;
using CooperativeSystem.UI.Views.Reports.Adjustments.MonthlyAdjustments;
using CooperativeSystem.UI.Views.Reports.Adjustments.YearlyAdjustments;

namespace CooperativeSystem.UI.Views.Reports.Adjustments
{
    public partial class AdjustmentsView : FormTemplate
    {
        public AdjustmentsView()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var date = _monthCalendar.SelectionStart; //dateTimePicker1.Value; //_monthCalendar.SelectionStart;
                if (_dailyAdjustmentRadioButton.Checked)
                {
                    using (var dcrv = new DailyAdjustmentReportView())
                    {
                        dcrv.Date = date;
                        dcrv.ShowDialog(this);
                    }
                }
                else if (_monthlyAdjustmentRadioButton.Checked)
                {
                    using (var mcrv = new MonthlyAdjustmentReportView())
                    {
                        mcrv.Date = date;
                        mcrv.ShowDialog(this);
                    }
                }
                else if (_yearlyAdjustmentRadioButton.Checked)
                {
                    using (var ycrv = new YearlyAdjustmentReportView())
                    {
                        ycrv.Date = date;
                        ycrv.ShowDialog(this);
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
