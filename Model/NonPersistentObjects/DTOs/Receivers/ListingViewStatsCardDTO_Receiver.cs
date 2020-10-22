using CommonUtil;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model{
    public class ListingViewStatsCardDTO_Receiver : ListingViewStatsCardDTO {

        #region Methods
        public static List<ListingViewStatsCardDTO> Rollup(List<ListingViewStatsCardDTO_Receiver> toRcvrs) {
            ListingViewStatsCardDTO oCurrentCreateListingDTO = null;
            List<ListingViewStatsCardDTO> oReturnList = new List<ListingViewStatsCardDTO>();

            foreach (ListingViewStatsCardDTO_Receiver oRcvr in toRcvrs) {
                oCurrentCreateListingDTO = ModelUtil.GetFromListByOid<ListingViewStatsCardDTO>((Int64)oRcvr.Oid, oReturnList);
                if (oCurrentCreateListingDTO == null) {
                    oCurrentCreateListingDTO = CreateListingViewStatsCardDTOFromReceiver(oRcvr);
                    oReturnList.Add(oCurrentCreateListingDTO);
                }
            }
            return oReturnList;
        }

        private static ListingViewStatsCardDTO CreateListingViewStatsCardDTOFromReceiver(ListingViewStatsCardDTO_Receiver toReceiver) {
            ListingViewStatsCardDTO oReturn = new ListingViewStatsCardDTO() {
                AdTitle = toReceiver.AdTitle, Clicks = toReceiver.Clicks, ClicksLast24Hrs = toReceiver.ClicksLast24Hrs, ClicksLast3Months = toReceiver.ClicksLast3Months, ClicksLast7Days = toReceiver.ClicksLast7Days,
                ClicksLastMonth = toReceiver.ClicksLastMonth, CompanyName = toReceiver.CompanyName, ContactRequests = toReceiver.ContactRequests, ContactRequestsLast24Hrs = toReceiver.ContactRequestsLast24Hrs, ContactRequestsLast3Months = toReceiver.ContactRequestsLast3Months,
                ContactRequestsLast7Days = toReceiver.ContactRequestsLast7Days, ContactRequestsLastMonth = toReceiver.ContactRequestsLastMonth, DeleteMe = toReceiver.DeleteMe, EditInProgress = toReceiver.EditInProgress, EntityOid = toReceiver.EntityOid, EntityOid_Region = toReceiver.EntityOid_Region, EntityOid_Office = toReceiver.EntityOid_Office,
                EntityOid_Master = toReceiver.EntityOid_Master, Favorited = toReceiver.Favorited, FavoritedLast24Hrs = toReceiver.FavoritedLast24Hrs, FavoritedLast3Months = toReceiver.FavoritedLast3Months, FavoritedLast7Days = toReceiver.FavoritedLast7Days,
                FavoritedLastMonth = toReceiver.FavoritedLastMonth, ListingOid = toReceiver.ListingOid, l_DateListed = toReceiver.l_DateListed, Oid = toReceiver.Oid, Title = toReceiver.Title, Views = toReceiver.Views, ViewsLast24Hrs = toReceiver.ViewsLast24Hrs,
                ViewsLast3Months = toReceiver.ViewsLast3Months, ViewsLast7Days = toReceiver.ViewsLast7Days, ViewsLastMonth = toReceiver.ViewsLastMonth, IsExpanded = false, IsHidden = false, l_IsActive = toReceiver.l_IsActive, l_lkpListingSetupStatusOid = toReceiver.l_lkpListingSetupStatusOid, l_IsPending = toReceiver.l_IsPending
            };
            return oReturn;
        }
        #endregion (Methods)


        #region Properties
        [Column("l_IsActive")]
        public bool l_IsActive { get; set; }
        [Column("l_IsPending")]
        public bool l_IsPending { get; set; }
        [Column("l_lkpListingSetupStatusOid")]
        public Int64 l_lkpListingSetupStatusOid { get; set; }
        #endregion (Properties)

    }
}
