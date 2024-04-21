import { useEffect, useState } from "react";
import { IRegionTrend } from "stores/resas/types/trends/IRegionTrend";
import { ILineChartOption } from "components/atoms/Chart/types/ILineChartOption";
import { RegionTrendLine } from "../models/RegionTrendLine";

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
    const model = new RegionTrendLine(regionTrends);
    setChartOptions(model.getChart());
  }, [regionTrends]);

  return chartOptions;
}
