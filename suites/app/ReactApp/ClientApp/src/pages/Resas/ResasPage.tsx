import React, { useState, useEffect } from 'react';
import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import styled from 'styled-components';
import axios from "axios";
import { TrendLine } from "./models/TrendLine";
import { TableLine } from "./models/TableLine";
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
import useRegionState from './hooks/useRegionState';
import { RegionValue } from './models/RegionValue';
import { TableColumn } from './models/TableColumn';
import { useStyles } from './hooks/useStyles';
import useRegionTableLines from './hooks/useRegionTableLines';
import { useInputId } from '../../hooks/useInputId';

const Button = styled.button`
  border: 1px solid #666;
  background: none;
  margin-top: 12px;
  border-radius: 4px;
`;

export const ResasPage: React.FunctionComponent = () => {

    const styles = useStyles();

    const inputId = useInputId();
    const [regionValue, setRegionValue] = useRegionState("11", "11362");

    const onChangePrefecture: InputProps["onChange"] = (ev, data) => {
        if (data.value.length <= 20) {
            const updateRegionValue : RegionValue = {
                pref : data.value,
                city : regionValue.city,
            }
            setRegionValue(updateRegionValue);
        }
      };
    const onChangeCity: InputProps["onChange"] = (ev, data) => {
        if (data.value.length <= 20) {
            const updateRegionValue : RegionValue = {
                pref : regionValue.pref,
                city : data.value,
            }
            setRegionValue(updateRegionValue);
        }
      };

    const populationPerYearTrendLines = usePopulationPerYearTrendLines(regionValue);

    const onClickApply = () => {

    }

    const regionTable = useRegionTableLines();

    useEffect(() => {
        //レンダリング毎に実行
        console.log("再レンダリングされるたび実行");
    });

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

    const tableColumns : TableColumn[] = [
        { columnKey: 'id', label: 'id' },
        { columnKey: 'name', label: 'name' },
        { columnKey: 'category', label: 'category' },
        { columnKey: 'label', label: 'label' },
    ];

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
                    {regionTable.pref.map(line => (
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
                    {regionTable.city.map(line => (
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
                <Input id={inputId} value={regionValue.pref} onChange={onChangePrefecture} />
                <Label htmlFor={inputId} style={{ paddingInlineEnd: "12px" }}>都市コード</Label>
                <Input id={inputId} value={regionValue.city} onChange={onChangeCity} />
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