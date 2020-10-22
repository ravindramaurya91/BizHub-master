using System;
using SqlKata;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using PetaPoco;


namespace Model {
    class ProfileCardDTO_Receiver {

        public static List<IdentityCardDTO> Rollup(List<ProfileCardDTO_Receiver> toRcvrs) {
            List<IdentityCardDTO> oReturnList = new List<IdentityCardDTO>();
            IdentityCardDTO oCurrentProfileCardDTO = null;
            NameValuePair oCurrentURLNameValuePair = null;
            Int64 iLkpAttributeTypeOid_Url = LookupManager.Instance.GetOidByConstantValue("ATTRIBUTETYPE->EXTERNALURL");

            foreach (ProfileCardDTO_Receiver oRcvr in toRcvrs) {
                oCurrentProfileCardDTO = ModelUtil.GetFromListByOid<IdentityCardDTO>(oRcvr.Oid, oReturnList);
                
                if (oCurrentProfileCardDTO == null) {
                    oCurrentProfileCardDTO = CreateDTOFromReceiver(oRcvr);
                    oReturnList.Add(oCurrentProfileCardDTO);
                }

                // Rollup EntityAttribute
                if (oRcvr.ea_Oid > 0) {
                    oCurrentURLNameValuePair = ModelUtil.GetFromListByOid<NameValuePair>(oRcvr.ea_Oid, oCurrentProfileCardDTO.Urls);
                    if (oCurrentURLNameValuePair == null) {
                        if (oRcvr.ea_lkpAttributeTypeOid == iLkpAttributeTypeOid_Url) {
                            // This is a Url that is associated with an Individual
                            oCurrentURLNameValuePair = CreateUrlFromEntityAttribute(oRcvr);
                            oCurrentProfileCardDTO.Urls.Add(oCurrentURLNameValuePair);
                        }
                    }
                }
            }
            return oReturnList;
        }

        private static IdentityCardDTO CreateDTOFromReceiver(ProfileCardDTO_Receiver toReceiver) {
            IdentityCardDTO oReturn = new IdentityCardDTO() {
                AboutMe = toReceiver.AboutMe, Address1 = toReceiver.Address1, Address2 = toReceiver.Address2, AreasServed = toReceiver.AreasServed, LicensedIn = toReceiver.LicensedIn, IsElite = toReceiver.IsElite,
                Avatar = toReceiver.Avatar, CompanyName = toReceiver.CompanyName, Country = toReceiver.Country, DisplayName = toReceiver.DisplayName,
                Email = toReceiver.Email, FirstName = toReceiver.FirstName, LastName = toReceiver.LastName, Oid = toReceiver.Oid, Phone = toReceiver.Phone,
                Title = toReceiver.Title, Urls = new List<NameValuePair>(), Zip = toReceiver.Zip, TagLine = toReceiver.bc_TagLine, City = toReceiver.City, State = toReceiver.State
            };
            return oReturn;
        }

        private static NameValuePair CreateUrlFromEntityAttribute(ProfileCardDTO_Receiver toReceiver) {
            NameValuePair oReturn = new NameValuePair() {
                Oid = toReceiver.ea_Oid, Name = !string.IsNullOrEmpty(toReceiver.ea_Text) ? toReceiver.ea_Text : "",
                Value = !string.IsNullOrEmpty(toReceiver.ea_Text2) ? toReceiver.ea_Text2 : "", DeleteMe = false
            };
            return oReturn;
        }


        // Entity
        [Column("Oid")]
        public Int64 Oid { get; set; }
        [Column("DisplayName")]
        public string DisplayName { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Zip")]
        public string Zip { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("AboutMe")]
        public string AboutMe { get; set; }
        [Column("Address1")]
        public string Address1 { get; set; }
        [Column("Address2")]
        public string Address2 { get; set; }
        [Column("AreasServed")]
        public string? AreasServed { get; set; }
        [Column("Country")]
        public string Country { get; set; }
        [Column("Avatar")]
        public string Avatar { get; set; }
        [Column("CompanyName")]
        public string CompanyName { get; set; }
        [Column("Title")]
        public string Title { get; set; }
        [Column("IsElite")]
        public bool? IsElite { get; set; }
        [Column("LicensedIn")]
        public string? LicensedIn { get; set; }
        // EntityAttribute
        [Column("ea_Oid")]
        public Int64 ea_Oid { get; set; }
        [Column("ea_lkpAttributeTypeOid")]
        public Int64 ea_lkpAttributeTypeOid { get; set; }
        [Column("ea_Text")]
        public string ea_Text { get; set; }
        [Column("ea_Text2")]
        public string ea_Text2 { get; set; }
        [Column("bc_TagLine")]
        public string bc_TagLine { get; set; }


    }
}
