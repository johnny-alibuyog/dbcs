using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CooperativeSystem.UI.Views.User
{
    public partial class SplashScreenView : CooperativeSystem.UI.Views.FormTemplate
    {
        private delegate void StringParameterDelegate(string Text);
        private delegate void StringParameterWithStatusDelegate(string Text, TypeOfMessage tom);
        private delegate void SplashShowCloseDelegate();

        /// <summary>
        /// To ensure splash screen is closed using the API and not by keyboard or any other things
        /// </summary>
        private bool _closeSplashScreenFlag = false;

        public SplashScreenView()
        {
            InitializeComponent();

            _statusLabel.Parent = this._pictureBox;
            _statusLabel.BackColor = Color.Transparent;
            _statusLabel.ForeColor = Color.Green;
            _progressBar.Show();
        }

        /// <summary>
        /// Displays the splashscreen
        /// </summary>
        public void ShowSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(ShowSplashScreen));
                return;
            }
            this.ShowDialog();
            //Application.Run(this);
        }

        /// <summary>
        /// Closes the SplashScreen
        /// </summary>
        public void CloseSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(CloseSplashScreen));
                return;
            }
            _closeSplashScreenFlag = true;
            this.Close();
        }

        /// <summary>
        /// Update text in default green color of success message
        /// </summary>
        /// <param name="Text">Message</param>
        public void UdpateStatusText(string Text)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UdpateStatusText), new object[] { Text });
                return;
            }
            // Must be on the UI thread if we've got this far
            _statusLabel.ForeColor = Color.Green;
            _statusLabel.Text = Text;
        }

        /// <summary>
        /// Update text with message color defined as green/yellow/red/ for success/warning/failure
        /// </summary>
        /// <param name="Text">Message</param>
        /// <param name="tom">Type of Message</param>
        public void UdpateStatusTextWithStatus(string Text, TypeOfMessage tom)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterWithStatusDelegate(UdpateStatusTextWithStatus), new object[] { Text, tom });
                return;
            }
            // Must be on the UI thread if we've got this far
            switch (tom)
            {
                case TypeOfMessage.Error:
                    _statusLabel.ForeColor = Color.Red;
                    break;
                case TypeOfMessage.Warning:
                    _statusLabel.ForeColor = Color.Yellow;
                    break;
                case TypeOfMessage.Success:
                    _statusLabel.ForeColor = Color.Green;
                    break;
            }
            _statusLabel.Text = Text;

        }

        /// <summary>
        /// Prevents the closing of form other than by calling the CloseSplashScreen function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashScreenView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_closeSplashScreenFlag == false)
                e.Cancel = true;
        }
    }
}
