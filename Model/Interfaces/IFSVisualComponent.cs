using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public interface IFSVisualComponent {

        #region Methods
        void On_Select(string tsValue);
        #endregion (Methods)

        #region Properties
        List<FSVisualItem> Items { get; set; }
        string BoundValue { get; set; }
        EventCallback<string> OnSelect { get; set; }

        #endregion (Properties)

    }

}
