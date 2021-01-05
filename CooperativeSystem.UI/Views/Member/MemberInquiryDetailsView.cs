using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CooperativeSystem.Service.Presenters;
using CooperativeSystem.Service.Presenters.Lookups.Services;
using CooperativeSystem.Service.Presenters.Members;
using CooperativeSystem.UI.Views.Member;


namespace CooperativeSystem.UI.Views.Member
{
    public delegate void MemberInquiryChangeEventHandler(object sender, MemberInquiryEventArgs e);
    public delegate void MemberInquiryClearEventHandler(object sender, EventArgs e);

    public partial class MemberInquiryDetailsView : UserControlTemplate, IMemberInquiryDetailsView
    {
        private MemberInquiryDetailsPresenter _presenter;

        public event MemberInquiryChangeEventHandler MemberInquiryChanged;
        public event MemberInquiryClearEventHandler MemberInquiryCleared;

        #region IMemberInquiryDetailsView Members

        public long MemberID { get; set; }

        public string AccountNumber
        {
            get { return _accountNumberLabel.Text; }
            set { _accountNumberLabel.Text = value; }
        }

        public string FullName 
        { 
            get { return _memberNameLabel.Text; } 
            set { _memberNameLabel.Text = value; } 
        }

        public string MembershipCategoryName 
        {
            get { return _membershipCategoryLabel.Text; }
            set { _membershipCategoryLabel.Text = value; } 
        }

        public string DateApplied 
        {
            get { return _applicationDateLabel.Text; }
            set { _applicationDateLabel.Text = value; } 
        }

        public string DateOfBirth 
        { 
            get { return _dateOfBirthLabel.Text; } 
            set { _dateOfBirthLabel.Text = value; } 
        }

        public string PlaceOfBirth 
        {
            get { return _placeOfBirthLabel.Text; }
            set { _placeOfBirthLabel.Text = value; } 
        }

        public string Address 
        { 
            get { return _addressLabel.Text; } 
            set { _addressLabel.Text = value; } 
        }

        public string HomePhone 
        { 
            get { return _homePhoneLabel.Text; } 
            set { _homePhoneLabel.Text = value; } 
        }

        public string MobilePhone 
        { 
            get { return _mobilePhoneLabel.Text; } 
            set { _mobilePhoneLabel.Text = value; } 
        }

        public string MaritalStatusName 
        { 
            get { return _maritalStatusNameLabel.Text; } 
            set { _maritalStatusNameLabel.Text = value; } 
        }
        
        public string SexTypeName 
        { 
            get { return _sexTypeNameLabel.Text; } 
            set { _sexTypeNameLabel.Text = value; } 
        }

        public byte[] Picture
        {
            get
            {
                if (_picturePictureBox.Image == null)
                    return null;

                // save image from PictureBox into MemoryStream object
                var stream = new MemoryStream();
                _picturePictureBox.Image.Save(stream, ImageFormat.Jpeg);
                var blob = stream.ToArray();

                return blob;
            }
            set
            {
                if (value != null)
                {
                    var stream = new MemoryStream(value);
                    _picturePictureBox.Image = Image.FromStream(stream);
                }
                else
                {
                    _picturePictureBox.Image = null;
                }
            }
        }

        public byte[] Signature
        {
            get
            {
                if (_signaturePictureBox.Image == null)
                    return null;

                // save image from PictureBox into MemoryStream object
                var memoryStream = new MemoryStream();
                _signaturePictureBox.Image.Save(memoryStream, ImageFormat.Jpeg);
                var blob = memoryStream.ToArray();

                return blob;
            }
            set
            {
                if (value != null)
                {
                    var memoryStream = new MemoryStream(value);
                    _signaturePictureBox.Image = Image.FromStream(memoryStream);
                }
                else
                {
                    _signaturePictureBox.Image = null;
                }
            }
        }



        public AvailedServicesAdapter AvailedServices { get; set; }

        #endregion

        #region Routine Helpers

        protected virtual void OnMemberInquiryCleared(EventArgs e)
        {
            RaiseMemberInquiryChangeEvent(this, e);
        }

        private void RaiseMemberInquiryChangeEvent(object sender, EventArgs e)
        {
            if (MemberInquiryCleared != null)
                MemberInquiryCleared.Invoke(sender, e);
        }

        protected virtual void OnMemberInquiryChanged(MemberInquiryEventArgs e)
        {
            RaiseMemberInquiryChangedEvent(this, e);
        }

        private void RaiseMemberInquiryChangedEvent(object sender, MemberInquiryEventArgs e)
        {
            if (MemberInquiryChanged != null)
                MemberInquiryChanged.Invoke(sender, e);
        }

        #endregion

        public MemberInquiryDetailsView()
        {
            InitializeComponent();

            _presenter = new MemberInquiryDetailsPresenter(this);
        }

        private void ListingView_MemberSelected(object sender, long memberID)
        {
            var result = _presenter.SearchMember(memberID);
            if (result)
                OnMemberInquiryChanged(new MemberInquiryEventArgs(memberID));
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var milv = new MemberInquiryListingView();
            milv.MemberSelected += new MemberSelectedEventHandler(ListingView_MemberSelected);
            milv.ShowDialog(ParentForm);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _presenter.Clear();
            OnMemberInquiryCleared(e);
        }

        private void MemberInquiryDetailsView_ParentChanged(object sender, EventArgs e)
        {
            // use this event just for initialization
            _presenter.Error += new ErrorHandler(NotifyError);
            _presenter.Success += new SuccessHandler(NotifyInformation);
        }
    }
}