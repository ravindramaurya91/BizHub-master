using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Components;
using Model;

namespace BizHub.Components.AccountComponents {
    public partial class CmpUserProfileWebPresence {

        #region Fields
        private List<NameValuePair> _urls = new List<NameValuePair>();
        #endregion(Fields)

        #region Methods
        protected override void OnInitialized() {
            if (Urls.Count == 0) {
                Urls.Add(new NameValuePair() { Name = "", Value = "" });
            }
        }

        public void RemoveUrl(NameValuePair toPair) {
            if (ActiveUrlCount == 1) {
                toPair.Name = "";
                toPair.Value = "";
            } else {
                toPair.DeleteMe = true;
            }
        }

        public void AddUrl() {
            Urls.Add(new NameValuePair() { Name = "", Value = "" });
        }

        public Int64 GetUrlCount() {
            Int64 iReturn = 0;
            foreach (NameValuePair Url in Urls) {
                if (!Url.DeleteMe) {
                    iReturn++;
                }
            }

            return iReturn;
        }
        #endregion(Methods)

        #region Properties
        [Parameter]
        public List<NameValuePair> Urls { get => _urls; set => _urls = value; }

        public Int64 ActiveUrlCount { get => GetUrlCount(); }

        #endregion(Properties)

    }
}
