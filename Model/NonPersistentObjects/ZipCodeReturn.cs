using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Model {
    public class ZipCodeReturn {
        // This class was used in an experiment to pull zip codes from the web - It is not beiong used in the app at this time. 
        // I am holding on to it because the Unit Test which uses it is a good example of how to pull from the web.

        #region Properties
        [JsonPropertyName("post code")]
        public string PostalCode { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("country abbreviation")]
        public string CountryAbbreviation { get; set; }
        [JsonPropertyName("places")]
        public List<ZipCodeReturnPlace> Places { get; set; }
        #endregion (Properties)

    }

    public class ZipCodeReturnPlace {
        #region Properties
        [JsonPropertyName("place name")]
        public string Name { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("state abbreviation")]
        public string StateAbbreviation { get; set; }
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
        public List<ZipCodeReturnPlace> places { get; set; }
        #endregion (Properties)

    }
}
