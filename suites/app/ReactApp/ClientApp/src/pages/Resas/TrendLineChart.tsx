import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { FC } from "react";
import { TrendLine } from "./models/TrendLine";
import useHighChartTrendLines from "./hooks/useHighChartTrendLines";
import { RegionTableLines } from "./models/RegionTableLines";

export declare type TrendLineChartProps = {
    trendLines : TrendLine[], 
    regionTableLines : RegionTableLines,
}

export const TrendLineChart: FC<TrendLineChartProps> = ({ trendLines, regionTableLines}) => {
    const chartOptions = useHighChartTrendLines(trendLines, regionTableLines);
    return(
        <HighchartsReact highcharts={Highcharts} options={chartOptions} />
    )
}