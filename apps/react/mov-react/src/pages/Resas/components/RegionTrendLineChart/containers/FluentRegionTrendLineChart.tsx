import useRegionTrendLineChart from "domains/statistics/hooks/useRegionTrendLineChart";
import React from "react";
import { IRegionTrendResponse } from "stores/resas/types/trends/IRegionTrendResponse";
import { RegionTrendLineChart } from "..";

export declare type FluentRegionTrendLineChartProps = {
  regionTrend: IRegionTrendResponse[];
};

export const FluentRegionTrendLineChart = (props: FluentRegionTrendLineChartProps) => {
  const option = useRegionTrendLineChart(props.regionTrend);

  return <RegionTrendLineChart chartOption={option} chartType="fluent" />;
};
