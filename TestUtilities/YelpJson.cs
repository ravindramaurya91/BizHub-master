using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using CommonUtil;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestUtilities {
    public class YelpJson {


        #region Constructor
        public YelpJson() {
            Json = System.IO.File.ReadAllText(@"D:\C# Projects\BizHub\TestUtilities\YelpJson.json");
            List<YelpNode> oJsonObject = FSTools.FromJSON<List<YelpNode>>(Json);

            foreach (YelpNode oNode in oJsonObject) {
                if(oNode.Parent.Length > 0) {
                    Debug.WriteLine("This One;");
                }
            }
        }
        #endregion (Constructor)

        #region Properties
        public string Json { get; set; }
        #endregion (Properties)

    }

    public class YelpNode {
        private string _parent = "";
        public string alias {get;set;}
        public string title { get;set;}
        public string Parent { get => _parent; set => _parent = value; }
    }
}
