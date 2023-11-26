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
import useHighChartTrendLines from './hooks/useHighChartTrendLines';
import useTableColumns from './hooks/useTableColumns';
import { RegionTable } from './RegionTable';
import { RegionTab } from './RegionTab';

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
    const regionTable = useRegionTableLines();
    const populationPerYearTrendLines = usePopulationPerYearTrendLines(regionValue);
    const chartOptions = useHighChartTrendLines(populationPerYearTrendLines);

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

    const onClickApply = () => {

    }

    useEffect(() => {
        //レンダリング毎に実行
        console.log("再レンダリングされるたび実行");
    });
  
    const tableColumns : TableColumn[] = useTableColumns();

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
            <RegionTab regionTableLines={regionTable} tableColumns={tableColumns} />
        </div>
    );
};