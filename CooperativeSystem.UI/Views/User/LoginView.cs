using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Users;
using CooperativeSystem.UI.Views.Utilities.ControlValidation;

namespace CooperativeSystem.UI.Views.User
{
    public partial class LoginView : FormTemplate, ILoginView
    {
        private LoginPresenter _presenter;
        private bool _allowClose;

        public LoginView()
        {
            InitializeComponent();

            _allowClose = false;

            _presenter = new LoginPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);

            // register controls to validate
            ControlValidator.RegisterControl(_userIDTextBox, InputType.Normal, true, "UserID", 20);
            ControlValidator.RegisterControl(_passwordTextBox, InputType.Normal, true, "Password", 25);
            ControlValidator.RegisterControl(_newPasswordTextBox, InputType.Normal, false, "New Password", 25);
            ControlValidator.RegisterControl(_newPasswordConfirmationTextBox, InputType.Normal, false, "New Password Confirmation", 25);

            ShowChangePasswordPane(false);
        }

        #region ILoginView Members

        public string UserID
        {
            get { return _userIDTextBox.Text; }
        }

        public string Password
        {
            get { return _passwordTextBox.Text; }
        }

        public string NewPassword
        {
            get { return _newPasswordTextBox.Text; }
        }

        public string NewPasswordConfirmation
        {
            get { return _newPasswordConfirmationTextBox.Text; }
        }

        public Service.Models.User GetUser()
        {
            return _presenter.GetUser();
        }

        public Service.Models.Application GetApplication()
        {
            return _presenter.GetApplication();
        }

        #endregion

        #region Routine Helpers

        private void ShowChangePasswordPane(bool show)
        {
            if (show)
            {
                if (!Controls.Contains(_changePasswordGroupBox))
                    Controls.Add(_changePasswordGroupBox);

                if (!Controls.Contains(_changePasswordButton))
                    Controls.Add(_changePasswordButton);

                _loginButton.Enabled = false;
                AcceptButton = _changePasswordButton;

                Size = new Size(Size.Width, 290);
            }
            else
            {
                if (Controls.Contains(_changePasswordGroupBox))
                    Controls.Remove(_changePasswordGroupBox);

                if (Controls.Contains(_changePasswordButton))
                    Controls.Remove(_changePasswordButton);

                _loginButton.Enabled = true;
                AcceptButton = _loginButton;

                Size = new Size(Size.Width, 173);
            }
        }

        private void ShowSpashScreen()
        {
            //var sf = new SplashScreenView();

            //Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
            //splashthread.IsBackground = true;
            //splashthread.Start();

            //SplashScreen.UdpateStatusText("Loading Items!!!");
            //Thread.Sleep(1000);

            //SplashScreen.UdpateStatusTextWithStatus("Success Message", TypeOfMessage.Success);
            //Thread.Sleep(1000);

            //SplashScreen.UdpateStatusTextWithStatus("Warning Message", TypeOfMessage.Warning);
            //Thread.Sleep(1000);

            //SplashScreen.UdpateStatusTextWithStatus("Error Message", TypeOfMessage.Error);
            //Thread.Sleep(1000);
            
            //SplashScreen.UdpateStatusText("Testing Default Message Color");
            //Thread.Sleep(1000);
            
            //SplashScreen.UdpateStatusText("Items Loaded..");
            //Thread.Sleep(500);

            //SplashScreen.CloseSplashScreen();

            //this.Hide();

            //SplashScreenProvider.ShowSplashScreen();

            //SplashScreenProvider.UdpateStatusText("Initializing. Please wait... ");
            //Thread.Sleep(1000); // delay

            //SplashScreenProvider.UdpateStatusText("Loading lookups... ");
            //Thread.Sleep(1000); // delay

            //SplashScreenProvider.CloseSplashScreen();

            //this.Show();


            this.Hide();
            bool done = false;
            ThreadPool.QueueUserWorkItem((x) =>
            {
                using (var splashScreen = new SplashScreenView())
                {
                    splashScreen.Show();
                    while (!done)
                        Application.DoEvents();
                    splashScreen.Close();
                }
            });

            Thread.Sleep(5000); // delay
            done = true;
            Show(); 
        }

        #endregion

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (ControlValidator.Validate())
                _allowClose = _presenter.Login();

            if (_allowClose)
                ShowSpashScreen();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _allowClose = true;
        }

        private void LoginView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_allowClose;
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (ControlValidator.Validate())
            {
                var confirm = AskConfirmation(this, "Do you want to change password?");
                if (confirm == DialogResult.Yes)
                {
                    if (_presenter.ChagePassword())
                    {
                        ShowChangePasswordPane(false);
                        _passwordTextBox.Text = string.Empty;
                        _passwordTextBox.Select();
                    }
                }
            }
        }

        private void ChangePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ShowChangePasswordPane(_changePasswordCheckBox.Checked);
        }

    }
}
