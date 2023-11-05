import React, { useEffect, useState } from 'react';
import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import axios from "axios";
import fetchData from "../hooks/fatchData";

export const ResasPage: React.FunctionComponent = () => {
    
    const [trendLines, setTrendLines] = useState<{
        id: string;
        category: string;
        label: string;
        number: number;
        value: number
    }[]>([]);

    useEffect(() => {
        // 都道府県一覧を取得する
        axios
            .get('api/TrendLine/population_per_years/11/11362', {
                //headers: { "X-API-KEY": process.env.REACT_APP_API_KEY },
            })
            .then((results) => {
                setTrendLines(results.data);
            })
            .catch((error) => { });
    }, []);

    let series: Highcharts.SeriesOptionsType[] = [];
    let categories = [];
    let data = [];
    for (let trendLine of trendLines)
    {    
        categories.push(String(trendLine.number));   
        data.push(trendLine.value);
    }

    series.push({
        type: "line",
        name: "population",
        data: data,
    });

    const options: Highcharts.Options = {
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
    };

    return (
        <div>
            <HighchartsReact highcharts={Highcharts} options={options} />
        </div>
    );
};