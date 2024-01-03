import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { FC } from "react";
import { ITrendLine } from "../../features/resas/types/ITrendLine";
import useHighChartTrendLines from "./hooks/useHighChartTrendLines";
import { IRegionTableLines } from "../../features/resas/types/IRegionTableLines";
import { IRegionTrendLines } from "../../features/resas/types/IRegionTrendLines";

const Styles: { [key: string]: React.CSSProperties } = {
    graph: {
      padding: "12px",
    },
  };

export declare type TrendLineChartProps = {
    trendLines : IRegionTrendLines[],
}

export const TrendLineChart: FC<TrendLineChartProps> = ({ trendLines}) => {
    const chartOptions = useHighChartTrendLines(trendLines);
    return(
        <div style={Styles.graph}>
            <HighchartsReact highcharts={Highcharts} options={chartOptions} />
        </div>
    )
}