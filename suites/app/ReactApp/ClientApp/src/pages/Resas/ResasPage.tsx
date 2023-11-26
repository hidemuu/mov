import React, { useState, useEffect } from 'react';
import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import styled from 'styled-components';
import axios from "axios";
import { TrendLine } from "./models/TrendLine";
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
    useId, 
    Input, 
    Label,
} from '@fluentui/react-components';
import type {
    SelectTabData,
    SelectTabEvent,
    TabValue,
    InputProps,
    ButtonProps,
  } from "@fluentui/react-components";
import usePopulationPerYearTrendLines from './hooks/usePopulationPerYearTrendLines';

const Button = styled.button`
  border: 1px solid #666;
  background: none;
  margin-top: 12px;
  border-radius: 4px;
`;

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
    grid: {
        ...shorthands.gap("16px"),
        display: "flex",
        flexDirection: "column",
    },
});

export const ResasPage: React.FunctionComponent = () => {

    const styles = useStyles();

    const inputId = useId("input");
    const [prefectureValue, setPrefectureValue] = React.useState("11");
    const onChangePrefecture: InputProps["onChange"] = (ev, data) => {
        // The controlled input pattern can be used for other purposes besides validation,
        // but validation is a useful example
        if (data.value.length <= 20) {
          setPrefectureValue(data.value);
        }
      };
    const [cityValue, setCityValue] = React.useState("11362");
    const onChangeCity: InputProps["onChange"] = (ev, data) => {
        // The controlled input pattern can be used for other purposes besides validation,
        // but validation is a useful example
        if (data.value.length <= 20) {
          setCityValue(data.value);
        }
      };

    const populationPerYearTrendLines = usePopulationPerYearTrendLines(prefectureValue, cityValue);

    const onClickApply = () => {

    }

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

    useEffect(() => {
        //レンダリング毎に実行
        console.log("再レンダリングされるたび実行");
    });

    useEffect(() =>{
        //初回レンダリング時に実行
        console.log("初回レンダリング時に実行");
        axios
            .get('api/TableLine/prefecture', {
            })
            .then((results) => {
                setPrefectureTableLines(results.data);
            })
            .catch((error) => { });
        axios
            .get('api/TableLine/city', {
            })
            .then((results) => {
                setCityTableLines(results.data);
            })
            .catch((error) => { });
    },[])

    const [chartOptions, setChartOptions] = useState<Highcharts.Options>();
    

    useEffect(() => {
        let series: Highcharts.SeriesOptionsType[] = [];
        let categories = [];
        let data = [];
        for (let trendLine of populationPerYearTrendLines) {
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

    }, [populationPerYearTrendLines]);

    const tableColumns = [
        { columnKey: 'id', label: 'id' },
        { columnKey: 'name', label: 'name' },
        { columnKey: 'category', label: 'category' },
        { columnKey: 'label', label: 'label' },
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
                            <TableCell>{line.label}</TableCell>
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
                            <TableCell>{line.label}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </div>
    ));

    const [selectedTabValue, setSelectedTabValue] =
    React.useState<TabValue>("conditions");

    const onTabSelect = (event: SelectTabEvent, data: SelectTabData) => {
        setSelectedTabValue(data.value);
    };

    return (
        <div className={styles.root}>
            <div>
                <Label htmlFor={inputId} style={{ paddingInlineEnd: "12px" }}>都道府県コード</Label>
                <Input id={inputId} value={prefectureValue} onChange={onChangePrefecture} />
                <Label htmlFor={inputId} style={{ paddingInlineEnd: "12px" }}>都市コード</Label>
                <Input id={inputId} value={cityValue} onChange={onChangeCity} />
                <Button onClick={onClickApply}></Button>
            </div>
            <h2>トレンドグラフ</h2>
            <HighchartsReact highcharts={Highcharts} options={chartOptions} />
            <TabList selectedValue={selectedTabValue} onTabSelect={onTabSelect}>
                <Tab value="tab1">都道府県コード一覧</Tab>
                <Tab value="tab2">都市コード一覧</Tab>
            </TabList>
            <div className={styles.panels}>
                {selectedTabValue === "tab1" && <Prefectures />}
                {selectedTabValue === "tab2" && <Cities />}
            </div>
        </div>
    );
};