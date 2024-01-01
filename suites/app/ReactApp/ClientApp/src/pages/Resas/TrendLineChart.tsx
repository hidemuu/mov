import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { FC } from "react";
import { TrendLine } from "../../models/TrendLine";
import useHighChartTrendLines from "./hooks/useHighChartTrendLines";
import { RegionTableLines } from "../../models/RegionTableLines";
import { RegionTrendLines } from "../../models/RegionTrendLines";

const Styles: { [key: string]: React.CSSProperties } = {
    graph: {
      padding: "12px",
    },
  };

export declare type TrendLineChartProps = {
    trendLines : RegionTrendLines[], 
    regionTableLines : RegionTableLines,
}

export const TrendLineChart: FC<TrendLineChartProps> = ({ trendLines, regionTableLines}) => {
    const chartOptions = useHighChartTrendLines(trendLines, regionTableLines);
    return(
        <div style={Styles.graph}>
            <HighchartsReact highcharts={Highcharts} options={chartOptions} />
        </div>
    )
}