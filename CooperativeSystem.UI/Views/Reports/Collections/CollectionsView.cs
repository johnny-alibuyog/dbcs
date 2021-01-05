using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.UI.Views.Reports.Collections.DailyCollections;
using CooperativeSystem.UI.Views.Reports.Collections.MonthlyCollections;
using CooperativeSystem.UI.Views.Reports.Collections.YearlyCollections;

namespace CooperativeSystem.UI.Views.Reports.Collections
{
    public partial class CollectionsView : FormTemplate
    {
        public CollectionsView()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var date = _monthCalendar.SelectionStart; //dateTimePicker1.Value; //_monthCalendar.SelectionStart;
                if (_dailyCollectionRadioButton.Checked)
                {
                    using (var dcrv = new DailyCollectionReportView())
                    {
                        dcrv.Date = date;
                        dcrv.ShowDialog(this);
                    }
                }
                else if (_monthlyCollectionRadioButton.Checked)
                {
                    using (var mcrv = new MonthlyCollectionReportView())
                    {
                        mcrv.Date = date;
                        mcrv.ShowDialog(this);
                    }
                }
                else if (_yearlyCollectionRadioButton.Checked)
                {
                    using (var ycrv = new YearlyCollectionReportView())
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
