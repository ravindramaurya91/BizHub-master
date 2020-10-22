using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Xml.Schema;
using System.Net.Mime;

namespace CommonUtil {
    public class Email {

        #region Fields
        private List<MailAddress> _bcc = new List<MailAddress>();
        private List<MailAddress> _cc = new List<MailAddress>();
        private List<MailAddress> _to = new List<MailAddress>();
        private List<MailAddress> _replyTo = new List<MailAddress>();
        private List<Attachment> _attachments = new List<Attachment>();
        #endregion (Fields)

        #region Constructor
        public Email() {

        }
        public Email(MailAddress toFrom, List<MailAddress> toTo, string tsSubject, string tsHtml, string tsText) {
            From = toFrom;
            To = toTo;
            Subject = tsSubject;
            HtmlMessage = tsHtml;
            TextMessage = tsText;
        }

        #endregion (Constructor)

        #region Methods

        #region Attachments
        // Attachments
        public void AddAttachment(string tsFilePath) {
            AddAttachment(new Attachment(tsFilePath));
        }
        public void AddAttachment(Stream contentStream, ContentType contentType) {
            AddAttachment(new Attachment(contentStream, contentType));
        }
        public void AddAttachment(Stream contentStream, string name) {
            AddAttachment(new Attachment(contentStream, name));
        }
        public void AddAttachment(string fileName, ContentType contentType) {
            AddAttachment(new Attachment(fileName, contentType));
        }
        public void AddAttachment(string fileName, string mediaType) {
            AddAttachment(new Attachment(fileName, mediaType));
        }
        public void AddAttachment(Stream contentStream, string name, string mediaType) {
            AddAttachment(new Attachment(contentStream, name, mediaType));
        }
        public void AddAttachment(Attachment toAttachment) {
            Attachments.Add(toAttachment);
        }
        #endregion (Attachments)

        // Bcc
        public void AddBcc(string tsAddress) { AddBcc(new MailAddress(tsAddress)); }
        public void AddBcc(string tsAddress, string tsDisplayName) { AddBcc(new MailAddress(tsAddress, tsDisplayName)); }
        public void AddBcc(MailAddress toAddress) {
            Bcc.Add(toAddress);
        }
        // Cc
        public void AddCc(string tsAddress) { AddCc(new MailAddress(tsAddress)); }
        public void AddCc(string tsAddress, string tsDisplayName) { AddCc(new MailAddress(tsAddress, tsDisplayName)); }
        public void AddCc(MailAddress toAddress) {
            Cc.Add(toAddress);
        }
        // To
        public void AddTo(string tsAddress) { AddTo(new MailAddress(tsAddress)); }
        public void AddTo(string tsAddress, string tsDisplayName) { AddTo(new MailAddress(tsAddress, tsDisplayName)); }
        public void AddTo(MailAddress toAddress) {
            To.Add(toAddress);
        }
        
        //Send
        public void SendEmail() {
            Debug.WriteLine($"email sent from {From.DisplayName} subject = {Subject}");
        }

        public void ResetTo(List<string> toNewList) {
            To.Clear();
            Cc.AddRange(ConvetToMicrosoftMailAddress(toNewList));
        }
        public void ResetCC(List<string> toNewList) {
            Cc.Clear();
            Cc.AddRange(ConvetToMicrosoftMailAddress(toNewList));
        }
        public void ResetBCC(List<string> toNewList) {
            Bcc.Clear();
            Bcc.AddRange(ConvetToMicrosoftMailAddress(toNewList));
        }

        private List<MailAddress> ConvetToMicrosoftMailAddress(List<string> toNewList) {
            List<MailAddress> oReturn = new List<MailAddress>();

            return oReturn;
        }
        #endregion (Methods)

        #region Properties
        public string TextMessage { get; set; }
        public string HtmlMessage { get; set; }
        public string Subject { get; set; }
        public List<MailAddress> Bcc { get=> _bcc; set=> _bcc = value; }
        public List<MailAddress> Cc { get => _cc; set => _cc = value; }
        public List<MailAddress> To { get => _to; set => _to = value; }
        public List<MailAddress> ReplyTo { get => _replyTo; set => _replyTo = value; }
        public MailAddress From { get; set; }
        public Dictionary<string, MemoryStream> StreamedAttachments { get; set; }
        public List<Attachment> Attachments { get => _attachments; set => _attachments = value; }
        #endregion (Properties)
    }

}
