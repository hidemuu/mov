import React from "react";
import useRegionTrendLineChart from "domains/statistics/hooks/useRegionTrendLineChart";
import { IRegionTrendResponse } from "stores/resas/types/trends/IRegionTrendResponse";
import { RegionTrendLineChart } from "..";

export declare type HighRegionTrendLineChartProps = {
  regionTrend: IRegionTrendResponse[];
};

export const HighRegionTrendLineChart = (props: HighRegionTrendLineChartProps) => {
  const option = useRegionTrendLineChart(props.regionTrend);

  return <RegionTrendLineChart chartOption={option} chartType="high" />;
};
