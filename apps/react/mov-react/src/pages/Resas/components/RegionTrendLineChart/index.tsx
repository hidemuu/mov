import React, { FC } from "react";
import useRegionTrendLineChart from "domains/statistics/hooks/useRegionTrendLineChart";
import { IRegionTrendResponse } from "stores/resas/types/trends/IRegionTrendResponse";
import { HighLineChart } from "components/atoms/Chart/containers/HighLineChart";
import { FluentLineChart } from "components/atoms/Chart/containers/FluentLineChart";

export declare type RegionTrendLineChartProps = {
  regionTrend: IRegionTrendResponse[];
  chartType: string;
};

export const RegionTrendLineChart: FC<RegionTrendLineChartProps> = ({ regionTrend, chartType }) => {
  const option = useRegionTrendLineChart(regionTrend);

  return (
    <div>
      {chartType === "high" && <HighLineChart option={option} />}
      {chartType !== "high" && <FluentLineChart option={option} />}
    </div>
  );
};
