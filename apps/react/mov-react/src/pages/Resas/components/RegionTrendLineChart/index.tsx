import React from "react";
import { HighLineChart } from "components/atoms/Chart/containers/HighLineChart";
import { FluentLineChart } from "components/atoms/Chart/containers/FluentLineChart";
import { ILineChartOption } from "components/atoms/Chart/types/ILineChartOption";

export declare type RegionTrendLineChartProps = {
  chartOption: ILineChartOption;
  chartType: string;
};

export const RegionTrendLineChart = (props: RegionTrendLineChartProps) => {
  return (
    <div>
      {props.chartType === "high" && <HighLineChart option={props.chartOption} />}
      {props.chartType !== "high" && <FluentLineChart option={props.chartOption} />}
    </div>
  );
};
