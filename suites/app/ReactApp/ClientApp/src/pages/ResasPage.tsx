import React, { useState, useEffect } from 'react';
import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import axios from "axios";
import {
    TableBody,
    TableCell,
    TableRow,
    Table,
    TableHeader,
    TableHeaderCell,
    TableCellLayout,
    PresenceBadgeStatus,
    Avatar,
    makeStyles,
    shorthands,
    Tab,
    TabList,
} from '@fluentui/react-components';
import type {
    SelectTabData,
    SelectTabEvent,
    TabValue,
  } from "@fluentui/react-components";

const useStyles = makeStyles({
    root: {
        alignItems: "flex-start",
        display: "flex",
        flexDirection: "column",
        justifyContent: "flex-start",
        ...shorthands.padding("50px", "20px"),
        rowGap: "20px",
    },
    panels: {
        ...shorthands.padding(0, "10px"),
        "& th": {
            textAlign: "left",
            ...shorthands.padding(0, "30px", 0, 0),
        },
    },
});

export const ResasPage: React.FunctionComponent = () => {

    const styles = useStyles();

    const [prefectureTableLines, setPrefectureTableLines] = useState<{
        id: number;
        category: string;
        label: string;
        name: string;
        content: string;
    }[]>([]);

    const [cityTableLines, setCityTableLines] = useState<{
        id: number;
        category: string;
        label: string;
        name: string;
        content: string;
    }[]>([]);


    const [trendLines, setTrendLines] = useState<{
        id: string;
        category: string;
        label: string;
        number: number;
        value: number;
    }[]>([]);

    useEffect(() => {
        axios
            .get('api/TableLine/prefecture', {
            })
            .then((results) => {
                setPrefectureTableLines(results.data);
            })
            .catch((error) => { });
    }, []);

    useEffect(() => {
        axios
            .get('api/TableLine/city', {
            })
            .then((results) => {
                setCityTableLines(results.data);
            })
            .catch((error) => { });
    }, []);

    useEffect(() => {
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
    for (let trendLine of trendLines) {
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

    const tableColumns = [
        { columnKey: 'id', label: 'id' },
        { columnKey: 'name', label: 'name' },
        { columnKey: 'category', label: 'category' },
    ];

    const tableStyles = {
        maxheight: '400px', // 適切な高さに変更してください
        overflow: 'auto', // テーブルの高さを超えた場合にスクロールバーを表示
    };

    const Prefectures = React.memo(() => (
        <div>
            <Table arial-label="Default table">
                <TableHeader>
                    <TableRow>
                        {tableColumns.map(column => (
                            <TableHeaderCell key={column.columnKey}>{column.label}</TableHeaderCell>
                        ))}
                    </TableRow>
                </TableHeader>
                <TableBody>
                    {prefectureTableLines.map(line => (
                        <TableRow key={line.id}>
                            <TableCell>{line.id}</TableCell>
                            <TableCell>{line.name}</TableCell>
                            <TableCell>{line.category}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </div>
    ));

    const Cities = React.memo(() => (
        <div>
            <Table arial-label="Default table">
                <TableHeader>
                    <TableRow>
                        {tableColumns.map(column => (
                            <TableHeaderCell key={column.columnKey}>{column.label}</TableHeaderCell>
                        ))}
                    </TableRow>
                </TableHeader>
                <TableBody>
                    {cityTableLines.map(line => (
                        <TableRow key={line.id}>
                            <TableCell>{line.id}</TableCell>
                            <TableCell>{line.name}</TableCell>
                            <TableCell>{line.category}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </div>
    ));

    const [selectedValue, setSelectedValue] =
    React.useState<TabValue>("conditions");

    const onTabSelect = (event: SelectTabEvent, data: SelectTabData) => {
        setSelectedValue(data.value);
    };

    return (
        <div className={styles.root}>
            <h2>トレンドグラフ</h2>
            <HighchartsReact highcharts={Highcharts} options={options} />
            <TabList selectedValue={selectedValue} onTabSelect={onTabSelect}>
                <Tab value="tab1">都道府県コード一覧</Tab>
                <Tab value="tab2">都市コード一覧</Tab>
            </TabList>
            <div className={styles.panels}>
                {selectedValue === "tab1" && <Prefectures />}
                {selectedValue === "tab2" && <Cities />}
            </div>
        </div>
    );
};