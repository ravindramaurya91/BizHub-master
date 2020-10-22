using System;
using System.Collections.Generic;
using System.Text;

using Syncfusion.Blazor.Charts;

namespace Model {
    public interface IPieChartController {

        #region Methods
        void ConvertDataIntoPieChartData();
        void RefreshPieChart();
        #endregion (Methods)

        #region Properties
        SfAccumulationChart PieChartRef { get; set; }
        List<FSPieChartModel> ChartData { get; set; }
        #endregion (Properties)
    }
}
