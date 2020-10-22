using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class FSVisualItem {

        #region Properties
        public string Label { get; set; }

        public string Value { get; set; }

        public string ElementName { get; set; }

        public List<FSVisualItem> Items { get; set; } = new List<FSVisualItem>();

        public string CustomCSS { get; set; }

        public string IconCSS { get; set; }

        public string ToolTipContent { get; set; }
        #endregion (Properties)


    }
}
