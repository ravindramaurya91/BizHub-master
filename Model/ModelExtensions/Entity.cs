using CommonUtil;
using System;
using System.Collections.Generic;
using System.Text;

using PetaPoco;

namespace Model {
    public partial class Entity {

        #region Methods
        public static Entity CreateDefaultEntity() {
            DateTime oNowDate = DateTime.UtcNow;
            Entity oEntity = new Entity();

            // Creates a blank User Entity record to satisfy the database
            oEntity.Address1 = "";
            oEntity.Address2 = "";
            oEntity.Zip = "";
            oEntity.City = "";
            oEntity.State = "";
            oEntity.Country = "USA";
            oEntity.IsActive = true;
            oEntity.Preferences = "";
            oEntity.CreatedBy = "";
            oEntity.CreatedOn = oNowDate;
            oEntity.StartDate = oNowDate;

            return oEntity;
        }

        private string GetCityStateFormatted() {
            string sReturn = "";
            if (!string.IsNullOrEmpty(City)) {
                sReturn = City;
                if (!string.IsNullOrEmpty(State)) {
                    sReturn += ", " + State;
                }
            } else if (!string.IsNullOrEmpty(State)) {
                sReturn = State;
            }
            return sReturn;
        }
        #endregion (Methods)


        #region Properties 
        [Ignore]
        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }

        [Ignore]
        public string CityStateFormatted {
            get => GetCityStateFormatted(); 
        }
        #endregion (Properties)
    }
}
