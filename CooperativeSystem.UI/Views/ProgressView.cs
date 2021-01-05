using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CooperativeSystem.UI.Views
{
    public partial class ProgressView : UI.Views.FormTemplate
    {
        private delegate void StringParameterDelegate(string Text);
        private delegate void StringParameterWithStatusDelegate(string Text);
        private delegate void SplashShowCloseDelegate();

        /// <summary>
        /// To ensure splash screen is closed using the API and not by keyboard or any other things
        /// </summary>
        private bool _closeProgressScreenFlag = false;

        public ProgressView()
        {
            InitializeComponent();

            _statusLabel.Parent = this._pictureBox;
            _statusLabel.BackColor = Color.Transparent;
            _statusLabel.ForeColor = Color.Green;
            _progressBar.Show();

        }

        /// <summary>
        /// Displays the ProgressScreen
        /// </summary>
        public void ShowProgressScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(ShowProgressScreen));
                return;
            }
            this.Show();
            Application.Run(this);
        }

        /// <summary>
        /// Closes the ProgressScreen
        /// </summary>
        public void CloseProgressScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(CloseProgressScreen));
                return;
            }
            _closeProgressScreenFlag = true;
            this.Close();
        }

        /// <summary>
        /// Update text in default green color of success message
        /// </summary>
        /// <param name="Text">Message</param>
        public void UdpateProgressText(string Text)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UdpateProgressText), new object[] { Text });
                return;
            }
            // Must be on the UI thread if we've got this far
            _statusLabel.ForeColor = Color.Green;
            _statusLabel.Text = Text;
        }

        /// <summary>
        /// Prevents the closing of form other than by calling the CloseProgressScreen function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_closeProgressScreenFlag == false)
                e.Cancel = true;
        }
    }
}
