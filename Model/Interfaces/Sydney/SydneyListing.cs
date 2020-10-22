using System;
using System.Collections.Generic;
using System.Text;

using CommonUtil;

namespace Model.Interfaces.Sydney {

    public class SydneyListingRecordRootObject {
        public SydneyListing[] Property1 { get; set; }
    }

    public class SydneyListing {

        public void Save() {
            // TODO Get the record by External ID WHERE ExternalSystem = "Sydney"
            Listing oListing = null;
            oListing.ExternalId = id; // Which One? - this or the next line?
            //?? oListing.ExternalId = c_listing_number__c;
            string sSydneyListingNumber = c_listing_number__c;
            oListing.ExternalSystem = "Sydney";
            oListing.SellerName = c_Seller;
            string sImageUrl = c_website_listing_image__c;
            // AssignedTo
            oListing.RealEstateValue = Convert.ToDecimal(c_RealEstateValue);
            oListing.RealEstateAskingPrice = Convert.ToDecimal(c_RealEstateAskingPrice);
            // RealEstateValue
            oListing.IsInventoryIncluded = (c_Inventory_Included_c.Equals("1"));
            oListing.AdTitle = c_ad_headline__c;
            oListing.AdDescription = c_business_description__c;
            oListing.AdBusinessHistory = c_business_history__c;
            oListing.HoursOfOperation = c_business_hours_of_operation__c;

            oListing.ListingPrice = Convert.ToDecimal(c_listing_price__c);
            oListing.CashFlow = string.IsNullOrEmpty(c_cash_flow__c.ToString()) ? decimal.Zero : Convert.ToDecimal(c_cash_flow__c);
            oListing.FFandE = Convert.ToDecimal(c_ff_e_value__c);
            oListing.ListingDate = DateTime.UtcNow;
            // DateFunction.EpochToDate(c_client_agreement_date__c);
            oListing.AdCompetitiveAnalysis = c_competitive_overview__c;
            oListing.COGs = Convert.ToDecimal(c_cost_of_goods_sold__c);
            oListing.lkpCountryOid = LookupManager.Instance.GetOidByLookupNameAndValue("Country",c_country__c);
           // oListing.Zip = c_ttl_postal_zip_code__c; // In documentation but not in file
           // oListing.Zip = c_zipcode;// In documentation but not in file
            oListing.lkpLegalEntityTypeOid = GetLegalEntityTypeFromString(c_form_of_ownership__c);
            oListing.Inventory = Convert.ToDecimal(c_inventory_value__c);
            oListing.Rent = Convert.ToDecimal(c_monthly_rent__c);
            oListing.AdOpportunityForGrowth = c_potential_growth__c;
            oListing.AdReasonForSelling = c_reason_for_sale__c;
            oListing.RealEstateIncluded_Int = Convert.ToInt32(c_real_estate_available__c) + 1; // radio buttons are 1 based so "0" will be converted to 1 
            oListing.EmployeeCount = Convert.ToInt32(c_of_employees__c);
            oListing.IsRealEstateInPrice = (c_real_estate_included__c.Equals("1"));
            oListing.IsRelocatable = ConvertToBool(c_relocatable);
            oListing.CashFlow = Convert.ToDecimal(c_seller_discretionary_earnings__c);
            oListing.ShowCashFlow_Int = 1;
            // oListing.SqFt = Convert.ToInt32(c_square_footage__c);
            oListing.GrossRevenue = Convert.ToDecimal(c_total_sales__c);
            oListing.CompanyName = name;
            string sState = c_state__c;
            decimal dTotalAssets = Convert.ToDecimal(c_total_assets__c);
            string sCategory = c_subcategory_1__c;
            int iEE_FullTime = Convert.ToInt32(c_of_employees_ft__c);
            int iEE_PartTime = Convert.ToInt32(c_of_employees_pt__c);

            string sRealPropertyValue = c_related_real_property_value;
            string sGeneralLocationShortName = c_office_location_shortname__c;
            string sFranchisee = c_franchisee__c;
            //string sGeneralLocation = c_general_location_c; // See if Sydney has a control list of General Locations
            string sFfeValue = c_ff_e_value__c; // in file but not in documentation
            string sff_e_included = c_ff_e_included;// in file but not in documentation
            string sSydneyAgentId = c_employee__c;
            string sSydneyLastModifiedBy = assignedTo;
            string sCounty = c_county__c; // Lookup off of Zip if we find it
            string tWorldListingUrl = c_listing_url__c;
            decimal dNetIncome = Convert.ToDecimal(c_net_income__c);
        
        }
        private bool ConvertToBool(string tsInput) {
            return tsInput.Equals("1");
        }
        public Int64 GetLegalEntityTypeFromString(string tsValue) {
            Int64 iReturn = -1;

            return iReturn;
        }

        #region Properties
        public string assignedTo { get; set; }
        public string createDate { get; set; }
        public string c_accounts_receivable { get; set; }
        public string c_accounts_receivable_incl { get; set; }
        public string c_address { get; set; }
        public string c_Address_2 { get; set; }
        public object c_adjusted_net_income__c { get; set; }
        public string c_ad_headline__c { get; set; }
        public string c_agency_type__c { get; set; }
        public object c_agent_or_franchisee_listing__c { get; set; }
        public string c_agent_promoted { get; set; }
        public object c_agreement_template_id__c { get; set; }
        public string c_agreement_type__c { get; set; }
        public object c_api_created__c { get; set; }
        public object c_appraisal__c { get; set; }
        public string c_assumable_financing_amount__c { get; set; }
        public object c_assumable_financing_interest__c { get; set; }
        public string c_assumable_financing_monthly_payment__c { get; set; }
        public object c_assumable_financining_term_months__c { get; set; }
        public object c_assumable_mortgage__c { get; set; }
        public object c_auto_number__c { get; set; }
        public string c_beneficial_addbacks__c { get; set; }
        public object c_bli_template_id__c { get; set; }
        public object c_businessfranchisee__c { get; set; }
        public string c_business_description__c { get; set; }
        public string c_business_history__c { get; set; }
        public object c_business_hours_of_operation { get; set; }
        public string c_business_hours_of_operation__c { get; set; }
        public string c_business_phone__c { get; set; }
        public string c_business_website__c { get; set; }
        public object c_buyer_desired_maximum_price__c { get; set; }
        public object c_buyer_desired_minimum_price__c { get; set; }
        public object c_buyer_email__c { get; set; }
        public object c_buyer_listing__c { get; set; }
        public string c_buyer_phone__c { get; set; }
        public object c_buyer_preference__c { get; set; }
        public object c_buyer_property_types_desired__c { get; set; }
        public object c_buyer_s_business_objective__c { get; set; }
        public object c_buyer_tenant_criteria__c { get; set; }
        public object c_cash_flow__c { get; set; }
        public object c_category_details__c { get; set; }
        public object c_category_id__c { get; set; }
        public string c_category__c { get; set; }
        public object c_checktrue__c { get; set; }
        public object c_check_for_matched_listings__c { get; set; }
        public string c_city__c { get; set; }
        public string c_client_agreement_date__c { get; set; }
        public string c_client_agreement_expires__c { get; set; }
        public object c_client_details__c { get; set; }
        public string c_client_status__c { get; set; }
        public object c_comment1__c { get; set; }
        public object c_comment2__c { get; set; }
        public object c_comment3__c { get; set; }
        public object c_comment4__c { get; set; }
        public string c_comments__c { get; set; }
        public object c_commisionrates__c { get; set; }
        public string c_commission_rate__c { get; set; }
        public string c_company_represented__c { get; set; }
        public string c_competitive_overview__c { get; set; }
        public object c_contact_represented_title__c { get; set; }
        public string c_contact_represented__c { get; set; }
        public string c_cost_of_goods_sold__c { get; set; }
        public string c_cost_of_training__c { get; set; }
        public string c_country__c { get; set; }
        public string c_county__c { get; set; }
        public object c_createdbyid { get; set; }
        public object c_createddate { get; set; }
        public string c_cross_street__c { get; set; }
        public object c_currencyisocode { get; set; }
        public string c_data_source__c { get; set; }
        public string c_data_year__c { get; set; }
        public object c_date_listing_closed_sold__c { get; set; }
        public object c_date_listing_went_active__c { get; set; }
        public object c_date_of_last_physical_count__c { get; set; }
        public string c_deal_stage__c { get; set; }
        public string c_deprecation__c { get; set; }
        public object c_distressed__c { get; set; }
        public object c_docs { get; set; }
        public object c_down_payment_formula__c { get; set; }
        public object c_down_payment_maximum__c { get; set; }
        public object c_down_payment_minimum__c { get; set; }
        public string c_down_payment_requested__c { get; set; }
        public object c_ebitda__c { get; set; }
        public object c_emailnotification__c { get; set; }
        public string c_email_count__c { get; set; }
        public object c_email_date__c { get; set; }
        public object c_employee_office_active_status__c { get; set; }
        public string c_employee__c { get; set; }
        public object c_expiration_date__c { get; set; }
        public object c_external_id__c { get; set; }
        public string c_facilities_c { get; set; }
        public object c_featured__c { get; set; }
        public string c_featureOnProfile { get; set; }
        public string c_fees_and_retainers_c { get; set; }
        public string c_ff_e_general_condition__c { get; set; }
        public string c_ff_e_included { get; set; }
        public string c_ff_e_overview__c { get; set; }
        public object c_ff_e_required_for_operations__c { get; set; }
        public string c_ff_e_value__c { get; set; }
        public object c_folio_number__c { get; set; }
        public string c_form_of_ownership__c { get; set; }
        public object c_franchisee_office_number__c { get; set; }
        public string c_franchisee_operation__c { get; set; }
        public string c_franchisee__c { get; set; }
        public object c_franchisor__c { get; set; }
        public string c_general_location__c { get; set; }
        public object c_geolocation__c { get; set; }
        public object c_geolocation__latitude__s { get; set; }
        public object c_geolocation__longitude__s { get; set; }
        public object c_google_maps_formula__c { get; set; }
        public string c_google_maps_url__c { get; set; }
        public string c_GrossCommission { get; set; }
        public object c_gross_sales_maximum__c { get; set; }
        public object c_gross_sales_minimum__c { get; set; }
        public string c_home_based { get; set; }
        public object c_industries_interested__c { get; set; }
        public object c_industry__c { get; set; }
        public object c_initial_investment_available__c { get; set; }
        public string c_interestedInFinancing { get; set; }
        public string c_interest__c { get; set; }
        public string c_Inventory_Included_c { get; set; }
        public object c_inventory_summary__c { get; set; }
        public string c_inventory_value__c { get; set; }
        public object c_isemployee_active__c { get; set; }
        public object c_landlord_paid_ti__c { get; set; }
        public object c_land_dimensions__c { get; set; }
        public object c_lastactivitydate { get; set; }
        public object c_lastmodifiedbyid { get; set; }
        public object c_lastmodifieddate { get; set; }
        public object c_lastreferenceddate { get; set; }
        public object c_lastvieweddate { get; set; }
        public object c_latitude__c { get; set; }
        public object c_lawsuits_explanation__c { get; set; }
        public object c_lawsuits_pending__c { get; set; }
        public string c_lead_generated_by { get; set; }
        public string c_lead_source__c { get; set; }
        public object c_leasable_square_feet__c { get; set; }
        public string c_leasehold_improvements_incl { get; set; }
        public string c_leasehold_improvements__c { get; set; }
        public string c_lease_expiration_date__c { get; set; }
        public object c_legal_description__c { get; set; }
        public string c_lender_prequalified__c { get; set; }
        public object c_lid__c { get; set; }
        public object c_listedproperty__c { get; set; }
        public object c_listed_business__c { get; set; }
        public object c_listingmonths__c { get; set; }
        public object c_ListingPipeline { get; set; }
        public object c_listing_cap_rate__c { get; set; }
        public object c_listing_category__c { get; set; }
        public object c_listing_city_formula__c { get; set; }
        public object c_listing_found_if_any__c { get; set; }
        public object c_listing_imagetemp__c { get; set; }
        public string c_listing_image__c { get; set; }
        public string c_listing_number__c { get; set; }
        public string c_listing_price__c { get; set; }
        public object c_listing_primary_imagetemp__c { get; set; }
        public object c_listing_primary_image_view__c { get; set; }
        public string c_listing_primary_image__c { get; set; }
        public string c_listing_status__c { get; set; }
        public string c_listing_url__c { get; set; }
        public object c_location_desired_notes__c { get; set; }
        public object c_longitude__c { get; set; }
        public object c_loop_id__c { get; set; }
        public object c_loop_template__c { get; set; }
        public object c_marketing_agreement_date__c { get; set; }
        public object c_medical_office_info__c { get; set; }
        public string c_miles_seller_not_to_compete_within__c { get; set; }
        public string c_minimum_commission__c { get; set; }
        public object c_minimum_sde_reqiured__c { get; set; }
        public object c_min_years__c { get; set; }
        public object c_monthly_gross_rental_income__c { get; set; }
        public object c_monthly_mortgage_payment__c { get; set; }
        public object c_monthly_payroll__c { get; set; }
        public string c_monthly_rent__c { get; set; }
        public object c_mortgage_interest_rate__c { get; set; }
        public object c_myteam__c { get; set; }
        public string c_my_net_commission_split__c { get; set; }
        public string c_my_net_commission__c { get; set; }
        public object c_NAICSDescription { get; set; }
        public string c_net_income__c { get; set; }
        public object c_net_operating_income__c { get; set; }
        public object c_non_compete_months__c { get; set; }
        public object c_notes__c { get; set; }
        public string c_number_of_days_listed__c { get; set; }
        public object c_number_of_days_since_created__c { get; set; }
        public string c_number_of_employees_mgrs__c { get; set; }
        public string c_office_location_shortname__c { get; set; }
        public string c_office_number__c { get; set; }
        public string c_of_employees_ft__c { get; set; }
        public string c_of_employees_pt__c { get; set; }
        public string c_of_employees__c { get; set; }
        public object c_of_total_sales_from_online__c { get; set; }
        public string c_of_weeks_seller_will_offer_training__c { get; set; }
        public string c_of_years_seller_not_to_compete_for__c { get; set; }
        public object c_old_listing_number__c { get; set; }
        public object c_operating_expenses__c { get; set; }
        public string c_other_assets_incl { get; set; }
        public string c_other_assets__c { get; set; }
        public object c_other_city__c { get; set; }
        public object c_other_country__c { get; set; }
        public object c_other_county__c { get; set; }
        public string c_other_financing_amount__c { get; set; }
        public object c_other_financing_interest__c { get; set; }
        public string c_other_financing_monthly_payment__c { get; set; }
        public string c_other_financing_term_months__c { get; set; }
        public object c_other_state__c { get; set; }
        public string c_other__c { get; set; }
        public object c_ownerid { get; set; }
        public object c_owner_benefit_max__c { get; set; }
        public object c_owner_benefit_min__c { get; set; }
        public object c_owner_financing_amount__c { get; set; }
        public string c_owner_financing_interest__c { get; set; }
        public string c_owner_financing_monthly_payment__c { get; set; }
        public string c_owner_financing_terms_months__c { get; set; }
        public string c_owner_financing_terms__c { get; set; }
        public object c_owner_s_financing_terms__c { get; set; }
        public string c_owner_s_salary__c { get; set; }
        public string c_owner_weekly_hours__c { get; set; }
        public string c_own_or_lease_c__c { get; set; }
        public string c_postalcode { get; set; }
        public object c_potential_buyer_email__c { get; set; }
        public object c_potential_buyer__c { get; set; }
        public string c_potential_growth__c { get; set; }
        public object c_preferred_lease__c { get; set; }
        public object c_previous_business_ownership__c { get; set; }
        public object c_previous_employment__c { get; set; }
        public string c_probability_of_closing__c { get; set; }
        public string c_probability_pipeline__c { get; set; }
        public object c_procuring_broker_firstname__c { get; set; }
        public object c_procuring_broker_lastname__c { get; set; }
        public string c_procuring_broker__c { get; set; }
        public string c_promoted__c { get; set; }
        public object c_property_type_required__c { get; set; }
        public object c_publicHash { get; set; }
        public string c_RealEstateAskingPrice { get; set; }
        public string c_RealEstateValue { get; set; }
        public string c_real_estate_available__c { get; set; }
        public string c_real_estate_included__c { get; set; }
        public string c_reason_for_sale__c { get; set; }
        public object c_recordtypeid { get; set; }
        public object c_record_type_id__c { get; set; }
        public string c_referralfee { get; set; }
        public string c_referredBy { get; set; }
        public object c_related_lease__c { get; set; }
        public string c_related_real_property_value { get; set; }
        public object c_related_real_property_value__c { get; set; }
        public object c_related_real_property__c { get; set; }
        public string c_relocatable { get; set; }
        public string c_relocatable__c { get; set; }
        public string c_remove_from_website__c { get; set; }
        public object c_rent_formula__c { get; set; }
        public object c_reserves__c { get; set; }
        public object c_SALESFORCEID { get; set; }
        public string c_Seller { get; set; }
        public string c_seller_discretionary_earnings__c { get; set; }
        public string c_Seller_Financing_Available_c { get; set; }
        public object c_serial_number__c { get; set; }
        public string c_showing_comments__c { get; set; }
        public string c_showing_instructions__c { get; set; }
        public object c_show_on_agent__c { get; set; }
        public object c_show_on_franchise__c { get; set; }
        public object c_sic_code__c { get; set; }
        public object c_sic_description__c { get; set; }
        public object c_sic_main_category_classification__c { get; set; }
        public object c_site_url__c { get; set; }
        public object c_site__c { get; set; }
        public string c_sold_price__c { get; set; }
        public object c_source_of_initial_investment__c { get; set; }
        public string c_square_footage__c { get; set; }
        public string c_state__c { get; set; }
        public string c_subcategory_1__c { get; set; }
        public string c_subcategory_2__c { get; set; }
        public string c_subcategory_3__c { get; set; }
        public string c_subcategory_4__c { get; set; }
        public object c_sub_category_name__c { get; set; }
        public object c_tenant_maximum_per_sf__c { get; set; }
        public object c_tenant_max_monthly_rent__c { get; set; }
        public object c_tenant_sq_ft_required__c { get; set; }
        public string c_terms_options__c { get; set; }
        public object c_term_months__c { get; set; }
        public object c_test_field__c { get; set; }
        public object c_this_is_an_investment_property__c { get; set; }
        public object c_this_property_is_in_default_bank_owned__c { get; set; }
        public object c_this_property_is_up_for_auction__c { get; set; }
        public object c_this_property_is_vacant_or_best_suited_f__c { get; set; }
        public string c_ThroPro { get; set; }
        public object c_time_buyer_spent_looking__c { get; set; }
        public object c_ti_allowance__c { get; set; }
        public string c_tom_marketing_status__c { get; set; }
        public string c_total_assets__c { get; set; }
        public object c_total_commission_percentage__c { get; set; }
        public string c_total_commission__c { get; set; }
        public string c_total_expenses__c { get; set; }
        public string c_total_sales__c { get; set; }
        public string c_training_support_included__c { get; set; }
        public object c_ttl_business_address__c { get; set; }
        public object c_ttl_business_country__c { get; set; }
        public object c_ttl_business_postal_zip_code__c { get; set; }
        public object c_ttl_business_state_province__c { get; set; }
        public object c_ttl_city__c { get; set; }
        public object c_ttl_county__c { get; set; }
        public object c_ttl_listing_city__c { get; set; }
        public object c_ttl_listing_country__c { get; set; }
        public object c_ttl_listing_county__c { get; set; }
        public object c_ttl_listing_postal_zip_code__c { get; set; }
        public object c_ttl_listing_state_province__c { get; set; }
        public object c_type_of_business_desired__c { get; set; }
        public string c_type_of_location__c { get; set; }
        public object c_under_construction_proposed__c { get; set; }
        public string c_url_formula__c { get; set; }
        public string c_value_added_tax__c { get; set; }
        public object c_value_of_inventory_wholesale__c { get; set; }
        public string c_vat_included_in_listing_price__c { get; set; }
        public object c_wants_absentee_ownership__c { get; set; }
        public object c_wants_franchisee_operation__c { get; set; }
        public object c_wants_real_property_included__c { get; set; }
        public object c_wants_relocatable_business__c { get; set; }
        public string c_website_has_image__c { get; set; }
        public string c_website_listing_image__c { get; set; }
        public object c_will_consider_locations__c { get; set; }
        public object c_wordpress_agent_city__c { get; set; }
        public object c_wordpress_agent_county__c { get; set; }
        public object c_wordpress_agent_name__c { get; set; }
        public object c_wordpress_custom_sort_order__c { get; set; }
        public object c_wordpress_listing_active_status__c { get; set; }
        public object c_wordpress_listing_custom_sort__c { get; set; }
        public object c_wordpress_listing_delete_status__c { get; set; }
        public object c_wordpress_related_locations__c { get; set; }
        public object c_wordpress_site_shortname__c { get; set; }
        public object c_wp_listings_relatedlocations__c { get; set; }
        public object c_wp_listing_customsort__c { get; set; }
        public object c_x1031_exchange__c { get; set; }
        public object c_x18_digit_salesforce_id__c { get; set; }
        public string c_years_owned__c { get; set; }
        public object c_year_built__c { get; set; }
        public string c_year_established__c { get; set; }
        public object c_year_in_business__c { get; set; }
        public object c_youtubelink__c { get; set; }
        public object c_zoning__c { get; set; }
        public object description { get; set; }
        public string id { get; set; }
        public string lastActivity { get; set; }
        public string lastUpdated { get; set; }
        public string name { get; set; }
        public string nameId { get; set; }
        public string sharedTo { get; set; }
        public string updatedBy { get; set; }
        #endregion (Properties)

    }
}