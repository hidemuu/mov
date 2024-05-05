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
            data: s.data.map((d) => ({ x: 0, y: d })),
            onDataPointClick: () => alert("click on data"),
          })),
  };

  return <Chart highChartOptions={undefined} fluentUiChartProps={chartProps} />;
};
