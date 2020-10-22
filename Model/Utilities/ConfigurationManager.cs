using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class ConfigurationMgr {

        #region Fields
        private static object _syncRoot = new Object(); //for multi thread protection
        private static volatile ConfigurationMgr _instance = null;
        private List<Configuration> _configurations = new List<Configuration>();
        #endregion (Fields)    

        #region Constructor 
        static ConfigurationMgr() {
        }
        #endregion (Constructor)
        public Configuration AddEntry(string tsContext, string tsValue) {
            Configuration oConfig = new Configuration() { Name = tsContext, DataType = "System.String", ModuleName = "Mercado", Value = tsValue, Description = "" };
            oConfig.Save();
            return oConfig;
        }
        public Configuration GetRecordByName(string tsName, bool tbThrowErrorOnNull = false) {
            Configuration oReturn = null;
            foreach (Configuration oConfig in _configurations) {
                if (oConfig.Name.Equals(tsName)) {
                    oReturn = oConfig;
                    break;
                }
            }

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"No entry for Mercado found in the Configurtation table where name = [{tsName}]");
            }
            return oReturn;
        }
        public void UpdateRecord(string tsName, string tsModuleName, string tsValue, bool tbThrowErrorOnNull = false) {
            Configuration oRecord = GetRecordByName(tsName, tsModuleName, tbThrowErrorOnNull);
            if(oRecord != null) {
                oRecord.Value = tsValue;
                oRecord.Save();
            }
        }
        public Configuration GetRecordByName(string tsName, string tsModuleName, bool tbThrowErrorOnNull = false) {
            Configuration oReturn = null;
            foreach (Configuration oConfig in _configurations) {
                if (oConfig.Name.Equals(tsName) && (oConfig.ModuleName.Equals(tsModuleName))) {
                    oReturn = oConfig;
                    break;
                }
            }

            if (oReturn == null && tbThrowErrorOnNull) {
                throw new Exception($"No entry for Mercado found in the Configurtation table where name = [{tsName}] and ModuleName = [{tsModuleName}]");
            }
            return oReturn;
        }
        public string GetValueByName(string tsName) {
            return GetValueByName(tsName, false);
        }
        public string GetValueByName(string tsName, bool tbThrowErrorIfNotFound) {
            string sReturn = "";
            foreach (Configuration oConfig in _configurations) {
                if (oConfig.Name.Equals(tsName)) {
                    sReturn = oConfig.Value;
                    break;
                }
            }

            if ((String.IsNullOrEmpty(sReturn) && tbThrowErrorIfNotFound)) {
                throw new Exception("No match in the Configuration table where Name = [" + tsName + "]");
            }
            return sReturn;
        }

        #region Properties
        public static ConfigurationMgr Instance {
            get {
                if (_instance == null) {
                    lock (_syncRoot) {
                        _instance = new ConfigurationMgr();
                        _instance.Configurations = Configuration.Fetch("");
                    }
                }
                return _instance;
            }
        }
        public List<Configuration> Configurations {
            get { return _configurations; }
            set { _configurations = value; }
        }
        #endregion (Properties)
    }
}
