using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.UI.Utilities;

namespace CooperativeSystem.UI.Views
{
    public partial class PostingView : FormTemplate, IPostingView
    {
        private PostingPresenter _presenter;

        #region Routine Helpers

        private void OnPosting(EventArgs e)
        {
            RaisePostingEvent(this, e);
        }

        private void RaisePostingEvent(object sender, EventArgs e)
        {
            if (Posting != null)
                Posting.Invoke(sender, e);
        }

        #endregion

        #region IPostingView Members

        public event EventHandler Posting;

        public string Sequence
        {
            get { return _sequenceTextBox.Text; }
            set { _sequenceTextBox.Text = value; }
        }

        public string VoucherNumber
        {
            get { return _voucherNumberTextBox.Text; }
            set { _voucherNumberTextBox.Text = value; }
        }

        #endregion

        public PostingView()
        {
            InitializeComponent();

            _presenter = new PostingPresenter(this);
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }

        private void GenerateVoucherButton_Click(object sender, EventArgs e)
        {
            if (_presenter.GenerateVoucherNumber())
                _restartVoucherCheckBox.Checked = false;
        }

        private void RestartVoucherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var restart = ((CheckBox)sender).Checked;

            _generateVoucherButton.Enabled = restart;
            _sequenceTextBox.Enabled = restart;
            _sequenceTextBox.Text = string.Empty;
            _sequenceTextBox.Select();

        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (AskConfirmation(this, "Are you sure you want to post?") != DialogResult.Yes)
                    return;

                OnPosting(new EventArgs());
                Close();
            }
            catch (Exception ex)
            {
                NotifyError(this, ex.Message);
            }
        }
    }
}
