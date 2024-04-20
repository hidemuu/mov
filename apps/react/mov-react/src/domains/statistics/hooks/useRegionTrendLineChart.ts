import { useEffect, useState } from "react";
import { IRegionTrend } from "stores/resas/types/trends/IRegionTrend";
import { ILineChartOption } from "components/atoms/Chart/types/ILineChartOption";
import { ILineSeries } from "components/atoms/Chart/types/ILineSeries";

export default function useRegionTrendLineChart(
  regionTrends: IRegionTrend[]
): ILineChartOption {
  const [chartOptions, setChartOptions] = useState<ILineChartOption>({
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
  });

  useEffect(() => {
    const series: ILineSeries[] = [];
    const categories = [];
    let count = 0;
    for (const regionTrend of regionTrends) {
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
    setChartOptions({
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
    });
  }, [regionTrends]);

  return chartOptions;
}
