import React, { FC } from "react";
import useRegionTrendLineChart from "domains/statistics/hooks/useRegionTrendLineChart";
import { IRegionTrendResponse } from "stores/resas/types/trends/IRegionTrendResponse";
import { HighLineChart } from "components/atoms/Chart/containers/HighLineChart";
import { FluentLineChart } from "components/atoms/Chart/containers/FluentLineChart";

export declare type RegionTrendLineChartProps = {
  regionTrend: IRegionTrendResponse[];
};

export const RegionTrendLineChart: FC<RegionTrendLineChartProps> = ({ regionTrend }) => {
  const option = useRegionTrendLineChart(regionTrend);

  return (
    <div>
      <HighLineChart option={option} />
      <FluentLineChart option={option} />
    </div>
  );
};
