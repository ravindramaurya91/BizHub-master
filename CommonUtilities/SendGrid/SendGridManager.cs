using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace CommonUtil {
    public class SendGridManager {
        public static string SEND_GRID_API_KEY_CWS    = "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";
        public static string SEND_GRID_API_KEY_TWORLD = "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";
        public static string SEND_GRID_API_KEY_BIZHUB = "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";

        public async Task SendMailTest() {
            try {
                //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
                var apiKey = SEND_GRID_API_KEY_BIZHUB;
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("lgrover@clearwavesoftware.com", "Lee Grover");
                var subject = "Sending with SendGrid is Fun";
                var to = new EmailAddress("lgrover@tworld.com", "Lee Grover");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
