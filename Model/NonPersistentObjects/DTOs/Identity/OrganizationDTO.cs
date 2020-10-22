using System;
using System.Collections.Generic;
using System.Text;

using PetaPoco;
    
namespace Model {
    public class OrganizationDTO : BaseEntity {

        #region Fields
        private List<RegionDTO> _regions = new List<RegionDTO>();
        private List<OfficeDTO> _officess = new List<OfficeDTO>();
        private List<UserDTO> _users = new List<UserDTO>();
        #endregion (Fields)



        #region Properties
        [Column("HasMultipleRegions")]
        public bool HasMultipleRegions { get; set; }
        [Column("HasMultipleOffices")]
        public bool HasMultipleOffices { get; set; }
        [Column("AboutMe")]
        public string AboutMe { get; set; }

        public List<RegionDTO> Regions { get => _regions; set => _regions = value; }
        public List<OfficeDTO> Offices { get => _officess; set => _officess = value; }
        public List<UserDTO> Users { get => _users; set => _users = value; }
        #endregion (Properties)

    }
}
