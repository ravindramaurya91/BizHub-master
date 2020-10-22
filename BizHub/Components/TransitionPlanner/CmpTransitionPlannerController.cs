using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;

namespace BizHub {
    public class CmpTransitionPlannerController {

        #region Fields
        private Int64 _entityOid = 8; // Hard coded test value for development
        private Int64 _listingOid = 45; // Hard coded test value for development
        List<SequenceItemDTO> _sequences = new List<SequenceItemDTO>();
        #endregion (Fields)

        #region Methods
        public void LoadSequences() {
            _sequences = SQL.GetSequenceItemDTOByEntityOidAndListingOid(EntityOid, ListingOid);
        }
        #endregion (Methods)


        #region Properties
        public Int64 EntityOid { get=>_entityOid; set=>_entityOid=value; } // Buyer EntityOid
        public Int64 ListingOid { get=>_listingOid; set=>_listingOid = value; }
        public List<SequenceItemDTO> Sequences { get => _sequences; set => _sequences = value; }
        #endregion (Properties)
    }
}
