import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { IChartProps, ILineChartProps, LineChart, DataVizPalette } from "@fluentui/react-charting";
import React, { FC } from "react";

const Styles: { [key: string]: React.CSSProperties } = {
  graph: {
    padding: "12px",
  },
};

declare type ChartProps = {
  highChartOptions: Highcharts.Options;
};

export const Chart: FC<ChartProps> = ({ highChartOptions }) => {
  return (
    <div style={Styles.graph}>
      {highChartOptions !== undefined && (
        <HighchartsReact highcharts={Highcharts} options={highChartOptions} />
      )}
    </div>
  );
};
