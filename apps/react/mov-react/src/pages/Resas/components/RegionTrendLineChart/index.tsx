import React, { FC } from "react";
import useRegionTrendLineChart from "domains/statistics/hooks/useRegionTrendLineChart";
import { IRegionTrendResponse } from "stores/resas/types/trends/IRegionTrendResponse";
import { LineChart } from "components/atoms/Chart/containers/LineChart";

export declare type RegionTrendLineChartProps = {
  regionTrend: IRegionTrendResponse[];
};

export const RegionTrendLineChart: FC<RegionTrendLineChartProps> = ({
  regionTrend,
}) => {
  const option = useRegionTrendLineChart(regionTrend);

  return (
    <div>
      <LineChart option={option} />
    </div>
  );
};
