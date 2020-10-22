using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SendGrid.Helpers.Mail;
using System.Configuration;
using System.Threading.Tasks;
using SendGrid;

namespace CommonUtil
{
    class EmailClient
    {

        #region Fields
        private string sendGridAPIKey = ConfigurationManager.AppSettings["SendGridAPIKey"];
        private List<EmailAddress> _bcc = new List<EmailAddress>();
        private List<EmailAddress> _cc = new List<EmailAddress>();
        private List<EmailAddress> _to = new List<EmailAddress>();
        private List<EmailAddress> _replyTo = new List<EmailAddress>();
        private List<Attachment> _attachments = new List<Attachment>();
        #endregion (Fields)

        #region Constructor
        public EmailClient()
        {

        }

        //Send Email
        public async Task SendMail()
        {
            var client = new SendGridClient(sendGridAPIKey);
            var msg = new SendGridMessage();

            //Set Subject
            msg.SetSubject(Subject);

            //Set Text Message
            msg.PlainTextContent = TextMessage;

            //Set Html Message
            msg.HtmlContent = HtmlMessage;

            //Set From Address
            msg.SetFrom(From);

            //Add List of To Mail Address
            msg.AddTos(To);

            //Add List of Cc Mail Address
            if (Cc.Count > 0)
                msg.AddCcs(Cc);

            //Add List of Bcc Mail Address
            if (Bcc.Count > 0)
                msg.AddBccs(Bcc);

            //Add List of Attachments
            if (Attachments.Count > 0)
                msg.AddAttachments(Attachments);

            //Send Mail
            var response = await client.SendEmailAsync(msg);
        }

        #endregion

        #region Properties
        public string TextMessage { get; set; }
        public string HtmlMessage { get; set; }
        public string Subject { get; set; }
        public List<EmailAddress> Bcc { get => _bcc; set => _bcc = value; }
        public List<EmailAddress> Cc { get => _cc; set => _cc = value; }
        public List<EmailAddress> To { get => _to; set => _to = value; }
        public List<EmailAddress> ReplyTo { get => _replyTo; set => _replyTo = value; }
        public EmailAddress From { get; set; }
        public Dictionary<string, MemoryStream> StreamedAttachments { get; set; }
        public List<Attachment> Attachments { get => _attachments; set => _attachments = value; }
        #endregion (Properties)
    }
}
