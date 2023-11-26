import { useEffect, useState } from "react";
import Highcharts from "highcharts";
import { TrendLine } from "../models/TrendLine";
import { RegionTableLines } from "../models/RegionTableLines";
import { RegionTrendLines } from "../models/RegionTrendLines";


export default function useHighChartTrendLines(regionTrendLines : RegionTrendLines[], regionTableLines : RegionTableLines) : Highcharts.Options {
    const [chartOptions, setChartOptions] = useState<Highcharts.Options>(
        {
            series : [],
        });

    useEffect(() => {
        let series: Highcharts.SeriesOptionsType[] = [];
        let categories = [];
        let data = [];
        const trendLines: TrendLine[] = regionTrendLines.length === 0 ? [] : regionTrendLines[0].trendLines;
        for (let trendLine of trendLines) {
            categories.push(String(trendLine.number));
            data.push(trendLine.value);
        }
        series.push({
            type: "line",
            name: "population",
            data: data,
        });

        setChartOptions({
            title: {
                text: "総人口推移",
            },
            xAxis: {
                title: {
                    text: "年度",
                },
                categories: categories,
            },
            yAxis: {
                title: {
                    text: "人口数",
                },
            },
            // 都道府県を一つも選んでいない場合との分岐条件
            series:
                series.length === 0
                    ? [{ type: "line", name: "都道府県名", data: [] }]
                    : series,
        });

    }, [regionTrendLines]);

    return chartOptions;
}