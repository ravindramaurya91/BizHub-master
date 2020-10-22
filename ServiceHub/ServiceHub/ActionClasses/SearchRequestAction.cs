using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using CommonUtil;
using BizSearch;
using Model;

namespace ServiceHub {
    public class SearchRequestAction : IAction {
        public void Run(QueableMessage toMessage) {
            // This method will be triggered when a user runs a Search.
            // We will trap the Search request and save it top the SearchRequestArchive table
            // to be used later when we want to see who has searched for what.  IE: When we run
            // an Email Blast we can assign a search criteria to the blast.
            // We will review that criteria against the searches run in the last 90 days to see who may be interested
            // in the email blast content.
            //
            // QueableMessage
            // MessageType = int that drives the task
            // TargetTable = Meta data to identify the target table (matches with the targetOid below)
            // TargetOid = Oid for the target record in the Target Table
            // Data object to have as a carrier for passing anything through to the run method

            #region Validation Checking
            // Check for Data
            if (toMessage.Data == null) {
                throw new ArgumentException("A message has been received to register a [SearchRequest] for a user, but the Data property of the Queueable Message is null. ");
            }
            #endregion (Validation Checking)

            try {
                SearchCriteria toCriteria = (SearchCriteria)toMessage.Data;
                Whse_RunSearchArchive oArchive = new Whse_RunSearchArchive(toCriteria) {
                    SearchCriteriaOid = toCriteria.Oid, EntityOid = toCriteria.EntityOid, RunDate = DateTime.UtcNow,
                    CashFlow_From = toCriteria.CashFlow_From, CashFlow_To = toCriteria.CashFlow_To, EBITDA_From = toCriteria.EBITDA_From,
                    EBITDA_To = toCriteria.EBITDA_To, EmployeeCount_From = toCriteria.EmployeeCount_From, EmployeeCount_To = toCriteria.EmployeeCount_To,
                    GrossRevenue_From = toCriteria.GrossRevenue_From,
                    GrossRevenue_To = toCriteria.GrossRevenue_To,
                    IsAbsenteeOwner = toCriteria.IsAbsenteeOwner,
                    IsActive = toCriteria.IsActive,
                    IsEmailNotification = toCriteria.IsEmailNotification,
                    IsEmailRecipientListQuery = toCriteria.IsEmailRecipientListQuery,
                    IsFranchise = toCriteria.IsFranchise,
                    IsHomeBased = toCriteria.IsHomeBased,
                    IsRealEstateAvailable = toCriteria.IsRealEstateAvailable,
                    IsRelocatable = toCriteria.IsRelocatable,
                    IsSbaPreApproved = toCriteria.IsSbaPreApproved,
                    IsSellerFinanace = toCriteria.IsSellerFinanace,
                    IsTextNotification = toCriteria.IsTextNotification,
                    Keywords = toCriteria.Keywords,
                    LastSearchedDate = DateTime.UtcNow,
                    ListingPrice_From = toCriteria.ListingPrice_From,
                    ListingPrice_To = toCriteria.ListingPrice_To,
                    lkpBusinessCategoryOids = toCriteria.lkpBusinessCategoryOids,
                    lkpCityOids = toCriteria.lkpCityOids,
                    lkpCountryOid = toCriteria.lkpCountryOid,
                    lkpCountyOids = toCriteria.lkpCountyOids,
                    lkpStateOid = toCriteria.lkpStateOid,
                    MinimumDownPayment_From = toCriteria.MinimumDownPayment_From,
                    MinimumDownPayment_To = toCriteria.MinimumDownPayment_To,
                    Name = toCriteria.Name,
                    SearchRadius = toCriteria.SearchRadius,
                    Street = toCriteria.Street,
                    TotalSqFt_From = toCriteria.TotalSqFt_From,
                    TotalSqFt_To = toCriteria.TotalSqFt_To,
                    ZipCode = toCriteria.ZipCode,
                    ZipCodes = toCriteria.ZipCodes
                };
                oArchive.Save();

            } catch (Exception ex) {
                // Log the error but continue.  This server cannot go down.
            }
        }
    }
}
