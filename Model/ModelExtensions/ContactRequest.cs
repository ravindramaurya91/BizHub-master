using CommonUtil;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Model {
    public partial class ContactRequest {

        private string GenerateGenericContactRequestSubjectLine() {
            return "A Buyer has requested contact";
        }

        private string GenerateListingSpecificContactRequestSubjectLine(ListingDTO toListingDTO) {
            return "A Buyer has requested contact regarding ListingID: " + toListingDTO.Oid;
        }

        private string PrependListingInfoToMessage(ListingDTO toListingDTO) {
            StringBuilder sb = new StringBuilder();
            // TODO See if we can make the listing id a clickable link that takes broker straight to that detail page, or to his management page?
            sb.Append("The following request for contact has been made regarding ListingID: " + toListingDTO.Oid + "<br>");
            sb.Append(Message);
            return sb.ToString();
        }

        public bool SendRequest(ListingDTO toListingDTO = null) {
            bool bReturn;

            try {
                Email oEmail = new Email();
                oEmail.AddTo(new MailAddress(EntityEmail_To));
                oEmail.From = new MailAddress(EntityEmail_From);
                oEmail.HtmlMessage = (toListingDTO != null) ? PrependListingInfoToMessage(toListingDTO) : Message;
                oEmail.Subject = (toListingDTO != null) ? GenerateListingSpecificContactRequestSubjectLine(toListingDTO) : GenerateGenericContactRequestSubjectLine();
                // TODO Add requesting buyers information to the bottom of the message, does not matter if listing was part of above message or now
                // Should be a generic looking set of buyer informaiton

                // TODO Append the preferred method of contact along with the buyers information
                
                oEmail.SendEmail();
                

                // TODO If the 401 box was checked, send referral info to outside party
                ContactDate = DateTime.UtcNow;
                Save();
                
                bReturn = true;
            } catch (Exception ex) {
                bReturn = false;
            }

            return bReturn;
        }
    }
}
