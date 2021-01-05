using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.UI.Views.Reports.CashFlows.MonthlyCashFlows;
using CooperativeSystem.UI.Views.Reports.CashFlows.YearlyCashFlows;

namespace CooperativeSystem.UI.Views.Reports.CashFlows
{
    public partial class CashFlowsView : FormTemplate
    {
        public CashFlowsView()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var date = _monthCalendar.SelectionStart;
                if (_monthlyCashFlowRadioButton.Checked)
                {
                    using (var mcfrv = new MonthlyCashFlowReportView())
                    {
                        mcfrv.Date = date;
                        mcfrv.ShowDialog(this);
                    }
                }
                else if (_yearlyCashFlowRadioButton.Checked)
                {
                    using (var ycfrv = new YearlyCashFlowReportView())
                    {
                        ycfrv.Date = date;
                        ycfrv.ShowDialog(this);
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
