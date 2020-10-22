using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

using Model;
using Syncfusion.Blazor.Spinner;

namespace BizHub.FSLibrary.Grid {
    public partial class FSGrid {

        public class OverviewData {
            public OverviewData(string id, string name, string designation, string reportingperson) {
                this.Id = id;
                this.Name = name;
                this.Designation = designation;
                this.ReportingPerson = reportingperson;
            }

            public string Id { get; set; }
            public string Name { get; set; }
            public string Designation { get; set; }
            public string ReportingPerson { get; set; }
        }

        public void GetAllRecords() {
            List<OverviewData> data = new List<OverviewData>();
            data.Add(new OverviewData("parent", "Elizabeth", "Director", ""));
            data.Add(new OverviewData("1", "Christina", "Manager", "parent"));
            data.Add(new OverviewData("2", "Yoshi", "Lead", "1"));
            data.Add(new OverviewData("3", "Philip", "Lead", "1"));
            data.Add(new OverviewData("4", "Yang", "Manager", "parent"));
            data.Add(new OverviewData("5", "Roland", "Lead", "4"));
            data.Add(new OverviewData("6", "Yvonne", "Lead", "4"));
            data.Add(new OverviewData("7", "Christinas", "Manager", "parent"));
            data.Add(new OverviewData("8", "Yoshis", "Lead", "1"));
            data.Add(new OverviewData("9", "Philips", "Lead", "1"));
            data.Add(new OverviewData("10", "Yangs", "Manager", "parent"));
            data.Add(new OverviewData("11", "Rolands", "Lead", "4"));
            data.Add(new OverviewData("12", "Yvonnes", "Lead", "4"));
            GridData = data;
        }

        public int Value { get; set; } = 1000;

        SfSpinner SpinnerObj;

        string target { get; set; } = "#container";
        public class DDData {
            public string Text { get; set; }
            public string Value { get; set; }
        }
        public List<DDData> DLData = new List<DDData>() {
        new DDData(){ Text= "1,000 Rows and 11 Columns", Value= "1000" },
        new DDData(){ Text= "10,000 Rows and 11 Columns", Value= "10000" },
        new DDData(){ Text= "1,00,000 Rows and 11 Columns", Value= "100000" },
    };
        public void Changedata(@Syncfusion.Blazor.DropDowns.ChangeEventArgs<string> args) {
            SpinnerObj.ShowSpinner(target);
            Value = Int32.Parse(args.Value);
            GetAllRecords();
            SpinnerObj.HideSpinner(target);
        }

        protected override void OnInitialized() {
            GetAllRecords();
        }

        #region Properties

        [Parameter]
        //public List<FSVisualItem> GridData { get; set; }
        public List<OverviewData> GridData { get; set; }

        #endregion (Properties)

    }
}
