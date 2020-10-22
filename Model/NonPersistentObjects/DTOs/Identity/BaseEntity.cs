using System;
using System.Collections.Generic;
using System.Text;

using Base;
using PetaPoco;

namespace Model {
    public class BaseEntity : IModel{

        #region Properties
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
        [Column("StartDate")]
        public DateTime StartDate { get; set; }
        [Column("IsActive")]
        public bool IsActive { get; set; }
        [Column("ListingCount")]
        public int ListingCount { get; set; }
        [Column("Preferences")]
        public string Preferences { get; set; }  
        #endregion (Properties)



    }
}
