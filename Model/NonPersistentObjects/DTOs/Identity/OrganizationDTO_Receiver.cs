using System;
using System.Collections.Generic;
using System.Text;

using PetaPoco;

namespace Model {
    public class OrganizationDTO_Receiver {

        #region Methods
        public static OrganizationDTO Rollup(List<OrganizationDTO_Receiver> toList) {
            OrganizationDTO oReturn = null;
            RegionDTO oRegion = null;
            OfficeDTO oOffice = null;
            UserDTO oUser = null;
            List<OfficeDTO> olistOfOffices = null;
            List<UserDTO> olistOfUsers = null;

            foreach (OrganizationDTO_Receiver oItem in toList) {
                if(oReturn == null) {
                    oReturn = new OrganizationDTO() {
                        Oid = oItem.Oid, EntityOid_Master = oItem.EntityOid_Master, EntityOid_Region = oItem.EntityOid_Region, EntityOid_Office = oItem.EntityOid_Office,
                        Address1 = oItem.Address1, Address2 = oItem.Address2, City = oItem.City, State = oItem.State, Zip = oItem.Zip, Country = oItem.Country,
                        BannerImage = oItem.BannerImage, Avatar = oItem.Avatar, Email = oItem.Email, Name = oItem.Name, DisplayName = oItem.DisplayName,
                        AboutMe = oItem.AboutMe, FaxNumber = oItem.FaxNumber, HasMultipleOffices = oItem.HasMultipleOffices, HasMultipleRegions = oItem.HasMultipleRegions,
                        IsActive = oItem.IsActive, ListingCount = oItem.ListingCount, lkpCountryOid = oItem.lkpCountryOid, lkpEntityTypeOid = oItem.lkpEntityTypeOid, lkpStateOid = oItem.lkpStateOid,
                        lkpStateOids_Servicing = oItem.lkpStateOids_Servicing, lkpTimeZoneOid = oItem.lkpTimeZoneOid, Phone = oItem.Phone, Preferences = oItem.Preferences, StartDate = oItem.StartDate
                    };
                    olistOfOffices = oReturn.Offices;
                    olistOfUsers = oReturn.Users;
                }

                if (oReturn.HasMultipleRegions){
                    if (oItem.reg_Oid > 0) {
                        oRegion = ModelUtil.GetFromListByOid(oItem.reg_Oid, oReturn.Regions);
                        if (oRegion == null) {
                            oRegion = CreateRegion(oItem);
                            oReturn.Regions.Add(oRegion);
                        }
                    }
                }

                if (oReturn.HasMultipleOffices) {
                    if (oItem.ofc_Oid > 0) {
                        oOffice = ModelUtil.GetFromListByOid(oItem.ofc_Oid, oReturn.Offices);
                        if (oOffice == null) {
                            oOffice = CreateOffice(oItem);
                            if(oRegion != null) {
                                oRegion.Offices.Add(oOffice);  // Ad tothe region to create the hierarchic view
                            }
                            oReturn.Offices.Add(oOffice);  // Duplicate the Office - Add it to the Organization's Office list fo a flat view of the Offices
                        }
                    }
                }

                if (oItem.usr_Oid > 0) {
                    oUser = ModelUtil.GetFromListByOid(oItem.usr_Oid, oReturn.Users);
                    if (oUser == null) {
                        oUser = CreateUser(oItem);
                        if (oReturn.HasMultipleOffices) {
                            oOffice.Users.Add(oUser);
                        }
                        oReturn.Users.Add(oUser);
                    }
                }
            }

            return oReturn; 
        }


        private static RegionDTO CreateRegion(OrganizationDTO_Receiver toItem) {
            RegionDTO oReturn = new RegionDTO() {
                Oid = toItem.reg_Oid, EntityOid_Master = toItem.reg_EntityOid_Master, lkpTimeZoneOid = toItem.reg_lkpTimeZoneOid,
                lkpCountryOid = toItem.reg_lkpCountryOid, lkpStateOid = toItem.reg_lkpStateOid, lkpStateOids_Servicing = toItem.reg_lkpStateOids_Servicing,
                Name = toItem.reg_Name, DisplayName = toItem.reg_DisplayName, HasMultipleOffices = toItem.reg_HasMultipleOffices,
                IsActive = toItem.reg_IsActive, ListingCount = toItem.reg_ListingCount
            };
            return oReturn;
        }

        private static OfficeDTO CreateOffice(OrganizationDTO_Receiver toItem) {
            return new OfficeDTO() {
                Oid = toItem.ofc_Oid, lkpTimeZoneOid = toItem.ofc_lkpTimeZoneOid, lkpCountryOid = toItem.ofc_lkpCountryOid,
                lkpStateOid = toItem.ofc_lkpStateOid, lkpStateOids_Servicing = toItem.ofc_lkpStateOids_Servicing,
                Name = toItem.ofc_Name, DisplayName = toItem.ofc_DisplayName, Address1 = toItem.ofc_Address1, Address2 = toItem.ofc_Address2,
                City = toItem.ofc_City, State = toItem.ofc_State, Zip = toItem.ofc_Zip, Country = toItem.ofc_Country,
                Avatar = toItem.ofc_Avatar, BannerImage = toItem.ofc_BannerImage,
                Phone = toItem.ofc_Phone, FaxNumber = toItem.ofc_FaxNumber, Email = toItem.ofc_Email,
                IsActive = toItem.ofc_IsActive, ListingCount = toItem.ofc_ListingCount, Preferences = toItem.ofc_Preferences
            };
        }

        private static UserDTO CreateUser(OrganizationDTO_Receiver toItem) {
            return new UserDTO() {
                Oid = toItem.usr_Oid, lkpTimeZoneOid = toItem.usr_lkpTimeZoneOid, lkpCountryOid = toItem.usr_lkpCountryOid,
                lkpStateOid = toItem.usr_lkpStateOid, lkpStateOids_Servicing = toItem.usr_lkpStateOids_Servicing,
                FirstName = toItem.usr_FirstName, LastName = toItem.usr_LastName, DisplayName = toItem.usr_DisplayName, Address1 = toItem.usr_Address1, Address2 = toItem.usr_Address2,
                City = toItem.usr_City, State = toItem.usr_State, Zip = toItem.usr_Zip, Country = toItem.usr_Country,
                Avatar = toItem.usr_Avatar, BannerImage = toItem.usr_BannerImage, StartDate = toItem.usr_StartDate,
                Phone = toItem.usr_Phone, FaxNumber = toItem.usr_FaxNumber, Email = toItem.usr_Email,
                IsActive = toItem.usr_IsActive, ListingCount = toItem.usr_ListingCount, Preferences = toItem.usr_Preferences,
                Title = toItem.usr_Title, AboutMe = toItem.usr_AboutMe, DOB = toItem.usr_DOB, IsElite = toItem.usr_IsElite
            };
        }
        #endregion (Methods)

        #region Properties
        // Organization
        [Column("Oid")]
        public long Oid { get; set; }
        [Column("EntityOid_Master")]
        public long EntityOid_Master { get; set; }
        [Column("EntityOid_Region")]
        public long EntityOid_Region { get; set; }
        [Column("EntityOid_Office")]
        public long EntityOid_Office { get; set; }
        [Column("lkpEntityTypeOid")]
        public Int64 lkpEntityTypeOid { get; set; }
        [Column("lkpTimeZoneOid")]
        public Int64 lkpTimeZoneOid { get; set; }
        [Column("lkpCountryOid")]
        public Int64 lkpCountryOid { get; set; }
        [Column("lkpStateOid")]
        public Int64 lkpStateOid { get; set; }
        [Column("lkpStateOids_Servicing")]
        public string lkpStateOids_Servicing { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("DisplayName")]
        public string DisplayName { get; set; }
        [Column("Address1")]
        public string Address1 { get; set; }
        [Column("Address2")]
        public string Address2 { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("State")]
        public string State { get; set; }
        [Column("Zip")]
        public string Zip { get; set; }
        [Column("Country")]
        public string Country { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }
        [Column("FaxNumber")]
        public string FaxNumber { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("BannerImage")]
        public string BannerImage { get; set; }
        [Column("Avatar")]
        public string Avatar { get; set; }
        [Column("HasMultipleRegions")]
        public bool HasMultipleRegions { get; set; }
        [Column("HasMultipleOffices")]
        public bool HasMultipleOffices { get; set; }
        [Column("AboutMe")]
        public string AboutMe { get; set; }
        [Column("StartDate")]
        public DateTime StartDate { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("ListingCount")]
        public int ListingCount { get; set; }
        [Column("Preferences")]
        public string Preferences { get; set; }

        // Region
        [Column("reg_Oid")]
        public long reg_Oid { get; set; }
        [Column("reg_EntityOid_Master")]
        public long reg_EntityOid_Master { get; set; }
        [Column("reg_lkpTimeZoneOid")]
        public long reg_lkpTimeZoneOid { get; set; }
        [Column("reg_lkpCountryOid")]
        public long reg_lkpCountryOid { get; set; }
        [Column("reg_lkpStateOid")]
        public long reg_lkpStateOid { get; set; }
        [Column("reg_lkpStateOids_Servicing")]
        public string reg_lkpStateOids_Servicing { get; set; }
        [Column("reg_Name")]
        public string reg_Name { get; set; }
        [Column("reg_DisplayName")]
        public string reg_DisplayName { get; set; }
        [Column("reg_HasMultipleOffices")]
        public bool reg_HasMultipleOffices { get; set; }
        [Column("reg_IsActive")]
        public bool reg_IsActive { get; set; }
        [Column("reg_ListingCount")]
        public int reg_ListingCount { get; set; }

        // Office
        [Column("ofc_Oid")]
        public long ofc_Oid { get; set; }
        [Column("ofc_lkpTimeZoneOid")]
        public long ofc_lkpTimeZoneOid { get; set; }
        [Column("ofc_lkpCountryOid")]
        public long ofc_lkpCountryOid { get; set; }
        [Column("ofc_lkpStateOid")]
        public long ofc_lkpStateOid { get; set; }
        [Column("ofc_lkpStateOids_Servicing")]
        public string ofc_lkpStateOids_Servicing { get; set; }
        [Column("ofc_Name")]
        public string ofc_Name { get; set; }
        [Column("ofc_DisplayName")]
        public string ofc_DisplayName { get; set; }
        [Column("ofc_Address1")]
        public string ofc_Address1 { get; set; }
        [Column("ofc_Address2")]
        public string ofc_Address2 { get; set; }
        [Column("ofc_City")]
        public string ofc_City { get; set; }
        [Column("ofc_State")]
        public string ofc_State { get; set; }
        [Column("ofc_Zip")]
        public string ofc_Zip { get; set; }
        [Column("ofc_Country")]
        public string ofc_Country { get; set; }
        [Column("ofc_Phone")]
        public string ofc_Phone { get; set; }
        [Column("ofc_Email")]
        public string ofc_Email { get; set; }
        [Column("ofc_FaxNumber")]
        public string ofc_FaxNumber { get; set; }
        [Column("ofc_BannerImage")]
        public string ofc_BannerImage { get; set; }
        [Column("ofc_Avatar")]
        public string ofc_Avatar { get; set; }
        [Column("ofc_IsActive")]
        public bool ofc_IsActive { get; set; }
        [Column("ofc_ListingCount")]
        public int ofc_ListingCount { get; set; }
        [Column("ofc_Preferences")]
        public string ofc_Preferences { get; set; }

        // User
        [Column("usr_Oid")]
        public long usr_Oid { get; set; }
        [Column("usr_lkpUserTypeOid")]
        public long usr_lkpUserTypeOid { get; set; }
        [Column("usr_lkpTimeZoneOid")]
        public long usr_lkpTimeZoneOid { get; set; }
        [Column("usr_lkpCountryOid")]
        public long usr_lkpCountryOid { get; set; }
        [Column("usr_lkpStateOid")]
        public long usr_lkpStateOid { get; set; }
        [Column("usr_lkpStateOids_Servicing")]
        public string usr_lkpStateOids_Servicing { get; set; }
        [Column("usr_FirstName")]
        public string usr_FirstName { get; set; }
        [Column("usr_LastName")]
        public string usr_LastName { get; set; }
        [Column("usr_DisplayName")]
        public string usr_DisplayName { get; set; }
        [Column("usr_Address1")]
        public string usr_Address1 { get; set; }
        [Column("usr_Address2")]
        public string usr_Address2 { get; set; }
        [Column("usr_City")]
        public string usr_City { get; set; }
        [Column("usr_State")]
        public string usr_State { get; set; }
        [Column("usr_Zip")]
        public string usr_Zip { get; set; }
        [Column("usr_Country")]
        public string usr_Country { get; set; }
        [Column("usr_Phone")]
        public string usr_Phone { get; set; }
        [Column("usr_Email")]
        public string usr_Email { get; set; }
        [Column("usr_FaxNumber")]
        public string usr_FaxNumber { get; set; }
        [Column("usr_BannerImage")]
        public string usr_BannerImage { get; set; }
        [Column("usr_Avatar")]
        public string usr_Avatar { get; set; }
        [Column("usr_StartDate")]
        public DateTime usr_StartDate { get; set; }
        [Column("usr_IsActive")]
        public bool usr_IsActive { get; set; }
        [Column("usr_ListingCount")]
        public int usr_ListingCount { get; set; }
        [Column("usr_Title")]
        public string usr_Title { get; set; }
        [Column("usr_AboutMe")]
        public string usr_AboutMe { get; set; }
        [Column("usr_DOB")]
        public DateTime usr_DOB { get; set; }
        [Column("usr_IsElite")]
        public bool usr_IsElite { get; set; }
        [Column("usr_Preferences")]
        public string usr_Preferences { get; set; }
		#endregion (Properties)

	}
}
