import { useEffect, useState } from "react";
import { IRegionTrendResponse } from "stores/resas/types/trends/IRegionTrendResponse";
import { ILineChartOption } from "components/atoms/Chart/types/ILineChartOption";
import { RegionTrendLine } from "../models/RegionTrendLine";

export default function useRegionTrendLineChart(
  regionTrend: IRegionTrendResponse[],
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
    const model = new RegionTrendLine(regionTrend);
    setChartOptions(model.getChart());
  }, [regionTrend]);

  return chartOptions;
}
