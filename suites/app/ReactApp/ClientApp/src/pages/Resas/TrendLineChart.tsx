import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import { FC } from "react";
import { TrendLine } from "./models/TrendLine";
import useHighChartTrendLines from "./hooks/useHighChartTrendLines";

export declare type TrendLineChartProps = {
    trendLines : TrendLine[], 
}

export const TrendLineChart: FC<TrendLineChartProps> = ({ trendLines}) => {
    const chartOptions = useHighChartTrendLines(trendLines);
    return(
        <HighchartsReact highcharts={Highcharts} options={chartOptions} />
    )
}