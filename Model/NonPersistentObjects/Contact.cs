using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Model {
    public class Contact {

        #region Methods

        public static Contact GetContactByEntityOid(Int64 tiEntityOid) {
            Contact oReturn = null;
            oReturn = SQL.GetContactByEntityOid(tiEntityOid, true);
            return oReturn;
        }

        public static List<Contact> GetMyContacts() {
            List<Contact> oReturnList = new List<Contact>();
            oReturnList = SQL.GetContactsByEntityOid_From(SessionMgr.Instance.User.EntityOid);
            return oReturnList;
        }

        public static void AddContact(Contact toContact) {
            bool IsUnique = IsContactUnique(toContact);
            if (IsUnique) {
                SaveNewContact(toContact);
            } else {
                Contact oContact = SQL.GetContactByContactDetails(toContact, false);
                Entity2EntityMap_Contact oNewMap = new Entity2EntityMap_Contact() { EntityOid_From = SessionMgr.Instance.User.EntityOid, EntityOid_To = oContact.Oid };
                oNewMap.Save();
            }
        }

        private static void SaveNewContact(Contact toContact) {
            DateTime oCurrentTime = DateTime.UtcNow;
            Entity oNewContact = new Entity() { EntityOid_Master = 1, Avatar = toContact.Avatar, FirstName = toContact.FirstName, LastName = toContact.LastName, DisplayName = toContact.FirstName + ' ' + toContact.LastName, Email = toContact.Email, Phone = toContact.Phone, City = "", State = "", Zip = "", IsActive = false, CreatedBy = SessionMgr.Instance.User.DisplayName, CreatedOn = oCurrentTime, StartDate = oCurrentTime };
            oNewContact.Save();
            Entity2EntityMap_Contact oNewMap = new Entity2EntityMap_Contact() { EntityOid_From = SessionMgr.Instance.User.EntityOid, EntityOid_To = oNewContact.Oid };
            oNewMap.Save();
        }

        private static bool IsContactUnique(Contact toContact) {
            bool oReturn = false;
            Contact oContact = SQL.GetContactByContactDetails(toContact, false);
            if(oContact == null) {
                oReturn = true;
            } else {
                oReturn = false;
            }
            return oReturn;
        }

        public static void DeleteContact(Contact toContact) {
            Entity2EntityMap_Contact oDeletableContactMap = SQL.GetEntity2EntityMap_ContactByEntityOidAndContactOid(SessionMgr.Instance.User.EntityOid, toContact.Oid);
            oDeletableContactMap.Delete();
        }

        #endregion (Methods)


        #region Properties

        [Parameter] public Int64 Oid { get; set; }
        [Parameter] public string Avatar { get; set; }
        [Parameter] public string DisplayName { get; set; }
        [Parameter] public string FirstName { get; set; }
        [Parameter] public string LastName { get; set; }
        [Parameter] public string Email { get; set; }
        [Parameter] public string Phone { get; set; }
        [Parameter] public string CreatedBy { get; set; }
        [Parameter] public DateTime CreatedOn { get; set; }

        #endregion (Properties)
    }
}
