import { ILineChartOption } from "components/atoms/Chart/types/ILineChartOption";
import { ILineSeries } from "components/atoms/Chart/types/ILineSeries";
import { IRegionTrendResponse } from "stores/resas/types/trends/IRegionTrendResponse";

export class RegionTrendLine {
  private trend: IRegionTrendResponse[];

  private chartOptions: ILineChartOption = {
    title: "",
    series: [],
    xAxis: {
      title: "",
      categories: [],
    },
    yAxis: {
      title: "",
      categories: [],
    },
  };

  constructor(trend: IRegionTrendResponse[]) {
    this.trend = trend;
  }

  public getChart() {
    const series: ILineSeries[] = [];
    const categories = [];
    let count = 0;
    for (const regionTrend of this.trend) {
      const data = [];
      for (const trendLine of regionTrend.data) {
        if (count === 0) {
          categories.push(String(trendLine.number));
        }
        data.push(trendLine.value);
      }
      const prefName = regionTrend.region.prefName;
      const cityName = regionTrend.region.cityName;
      series.push({
        name: prefName + "-" + cityName,
        data: data,
      });
      count++;
    }

    this.chartOptions = {
      title: "",
      series: series,
      xAxis: {
        title: "",
        categories: categories,
      },
      yAxis: {
        title: "",
        categories: [],
      },
    };
    return this.chartOptions;
  }
}
