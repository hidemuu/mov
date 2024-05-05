import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { ILineChartProps, LineChart } from "@fluentui/react-charting";
import React, { FC } from "react";

const Styles: { [key: string]: React.CSSProperties } = {
  graph: {
    padding: "12px",
  },
};

declare type ChartProps = {
  highChartOptions?: Highcharts.Options;
  fluentUiChartProps?: ILineChartProps;
};

export const Chart: FC<ChartProps> = ({ highChartOptions, fluentUiChartProps }) => {
  return (
    <div style={Styles.graph}>
      {highChartOptions !== undefined && (
        <HighchartsReact highcharts={Highcharts} options={highChartOptions} />
      )}
      {fluentUiChartProps !== undefined && (
        <LineChart
          culture={window.navigator.language}
          data={fluentUiChartProps.data}
          legendsOverflowText={"Overflow Items"}
          yMinValue={200}
          yMaxValue={301}
          height={500}
          width={500}
          xAxisTickCount={10}
          allowMultipleShapesForPoints={true}
          enablePerfOptimization={true}
          yAxisTitle={"Different categories of mail flow"}
          xAxisTitle={"Values of each category"}
        />
      )}
    </div>
  );
};
