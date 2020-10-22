using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class SequenceItemDTO : SequenceItem, IHierarchy {

        #region Fields
        private IHierarchy _parent = null;
        private List<IHierarchy> _children = new List<IHierarchy>();
        #endregion (Fields)

        #region Contructor
        public SequenceItemDTO() {

        }

        public SequenceItemDTO(SequenceItem toItem) {
            Oid = toItem.Oid;
            ParentOid = toItem.ParentOid;
            EntityOid = toItem.EntityOid;
            ListingOid = toItem.ListingOid;
            lkpCheckListStatusOid = toItem.lkpCheckListStatusOid;
            lkpSequenceTypeOid = toItem.lkpSequenceTypeOid;
            InfoUrl = toItem.InfoUrl;
            Name = toItem.Name;
            Value = toItem.Name;
            IsExpanded = false;
            IsHidden = false;
            IsSelected = false;
            Seq = toItem.Seq;
        }
        #endregion (Contructor)

        #region Methods
        public static List<SequenceItemDTO> Rollup(List<SequenceItem> toItems) {
            List<SequenceItemDTO> oReturn = new List<SequenceItemDTO>();
            SequenceItemDTO oDTO;
            foreach (SequenceItem oItem in toItems) {
                oDTO = new SequenceItemDTO(oItem);
                if (oItem.ParentOid != null) {
                    SequenceItemDTO oParent = GetParent((Int64)oItem.ParentOid, oReturn, toItems);
                    if(oParent == null) {
                        throw new Exception("Unable to match ParentOid in the SequenceItemDTO.RollUpMethod()");
                    }  else {
                        oDTO.Parent = oParent;
                        oParent.Children.Add(oDTO);
                    }
                } else {
                    oReturn.Add(oDTO);
                }
            }

            return oReturn;
        }

        private static SequenceItemDTO GetParent(Int64 tiParentOid, List<SequenceItemDTO> toDtoList, List<SequenceItem> toSourceList) {
            SequenceItemDTO oReturn = GetParentFromDtoList(tiParentOid, toDtoList);
            if(oReturn == null) {
                // We may not have processed the parent yet - find it in the Source list & process it now 
                oReturn = GetParentFromSourceList(tiParentOid, toSourceList);
                toDtoList.Add(oReturn);
            }
            return oReturn;
        }
        private static SequenceItemDTO GetParentFromDtoList(Int64 tiParentOid, List<SequenceItemDTO> toDtoList) {
            SequenceItemDTO oReturn = null;
            foreach (SequenceItemDTO oDto in toDtoList) {
                if (oDto.Oid == tiParentOid) {
                    oReturn = oDto;
                    break;
                }
            }
            return oReturn;
        }
        private static SequenceItemDTO GetParentFromSourceList(Int64 tiParentOid, List<SequenceItem> toSourceList) {
            SequenceItemDTO oReturn = null;
            foreach (SequenceItem oItem in toSourceList) {
                if (oItem.Oid == tiParentOid) {
                    oReturn = new SequenceItemDTO(oItem);
                    break;
                }
            }
            return oReturn;
        }
        #endregion (Methods)

        #region Properties
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
        public bool IsSelected { get; set; }

        public IHierarchy Parent { get => _parent; set => _parent = value; }
        public List<IHierarchy> Children { get => _children; set => _children = value; }
        #endregion (Properties)
    }
}
