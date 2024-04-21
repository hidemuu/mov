import React, { FC } from "react";
import useRegionTrendLineChart from "domains/statistics/hooks/useRegionTrendLineChart";
import { IRegionTrend } from "stores/resas/types/trends/IRegionTrend";
import { LineChart } from "components/atoms/Chart/containers/LineChart";

export declare type RegionTrendLineChartProps = {
  trendLines: IRegionTrend[];
};

export const RegionTrendLineChart: FC<RegionTrendLineChartProps> = ({
  trendLines,
}) => {
  const option = useRegionTrendLineChart(trendLines);

  return (
    <div>
      <LineChart option={option} />
    </div>
  );
};
