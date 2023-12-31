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
    Combobox,
    Button,
    Option,
} from '@fluentui/react-components';
import type {
    SelectTabData,
    SelectTabEvent,
    TabValue,
    InputProps,
    ButtonProps,
    ComboboxProps,
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
import { TrendLineChart } from './TrendLineChart';
import { RegionComboBox } from './RegionComboBox';

export const ResasPage: React.FunctionComponent = () => {

    const styles = useStyles();
    const inputId = useInputId();
    const [regionValue, setRegionValue] = useRegionState(11, 11362);
    const regionTable = useRegionTableLines();
    const populationPerYearTrendLines = usePopulationPerYearTrendLines(regionValue);

    const onChangePrefecture: InputProps["onChange"] = (ev, data) => {
        if (data.value.length <= 20) {
            const updateRegionValue : RegionValue = {
                pref : Number(data.value),
                prefCode : '',
                city : regionValue.city,
                cityCode : '',
            }
            setRegionValue(updateRegionValue);
        }
      };

    const onChangeCity: InputProps["onChange"] = (ev, data) => {
        if (data.value.length <= 20) {
            const updateRegionValue : RegionValue = {
                pref : regionValue.pref,
                prefCode : '',
                city : Number(data.value),
                cityCode : '',
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

    return (
        <div className={styles.root}>
            <div>
                <Label htmlFor={inputId} style={{ paddingInlineEnd: "12px" }}>都道府県コード</Label>
                <Input id={inputId} value={String(regionValue.pref)} onChange={onChangePrefecture} />
                <RegionComboBox regionValue={regionValue} tableLines={regionTable} />
                <Label htmlFor={inputId} style={{ paddingInlineEnd: "12px" }}>都市コード</Label>
                <Input id={inputId} value={String(regionValue.city)} onChange={onChangeCity} />
                <Button onClick={onClickApply}></Button>
            </div>
            <h2>トレンドグラフ</h2>
            <TrendLineChart trendLines={populationPerYearTrendLines} regionTableLines={regionTable} />
            <RegionTab regionTableLines={regionTable} />
        </div>
    );
};