using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizHub.Services;

using Model;

namespace BizHub {
    public class PagListingSetupController : BasePageController {

        #region Fields
        private ListingDTO _listingDTO;
        private Int64 _currentStep;
        private Int64 _stepOneOid = LookupManager.Instance.GetOidByConstantValue("LISTINGSETUPSTATUS->STEPONE");
        private Int64 _stepTwoOid = LookupManager.Instance.GetOidByConstantValue("LISTINGSETUPSTATUS->STEPTWO");
        private Int64 _stepThreeOid = LookupManager.Instance.GetOidByConstantValue("LISTINGSETUPSTATUS->STEPTHREE");
        private Int64 _completeOid = LookupManager.Instance.GetOidByConstantValue("LISTINGSETUPSTATUS->COMPLETE");
        private bool _isSubmitted = false;
        #endregion (Fields)

        #region Methods
        public void CreateDefaultListingDTO() {
            ListingDTO = new ListingDTO() { lkpCountryOid = LookupManager.Instance.GetOidByConstantValue("COUNTRY->UNITEDSTATES"), lkpListingSetupStatusOid = StepOneOid };
        }

        public void GetAndSetListingDTOByOid(Int64 tiOid) {
            BaseResponse oResponse = new BaseResponse();
            oResponse = DataService.GetListingDTOByOid(tiOid);
            if (oResponse.Data != null) {
                ListingDTO = (ListingDTO)oResponse.Data;
            } else {
                //throw error modal with single 'OK' button and no 'X' at the top. ok navigates them to the home page.
                //TODO: Pop Modal Dialogue with the error in the response
            }
        }


        public void AddUpdateCreateListingDTO() {
            try {
                DataService.AddUpdateListing(ListingDTO);
            } catch (Exception ex) {
                ShowPopupDialog(ex.Message, "Error");
            }
        }

        public void FinalSetupSave() {
            try {
                DataService.CompleteAndPublishListing(ListingDTO);
            } catch (Exception ex) {
                ShowPopupDialog(ex.Message, "Error");
            }
        }

        public async void NavigateFromOneToTwo() {
            string s = IsFirstStepValid();
            if (s.Length == 0) {
                if (ListingDTO.lkpListingSetupStatusOid == null || ListingDTO.lkpListingSetupStatusOid == StepOneOid) {
                    ListingDTO.lkpListingSetupStatusOid = StepTwoOid;
                }
                NavigateToNewStep(2);
            } else {
                ShowPopupDialog(s, "Error");
            }
        }

        public void NavigateFromTwoToThree() {
            string s = IsSecondStepValid();
            if (s.Length == 0) {
                if ((ListingDTO.lkpListingSetupStatusOid != StepThreeOid) && (ListingDTO.lkpListingSetupStatusOid != CompleteOid)) {
                    ListingDTO.lkpListingSetupStatusOid = StepThreeOid;
                }
                IsSubmitted = false;
                NavigateToNewStep(3);
            } else
            {
                ShowPopupDialog(s, "Error");
            }
        }

        public void NavigateFromOneToThree() {
            string s1 = IsFirstStepValid();
            string s2 = IsSecondStepValid();
            if(s1.Length > 0) {
                ShowPopupDialog(s1, "Error");
            } else if (ListingDTO.lkpListingSetupStatusOid == null || ListingDTO.lkpListingSetupStatusOid == StepOneOid) {
                ShowPopupDialog("Must first complete the second page of the creation process", "Error");
            } else if(s2.Length > 0){
                ShowPopupDialog("Validation issues on second page of the creation process: <br>" + s2, "Error");
            } else {
                if (ListingDTO.lkpListingSetupStatusOid == StepTwoOid) {
                    ListingDTO.lkpListingSetupStatusOid = StepThreeOid;
                }
                IsSubmitted = false;
                NavigateToNewStep(3);
            }
        }

        public void SaveAndExit() {
            IsSubmitted = true;
            if (ListingDTO.lkpListingSetupStatusOid == CompleteOid) {
                switch (CurrentStep) {
                    case 1:
                        string s1 = IsFirstStepValid();
                        if (s1.Length == 0) {
                            AddUpdateCreateListingDTO();
                            IsSubmitted = false;
                        } else {
                            ShowPopupDialog(s1, "Error");
                        }
                        break;
                    case 2:
                        string s2 = IsSecondStepValid();
                        if (s2.Length == 0) {
                            AddUpdateCreateListingDTO();
                            IsSubmitted = false;
                        } else {
                            ShowPopupDialog(s2, "Error");
                        }
                        break;
                    case 3:
                        string s3 = IsThirdStepValid();
                        if (s3.Length == 0) {
                            AddUpdateCreateListingDTO();
                            IsSubmitted = false;
                        } else {
                            ShowPopupDialog(s3, "Error");
                        }
                        break;
                    default:
                        AddUpdateCreateListingDTO();
                        IsSubmitted = false;
                        break;
                }
            } else {
                if (!string.IsNullOrEmpty(ListingDTO.Zip)) {
                    ListingDTO.IsPending = true;
                    AddUpdateCreateListingDTO();
                    IsSubmitted = false;
                } else {
                    ShowPopupDialog("Must at least have a Zip Code in order to save a listing in progress", "Error");
                }
            }
            NavigateToMyListings();
        }

        public void NavigateToMyListings() {
            NavManager.NavigateTo("/Account-Setup/3");
        }

        public void CompleteListing() {
            IsSubmitted = true;
            string s3 = IsThirdStepValid();
            if (s3.Length == 0) {
                FinalSetupSave();
                NavigateToMyListings();
            } else {
                ShowPopupDialog(s3, "Error");
            }
        }

        public void ArrowSelected(Int64 tiStepNumber) {
            IsSubmitted = true;
            if (tiStepNumber > CurrentStep) {
                if (CurrentStep == 1) {
                    if (tiStepNumber == 2) {
                        NavigateFromOneToTwo();
                    } else if(tiStepNumber == 3){
                        NavigateFromOneToThree();
                    }
                } else if (CurrentStep == 2) {
                    if (tiStepNumber == 3) {
                        NavigateFromTwoToThree();
                    } else if(tiStepNumber == 1) {
                        NavigateToNewStep(1);
                    }
                }
            } else if(tiStepNumber < CurrentStep) {
                // IF status is completed validate the page I am on is ok. Then save
                    NavigateToNewStep(tiStepNumber);
            }
        }

        public void NavigateToNewStep(Int64 tiStepNumber) {
            IsSubmitted = true;
            AddUpdateCreateListingDTO();
            ChangeStep(tiStepNumber);
        }

        public void ChangeStep(Int64 tiArrowNumber) {
            IsSubmitted = false;   
            this.CurrentStep = tiArrowNumber;
        }
        
        public void SetActiveArrow() {
            if (ListingDTO.lkpListingSetupStatusOid != null && ListingDTO.lkpListingSetupStatusOid != 0) {
                if (ListingDTO.lkpListingSetupStatusOid == StepOneOid) {
                    this.CurrentStep = 1;
                }
                if (ListingDTO.lkpListingSetupStatusOid == StepTwoOid) {
                    this.CurrentStep = 2;
                }
                if (ListingDTO.lkpListingSetupStatusOid == StepThreeOid) {
                    this.CurrentStep = 3;
                }
                if (ListingDTO.lkpListingSetupStatusOid == CompleteOid) {
                    this.CurrentStep = 1;
                }
            }
        }

        #region Validation
        public string IsFirstStepValid() {
            IsSubmitted = true;
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(ListingDTO.Zip)) {
                sb.Append("A Zip Code is required to proceed <br>");
            }
            if (string.IsNullOrEmpty(ListingDTO.CompanyName)) {
                sb.Append("A Business Name is required to proceed <br>");
            }
            if (ListingDTO.lkpCountryOid == null) {
                sb.Append("A Country is required to proceed <br>");
            }
            if (string.IsNullOrEmpty(ListingDTO.Address)) {
                sb.Append("A Street Address is required to proceed <br>");
            }
            if (string.IsNullOrEmpty(ListingDTO.ContactEmail)) {
                sb.Append("A Contact Email Address is required to proceed <br>");
            }
            return sb.ToString();
        }

        public string IsSecondStepValid() {
            IsSubmitted = true;
            StringBuilder sb = new StringBuilder();
            if (ListingDTO.ListingPrice == null || ListingDTO.ListingPrice == 0) {
                sb.Append("An Asking Price is required to proceed <br>");
            }
            if (ListingDTO.GrossRevenue == null || ListingDTO.GrossRevenue == 0) {
                sb.Append("Gross Revenue is required to proceed <br>");
            }
            if (ListingDTO.CashFlow == null || ListingDTO.CashFlow == 0) {
                sb.Append("Cash Flow is required to proceed <br>");
            }
            if (ListingDTO.IsSellerFinanace == null) {
                sb.Append("Please select whether or not you are financed to proceed <br>");
            }
            return sb.ToString();
        }

        public string IsThirdStepValid() {
            IsSubmitted = true;
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(ListingDTO.AdTitle)) {
                sb.Append("An Ad Title is required to proceed <br>");
            }
            if (string.IsNullOrEmpty(ListingDTO.AdTagLine)) {
                sb.Append("A Tag Line is required to proceed <br>");
            }
            if (string.IsNullOrEmpty(ListingDTO.AdDescription)) {
                sb.Append("A Business Opportunity Description is required to proceed <br>");
            }
            return sb.ToString();
        }
        #endregion (Validation)

        #endregion (Methods)

        #region Properties
        public ListingDTO ListingDTO { get => _listingDTO; set => _listingDTO = value; }
        public Int64 CurrentStep { get => _currentStep; set => _currentStep = value; }
        public Int64 StepOneOid { get => _stepOneOid; }
        public Int64 StepTwoOid { get => _stepTwoOid; }
        public Int64 StepThreeOid { get => _stepThreeOid; }
        public Int64 CompleteOid { get => _completeOid; }
        public bool IsSubmitted { get => _isSubmitted; set => _isSubmitted = value; }
        #endregion (Properties)

    }
}
