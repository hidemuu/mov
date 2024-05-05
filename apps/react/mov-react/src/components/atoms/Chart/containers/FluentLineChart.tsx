import React from "react";
import { Chart } from "../index";
import { ILineChartOption } from "../types/ILineChartOption";
import { DataVizPalette, IChartProps, ILineChartProps } from "@fluentui/react-charting";

type LineChartProps = {
  option: ILineChartOption;
};

export const FluentLineChart = (props: LineChartProps) => {
  const { option } = props;

  const chartProps: IChartProps = {
    chartTitle: option.title,
    lineChartData:
      option.series.length === 0
        ? [
            {
              legend: "",
              data: [],
              color: DataVizPalette.color1,
              lineOptions: { lineBorderWidth: "1" },
            },
          ]
        : option.series.map((s) => ({
            legend: s.name,
            data: s.data.map((d) => ({
              x: d.x,
              y: d.y,
              onDataPointClick: () => alert(`click on x: ${d.x} y: ${d.y}`),
            })),
            color: s.color,
            lineOptions: { lineBorderWidth: String(s.borderWdth) },
          })),
  };

  const lineChartProps: ILineChartProps = {
    data: chartProps,
  };

  return <Chart highChartOptions={undefined} fluentUiChartProps={lineChartProps} />;
};
