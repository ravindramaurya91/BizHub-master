using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BizHub.Pages.Transition_Planner
{
    public partial class PagTransitionPlanner
    {

        #region Fields
        private Int64 _entityOid = 8; // Hard coded test value for development
        private Int64 _listingOid = 45; // Hard coded test value for development
        private PagTransitionPlannerController _controller = new PagTransitionPlannerController();
        private CmpTransitionPlannerController _cmpController = new CmpTransitionPlannerController();
        #endregion (Fields)

        #region Methods
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                if (CurrentMenu <= 0 || CurrentMenu == null)
                {
                    SelectMenuItem(1);
                }
            }
        }
        public void SelectMenuItem(int menuNumber)
        {
            _controller.NavManager.NavigateTo("/TransitionPlanner/" + menuNumber);
        }
        #endregion(Methods)

        #region Properties
        [Parameter] public long CurrentMenu { get; set; }
        public PagTransitionPlannerController Controller { get => _controller; }
        public CmpTransitionPlannerController CmpController { get => _cmpController; set => _cmpController = value; }
        public Int64 EntityOid { get => _entityOid; set => _entityOid = value; } // Buyer EntityOid
        public Int64 ListingOid { get => _listingOid; set => _listingOid = value; }
        #endregion(Properties)
    }
}
