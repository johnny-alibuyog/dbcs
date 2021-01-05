using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Users;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.User
{
    public partial class ManagerApprovalView : FormTemplate, IManagerApprovalView
    {
        private bool _allowClose;
        private readonly ManagerApprovalPresenter _presenter;

        public ManagerApprovalView()
        {
            InitializeComponent();

            _allowClose = false;

            _presenter = new ManagerApprovalPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            // register controls to validate
            ControlValidator.RegisterControl(_userIDTextBox, InputType.Normal, true, "UserID", 20);
            ControlValidator.RegisterControl(_passwordTextBox, InputType.Normal, true, "Password", 25);
        }

        #region IManagerApprovalView

        public string UserID
        {
            get { return _userIDTextBox.Text; }
            set { _userIDTextBox.Text = value; }
        }

        public string Password
        {
            get { return _passwordTextBox.Text; }
            set { _passwordTextBox.Text = value; }
        }

        #endregion

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            _allowClose = _presenter.Execute();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _allowClose = true;
        }

        private void ManagerApprovalView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_allowClose;
        }
    }
}
