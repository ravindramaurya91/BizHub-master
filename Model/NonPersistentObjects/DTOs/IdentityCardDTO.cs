using System;
using System.Collections.Generic;
using System.Linq;
using PetaPoco;

namespace Model {
    public class IdentityCardDTO : Entity {
        #region Fields
        private List<NameValuePair> _urls = new List<NameValuePair>();
        private string _licensedIn = "";
        private string _areasServed = "";
        private string _tagLine = "";

        #endregion (Fields)

        #region Methods
        public static IdentityCardDTO GetProfileCardDTOByEntityOid(Int64 tiEntityOid) {
            IdentityCardDTO oReturn = SQL.GetIdentityCardDTOByEntityOid(tiEntityOid);
            return oReturn;
        }

        public IdentityCardDTO Save() {
            //Save Entity
            SaveEntity();

            //Save Entity Attributes
            SaveUrls();

            return this;
        }

        private void SaveEntity() {
            Entity oEntity = SQL.GetEntityByOid(this.Oid, true);
            DTO2Entity(oEntity);
            oEntity.Save();
            Entity2DTO(oEntity);
        }

        private void SaveUrls() {
            List<Int64> iDeleteList = new List<Int64>();
            foreach (NameValuePair oPair in Urls) {
                if (oPair.DeleteMe) {
                    EntityAttribute.Delete(oPair.Oid);
                } else {
                    EntityAttribute oAttribute = null;
                    if (oPair.Oid > 0) {
                        oAttribute = SQL.GetEntityAttributeByOid(oPair.Oid, false);
                    }
                    if (oAttribute == null) {
                        oAttribute = new EntityAttribute();
                        oAttribute.EntityOid = SessionMgr.Instance.User.EntityOid;
                        oAttribute.lkpAttributeTypeOid = LookupManager.Instance.GetOidByConstantValue("ATTRIBUTETYPE->EXTERNALURL");
                        oAttribute.HasChildren = false;
                    }

                    oAttribute.Text = oPair.Name;
                    oAttribute.Text2 = oPair.Value;
                    oAttribute.Save();
                    EntityAttribute2Url(oAttribute, oPair);
                }
            }
            if(iDeleteList.Count > 0) {
                Base.Database.GetInstance().Execute("DELETE EntityAttribute WHERE Oid IN (@0)", iDeleteList);
            }
        }

        public void EntityAttribute2Url(EntityAttribute toAttribute, NameValuePair toPair) {
            toPair.Oid = toAttribute.Oid;
            toPair.Name = toAttribute.Text;
            toPair.Value = toAttribute.Text2;
        }

        public void DTO2Entity(Entity toEntity) {
            toEntity.AboutMe = AboutMe;
            toEntity.Address1 = Address1;
            toEntity.Address2 = Address2;
            toEntity.AreasServed = AreasServed;
            toEntity.Avatar = Avatar;
            toEntity.CompanyName = CompanyName;
            toEntity.Country = Country;
            toEntity.DisplayName = DisplayName;
            toEntity.Email = Email;
            toEntity.FirstName = FirstName;
            toEntity.LastName = LastName;
            toEntity.LicensedIn = LicensedIn;
            toEntity.Phone = Phone;
            toEntity.Title = Title;
            toEntity.Zip = Zip;
        }

        public void Entity2DTO(Entity toEntity) {
            AboutMe = toEntity.AboutMe;
            Address1 = toEntity.Address1;
            Address2 = toEntity.Address2;
            AreasServed = toEntity.AreasServed;
            Avatar = toEntity.Avatar;
            CompanyName = toEntity.CompanyName;
            Country = toEntity.Country;
            DisplayName = toEntity.DisplayName;
            Email = toEntity.Email;
            FirstName = toEntity.FirstName;
            LastName = toEntity.LastName;
            LicensedIn = toEntity.LicensedIn;
            Phone = toEntity.Phone;
            Title = toEntity.Title;
            Zip = toEntity.Zip;
        }

        // Create Entity From DTO

        #endregion (Methods)

        #region Properties

        [Ignore]
        public List<NameValuePair> Urls {
            get { return _urls; }
            set { _urls = value; }
        }

        [Ignore]
        public string LicensedIn { get=> _licensedIn; set => _licensedIn = value; }

        [Ignore]
        public string AreasServed { get => _areasServed; set => _areasServed = value; }

        [Ignore]
        public string TagLine { get => _tagLine; set => _tagLine = value; }
        #endregion (Properties)
    }
}
