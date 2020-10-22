using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Base;
using Model;
using CommonUtil;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using BizHub.Service;

namespace TestUtilities {
   public class ZipCodeUtil {
        #region Setup / Tear down
        [SetUp]
        public void InitializeTestHarness() {
            Initialization.BuildServiceProvider();
        }

        [TearDown]
        public void TearDown() {
            // Noithing to do here
        }

        #endregion Setup / Tear down

        [Test]
        public void Test_01_UpdateZCTableOids() {
            ZC oZip;
            int iCounter = 49057;

            try {
                List<ZC_MultiCounty> oList1 = ZC_MultiCounty.Fetch("");
                foreach (ZC_MultiCounty zcm in oList1) {
                    oZip = ZC.FirstOrDefault("WHERE ZipCode = @0 AND PrimaryRecord = 'P'", zcm.ZipCode);
                    if (oZip != null) {
                        zcm.ZCOid = oZip.Oid;
                        zcm.Save();
                        iCounter++;
                        Debug.WriteLine(iCounter);
                    } else {
                        Debug.WriteLine("Exception");
                    }
                }
                Debug.WriteLine("ZC_MultiCounty Complete");

                iCounter = 0;
                List<ZC_PlaceFIPS> oList2 = ZC_PlaceFIPS.Fetch("");
                foreach (ZC_PlaceFIPS fips in oList2) {
                    oZip = ZC.FirstOrDefault("WHERE ZipCode = @0 AND PrimaryRecord = 'P'", fips.ZipCode);
                    if (oZip != null) {
                        fips.ZCOid = oZip.Oid;
                        fips.Save();
                    } else {
                        Debug.WriteLine("Exception");
                    }

                    iCounter++;
                    Debug.WriteLine(iCounter);

                }

                Debug.WriteLine("ZC_PlaceFIPS Complete");

            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }
        }

        [Test]
        public void Test_02_LoadZipcodeFromZC() {
            ZipCode oZip;
            int iCounter = 0;

            try {
                List<ZC> oList1 = ZC.Fetch("WHERE PrimaryRecord = 'P'");
                foreach (ZC oZC in oList1) {
                    oZip = ZipCode.FirstOrDefault("WHERE Zip = @0", oZC.ZipCode);
                    if (oZip == null) {
                        oZip = new ZipCode() { Zip = oZC.ZipCode, City = oZC.City, County = oZC.County, Latitude = oZC.Latitude, Longitude = oZC.Longitude, State = oZC.State, StateFullName = oZC.StateFullName, TimeZone = oZC.TimeZone };
                        oZip.Save();
                        iCounter++;
                        Debug.WriteLine(iCounter);
                    }
                }

                Debug.WriteLine("ZC Complete");

            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }

        }

        [Test]
        public void Test_03_LoadUniqueAndMultiCountyFromZC() {
            ZipCode oZip;
            int iCounter = 0;
            List<ZC_MultiCounty> oMultiList;
            StringBuilder sb = new StringBuilder();
            Database.GetInstance().Execute("UPDATE ZipCode SET IsUnique = 0, IsMultipleCounties = 0, CountyList = ''");
            try {
                List<ZC> oList1 = Database.GetInstance().Fetch<ZC>("SELECT ZipCode, UniqueZIPName, MultiCounty FROM ZC WHERE MultiCounty = 'Y' OR UniqueZipName = 'Y'", null);
                foreach (ZC oZC in oList1) {
                    oZip = ZipCode.FirstOrDefault("WHERE Zip = @0", oZC.ZipCode);
                    if (oZip != null) {
                        oZip.IsUnique = (oZC.UniqueZIPName.Equals("Y"));

                        if (oZC.MultiCounty.Equals("Y")) {
                            sb.Clear();
                            oMultiList = ZC_MultiCounty.Fetch("WHERE ZipCode = @0", oZip.Zip);
                            foreach (ZC_MultiCounty oMulti in oMultiList) {
                                sb.Append("," + oMulti.County);
                            }
                            oZip.IsMultipleCounties = true;
                            oZip.CountyList = sb.ToString().Substring(1);
                            oZip.Save();
                        }
                        oZip.Save();
                        iCounter++;
                        Debug.WriteLine(iCounter);
                    }
                }

                Debug.WriteLine("ZC Complete");

            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }

        }

        [Test]
        public void Test_04_Load_State_County_City_Lookups() {
            List<ZipCode> oZipCodes = ZipCode.Fetch("");
            try {
                string sStateFullName, sState, sCounty, sCity;
                Lookup oCountryLookup = Lookup.FirstOrDefault("WHERE Oid = @0", 30);
                Lookup oStateLookup = null, oCountyLookup = null, oCityLookup = null;
                int iState = 0, iCounty = 0, iCity = 0, iCounter = 0;

                string sLastState = "", sLastCounty = "", sLastCity = "";

                foreach (ZipCode oZip in oZipCodes) {
                    iCounter++;
                    Debug.WriteLine(iCounter);
                    if (iCounter < 0) {
                        continue;
                    }
                   
                    oZip.lkpCountryOid = oCountryLookup.Oid;

                    if (!string.IsNullOrEmpty(oZip.County)) {
                        // We will ignore the data that does not have a county
                        sStateFullName = oZip.StateFullName.Trim();
                        sState = oZip.State.Trim();
                        sCounty = oZip.County.Trim();
                        sCity = oZip.City.Trim();

                        if (!sState.Equals(sLastState)) {
                            // Check For State
                            oStateLookup = Lookup.FirstOrDefault("WHERE ParentOid = @0 AND LookupName = 'State' AND Value = @1", oCountryLookup.Oid, sStateFullName);
                            if (oStateLookup == null) {
                                iState++;
                                oStateLookup = new Lookup() { ParentOid = oCountryLookup.Oid, LookupDefinitionOid = 10, LookupName = "State", ConstantValue = "STATE->" + sStateFullName.ToUpper().Replace(" ", ""), Value = sStateFullName, Description = sStateFullName, IsActive = true, MetaData = "", SortOrder = iState, UDF1 = sState, UDF2 = "", UDF3 = "", UDF4 = "" };
                                Debug.WriteLine("State = " + sStateFullName);

                                oStateLookup.Save();
                                sLastState = sState;
                            }
                            oZip.lkpStateOid = oStateLookup.Oid;
                        }

                        if (!sCounty.Equals(sLastCounty)) {
                            // Check For County
                            oCountyLookup = Lookup.FirstOrDefault("WHERE ParentOid = @0 AND LookupName = 'County' AND Value = @1", oStateLookup.Oid, sCounty);
                            if (oCountyLookup == null) {
                                iCounty++;
                                oCountyLookup = new Lookup() { ParentOid = oStateLookup.Oid, LookupDefinitionOid = 11, LookupName = "County", ConstantValue = "COUNTY->" + sCounty.ToUpper().Replace(" ", ""), Value = sCounty, Description = sCounty, SortOrder = iCounty, IsActive = true, MetaData = "", UDF1 = sState, UDF2 = "", UDF3 = "", UDF4 = "" };
                                Debug.WriteLine("County = " + sCounty);
                                oCountyLookup.Save();
                                sLastCounty = sCounty;
                            }
                            oZip.lkpCountyOid = oCountyLookup.Oid;
                        }

                        if (!sCity.Equals(sLastCity)) {
                            // Check For City
                            oCityLookup = Lookup.FirstOrDefault("WHERE ParentOid = @0 AND LookupName = 'City' AND Value = @1", oCountyLookup.Oid, sCity);
                            if (oCityLookup == null) {
                                iCity++;
                                oCityLookup = new Lookup() { ParentOid = oCountyLookup.Oid, LookupDefinitionOid = 12, LookupName = "City", ConstantValue = "City->" + sCity.ToUpper().Replace(" ", ""), Value = sCity, Description = sCity, SortOrder = iCity, IsActive = true, MetaData = "", UDF1 = sState, UDF2 = "", UDF3 = "", UDF4 = "" };
                                Debug.WriteLine("City = " + sCity);
                                // oCityLookup.Save();
                                sLastCity = sCity;

                            }
                            oZip.lkpCityOid = oCityLookup.Oid;
                        }
                    }
                    oZip.Save();
                }

                Debug.WriteLine("ZC Complete");

            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }
        }
        [Test]
        public void Test_05_Retrieve_Location_Data_FromZipCode() {
            string sZipCode = "95356";

            try {
                ZipCode oZip = ZipCode.FirstOrDefault("WHERE Zip = @0", sZipCode);
                Debug.WriteLine("oZip");

            } catch (ArgumentException ex) {
                Debug.WriteLine(ex);
            }
        }

        [Test]
        public void Test_06_BackFillStateOidInZipTableWhereNull() {
            try {
                int iCounter = 0;
                //List<ZipCode> oZips = ZipCode.Fetch("WHERE lkpStateOid IS NULL ", 0);
                List<ZipCode> oZips = ZipCode.Fetch("WHERE lkpStateOid IS NULL AND State = @0", "CA");
                Lookup oLookup;

                foreach (ZipCode oZip in oZips) {
                    oLookup = Lookup.FirstOrDefault("WHERE LookupName = 'State' AND UDF1 = @0", oZip.State.Trim());
                    if (oLookup != null) {
                        oZip.lkpStateOid = oLookup.Oid;
                        oLookup = Lookup.FirstOrDefault("WHERE LookupName = 'County' AND ParentOid = @0 AND Value = @1", oZip.lkpStateOid, oZip.County.Trim());
                        if (oLookup != null) {
                            oZip.lkpCountyOid = oLookup.Oid;
                            oLookup = Lookup.FirstOrDefault("WHERE LookupName = 'City' AND ParentOid = @0 AND Value = @1", oZip.lkpCountyOid, oZip.City.Trim());
                            if (oLookup != null) {
                                oZip.lkpCityOid = oLookup.Oid;
                                iCounter++;
                                oZip.Save();
                            }
                        }
                    }
                }
                Debug.WriteLine(iCounter.ToString() + " Records Updated");

            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
