import React, { Component, useEffect, useState } from 'react';
import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import axios from "axios";
import fetchData from "../hooks/fatchData";

export const ResasPage: React.FunctionComponent = () => {
    let series: Highcharts.SeriesOptionsType[] = [];
    let categories = [];

    const [prefectures, setPreFectures] = useState<{
        message: null;
        result: {
            prefCode: number;
            prefName: string;
        }[];
    } | null>(null);
    const [prefPopulation, setPrefPopulation] = useState<
        { prefName: string; data: { year: number; value: number }[] }[]
    >([]);

    useEffect(() => {
        // 都道府県一覧を取得する
        axios
            .get('prefecture', {
                //headers: { "X-API-KEY": process.env.REACT_APP_API_KEY },
            })
            .then((results) => {
                setPreFectures(results.data);
            })
            .catch((error) => { });

    }, []);

    for (let p of prefPopulation) {
        let data = [];

        for (let pd of p.data) {
            data.push(pd.value);
            categories.push(String(pd.year));
        }

        series.push({
            type: "line",
            name: p.prefName,
            data: data,
        });
    }

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