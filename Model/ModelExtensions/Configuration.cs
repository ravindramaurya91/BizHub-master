using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public partial class Configuration {

        #region Fields
        /// <summary>
        /// Logger interface. This will output to Log2Console.
        /// </summary>
        private static Logger _log = LogManager.GetCurrentClassLogger();
        #endregion( Fields )

        #region Methods
        /// <summary>
        /// Add a value to the configuration table. Generic type allows
        /// for any kind of data value you want, turned into a string.
        /// 
        /// The the config alredy exists, its value is updated.
        /// </summary>
        /// <param name="key">The key the data is associated with</param>
        /// <param name="value">The value we want to use.</param>
        /// <param name="moduleName">Name of the module this config belongs to.</param>
        /// <returns></returns>
        public static bool SetConfig(string key, object value, string moduleName, string description) {
            /**
             * 1) Valdate the parameters.
             * 2) Make sure that the key dosent exist.
             * 3) If it does exist update value.
             * 4) If it does NOT exist, then add it.
             */

            if (string.IsNullOrEmpty(key) == true) {
                return false;
            }

            var conf = Configuration.FirstOrDefault("WHERE [Name] = @", key);
            if (conf != default(Configuration) && conf.Value != value.ToString()) {
                // Update the object with the new value.
                conf.Value = value.ToString();
                conf.DataType = value.GetType().ToString();
                conf.ModuleName = moduleName;
                conf.Description = description;

                // Save the updates to the database.
                conf.Save();
                return true;
            }

            // Save a new configuration object.
            var newConf = new Configuration() {
                Name = key,
                Value = value.ToString(),
                DataType = value.GetType().ToString(),
                ModuleName = moduleName,
                Description = description
            };

            newConf.Save();
            return true;
        }

        /// <summary>
        /// Get the configuration from the database.
        /// </summary>
        /// <param name="key">The key associated with the value we want.</param>
        /// <param name="defaultValue">If the key dosen't find anything then this gets returned.</param>
        /// <param name="moduleName">Name of the module this configuration belongs to.If not specified then all get searched.</param>
        /// <returns>Returns an object of the type specified in the database.</returns>
        public static object GetConfig(string key, object defaultValue = null, string moduleName = null) {
            /**
             * 1) Validate the key parameter.
             * 2) Query the database to get the config.
             * 3) Using the DataType field, convert the string value to the correct type.
             */

            if (string.IsNullOrEmpty(key) == true) {
                return defaultValue;
            }

            // Set up our where clause for our query.
            string sWhere = string.Format("WHERE [Name] = @0");
            if (string.IsNullOrEmpty(moduleName) == false) {
                sWhere += string.Format(" AND ([ModuleName] ='{0}' OR [ModuleName] = '')", moduleName);
            }

            var conf = Configuration.FirstOrDefault(sWhere, key);
            if (conf == default(Configuration) || string.IsNullOrEmpty(conf.Value) == true) {
                return defaultValue;
            }

            try {
                // Convert the string into the specified data type.
                return Convert.ChangeType(conf.Value, Type.GetType(conf.DataType));
            } catch (FormatException ex) {
                _log.Error("The type specified does not match, actual type. Verify type in database.");
                //log.Trace("Exception: {0}", ex);
            }

            return defaultValue;
        }

        public static Dictionary<string, object> GetConfigList(string moduleName = null) {
            /**
             * 1) Build the where clause, and check to see if we need to check for module name.
             * 2) Once we got the list, iterate through it and convert the value to the correct data type.
             * 3) Save the data to the dictionary and return it.
             */

            Dictionary<string, object> dicRetVal = new Dictionary<string, object>();

            string sWhere = "";
            if (string.IsNullOrEmpty(moduleName) == false) {
                sWhere = string.Format("WHERE [ModuleName] = '{0}' OR [ModuleName] = ''", moduleName);
            }

            var confList = Configuration.Fetch(sWhere);
            foreach (Configuration conf in confList) {
                if (conf != null && string.IsNullOrEmpty(conf.Value) == false) {
                    // Convert the string to the type, set by DataType.
                    var confVal = Convert.ChangeType(conf.Value, Type.GetType(conf.DataType));
                    if (confVal == null) {
                        continue;
                    }

                    // Add the configuration to the dictionary.
                    dicRetVal.Add(conf.Name, confVal);
                }
            }

            return dicRetVal;
        }

        /// <summary>
        /// Returns true if the configuration exists.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool HasConfig(string key) {
            return (Configuration.FirstOrDefault("WHERE [Name] = @0", key) == default(Configuration)) ? false : true;
        }
        #endregion( Methods )
    }
}
