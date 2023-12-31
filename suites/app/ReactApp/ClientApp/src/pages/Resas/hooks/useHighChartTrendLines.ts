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
        let count = 0;
        for(let regionTrendLine of regionTrendLines){
            let data = [];
            for(let trendLine of regionTrendLine.trendLines){
                if(count === 0){
                    categories.push(String(trendLine.number));
                }
                data.push(trendLine.value);
            }
            const prefTable = regionTableLines.pref.filter(x => x.id === regionTrendLine.region.prefCode);
            const cityTable = regionTableLines.city.filter(x => x.id === regionTrendLine.region.cityCode);
            const prefName = prefTable.length === 0 ? String(regionTrendLine.region.prefCode) : prefTable[0].content;
            const cityName = cityTable.length === 0 ? String(regionTrendLine.region.cityCode) : cityTable[0].content;
            series.push({
                type: "line",
                name: prefName + '-' + cityName,
                data: data,
            });
            count++;
        }

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