using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Blazored.Modal;
using CommonUtil;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Model;

namespace BizHub.Components.Modals.Email_Send {
    public partial class Email_Send {

        #region Fields
        private BasePageController _controller = new BasePageController();
        private List<DisplayTag> _tags_To = new List<DisplayTag>();
        private List<DisplayTag> _tags_Cc = new List<DisplayTag>();
        private string _inputString_To;
        private string _inputString_Cc;
        private Email _email = new Email();
        #endregion(Fields)

        #region Constructor
        protected override void OnInitialized() {
            if (!string.IsNullOrEmpty(ContactEmail)) {
                Tags_To.Add(new DisplayTag() { Name = ContactEmail, TagId = 1 });
            }
        }
        #endregion(Constructor)

        #region Methods

        public void Save() {
            StringBuilder sb = new StringBuilder();
            foreach (DisplayTag oTag in Tags_To) {
                try {
                    MailAddress oAddress = new MailAddress(oTag.Name);
                    Email.To.Add(oAddress);
                } catch (Exception ex) {
                    sb.Append(oTag.Name + " <br>");
                }
            }

            foreach (DisplayTag oTag in Tags_Cc) {
                try {
                    MailAddress oAddress = new MailAddress(oTag.Name);
                    Email.Cc.Add(oAddress);
                } catch (Exception ex) {
                    sb.Append(oTag.Name + " < br>");
                }
            }
            if (sb.Length > 0) {
                sb.Insert(0, "The following Email Addresses are invalid: <br>");
                Controller.ShowPopupDialog(sb.ToString(), "Error");
            } else {
                Controller.ShowPopupDialog("Email Sent!", "Success");
            }
            //BlazoredModal.Close();
        }

        public void Cancel() {
            BlazoredModal.Cancel();
        }

        #region Blur/KeyPress
        public void AddressInputBlur(Int64 tiTagId) {
            AddTag(tiTagId);
        }

        public void AddressInputKeyUp(KeyboardEventArgs e, Int64 tiTagId) {
            if (e.Key.Equals("Enter") || e.Key.Equals("Tab")) {
                AddTag(tiTagId);
            }
        }

        public void SetInputString_To(string tsValue) {
            _inputString_To = tsValue;
            if (_inputString_To.EndsWith(",") || _inputString_To.EndsWith(" ")) {
                _inputString_To.Replace(",", "");
                AddTag(1);
            }
        }

        public void SetInputString_Cc(string tsValue) {
            _inputString_Cc = tsValue;
            if (_inputString_Cc.EndsWith(",") || _inputString_Cc.EndsWith(" ")) {
                _inputString_Cc.Replace(",", "");
                AddTag(2);
            }
        }
        #endregion (Blur/KeyPress)

        #region Tag Management
        private void AddTag(Int64 tiListId) {
            switch (tiListId) {
                case 1:
                    if (!string.IsNullOrEmpty(InputString_To)) {
                        Tags_To.Add(new DisplayTag() { Name = InputString_To.Replace(",", ""), TagId = 1 });
                        InputString_To = string.Empty;
                    }
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(InputString_Cc)) {
                        Tags_Cc.Add(new DisplayTag() { Name = InputString_Cc.Replace(",", ""), TagId = 2 });
                        InputString_Cc = string.Empty;
                    }
                    break;
                default:
                    break;
            }
            StateHasChanged();
        }

        public void RemoveTag(DisplayTag toTag) {
            switch (toTag.TagId) {
                case 1:
                    Tags_To.Remove(toTag);
                    break;
                case 2:
                    Tags_Cc.Remove(toTag);
                    break;
                default:
                    break;
            }
            StateHasChanged();
        }
        #endregion (Tag Management)

        #endregion(Methods)

        #region Properties
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public Email Email { get => _email; set => _email = value; }
        [Parameter] public string? ContactEmail { get; set; }

        //public string InputString_To { get; set; }
        public string InputString_To { get => _inputString_To; set => SetInputString_To(value); }
        public string InputString_Cc { get => _inputString_Cc; set => SetInputString_Cc(value); }
        //public string InputString_Cc { get; set; }

        //DisplayTag Id value of 1
        public List<DisplayTag> Tags_To { get => _tags_To; set => _tags_To = value; }

        //DisplayTag Id value of 2
        public List<DisplayTag> Tags_Cc { get => _tags_Cc; set => _tags_Cc = value; }
        public BasePageController Controller { get => _controller; set => _controller = value; }
        #endregion(Properties)

    }
}