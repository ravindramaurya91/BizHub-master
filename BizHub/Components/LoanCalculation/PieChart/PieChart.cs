using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Syncfusion.Blazor.Charts;

using Model;

namespace BizHub.Components.LoanCalculation.PieChart {
    public partial class PieChart {

        public void TooltipRender(ITooltipRenderEventArgs Args) {
            string yValue = String.Format("{0:n}", Args.Data.PointY);
            Args.Text = "$" + yValue;
        }

        #region Properties
        [Parameter] public IPieChartController Controller { get; set; }
        public List<FSPieChartModel> ChartData { get => Controller.ChartData; set => Controller.ChartData = value; }
        public SfAccumulationChart ChartRef { get => Controller.PieChartRef; set => Controller.PieChartRef = value; }

        public int StartAngle = 0, value = 0, EndAngle = 360, radiusValue = 80, exploderadius = 15;
        public string OuterRadius = "80%", ExplodeRadius = "15%";
        public double ExplodeIndex = 1;

        public AccumulationChartTooltipSettings o { get; set; }
        #endregion (Properties)

    }
}
