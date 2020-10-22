using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;

namespace BizHub.Components.TransitionPlanner
{
    public partial class CmpTransitionPlanner
    {

        #region Fields
        private CmpTransitionPlannerController _controller = new CmpTransitionPlannerController();
        #endregion (Fields)

        #region Constructor
        public CmpTransitionPlanner()
        {
            if ((Controller != null) && (EntityOid > 0) && (ListingOid > 0))
            {
                LoadSequences();
            }
        }
        #endregion (Constructor)

        #region Methods
        public void LoadSequences()
        {
            Controller.LoadSequences();
        }
        public void OpenStatus(SequenceItemDTO sequenceItemDTO)
        {
            sequenceItemDTO.IsSelected = !sequenceItemDTO.IsSelected;
        }
        public void OpenChildStatus(IHierarchy hierarchy)
        {
            hierarchy.IsSelected = !hierarchy.IsSelected;
        }
        #endregion (Methods)

        #region Properties
        // [Parameter] public CmpTransitionPlannerController Controller { get; set; }
        public CmpTransitionPlannerController Controller { get => _controller; set => _controller = value; }
        [Parameter] public Int64 EntityOid { get => Controller.EntityOid; set => Controller.EntityOid = value; } // Buyer EntityOid
        [Parameter] public Int64 ListingOid { get => Controller.ListingOid; set => Controller.ListingOid = value; }
        public List<SequenceItemDTO> Sequences { get => Controller.Sequences; set => Controller.Sequences = value; }
        #endregion (Properties)

    }
}
