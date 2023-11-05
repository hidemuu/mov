import React, { useState, useEffect } from 'react';
import Highcharts from "highcharts";
import HighchartsReact from "highcharts-react-official";
import axios from "axios";
import {
    FolderRegular,
    EditRegular,
    OpenRegular,
    DocumentRegular,
    PeopleRegular,
    DocumentPdfRegular,
    VideoRegular,
} from '@fluentui/react-icons';
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
} from '@fluentui/react-components';

const items = [
    {
        file: { label: 'Meeting notes', icon: <DocumentRegular /> },
        author: { label: 'Max Mustermann', status: 'available' },
        lastUpdated: { label: '7h ago', timestamp: 1 },
        lastUpdate: {
            label: 'You edited this',
            icon: <EditRegular />,
        },
    },
    {
        file: { label: 'Thursday presentation', icon: <FolderRegular /> },
        author: { label: 'Erika Mustermann', status: 'busy' },
        lastUpdated: { label: 'Yesterday at 1:45 PM', timestamp: 2 },
        lastUpdate: {
            label: 'You recently opened this',
            icon: <OpenRegular />,
        },
    },
    {
        file: { label: 'Training recording', icon: <VideoRegular /> },
        author: { label: 'John Doe', status: 'away' },
        lastUpdated: { label: 'Yesterday at 1:45 PM', timestamp: 2 },
        lastUpdate: {
            label: 'You recently opened this',
            icon: <OpenRegular />,
        },
    },
    {
        file: { label: 'Purchase order', icon: <DocumentPdfRegular /> },
        author: { label: 'Jane Doe', status: 'offline' },
        lastUpdated: { label: 'Tue at 9:30 AM', timestamp: 3 },
        lastUpdate: {
            label: 'You shared this in a Teams chat',
            icon: <PeopleRegular />,
        },
    },
];

const columns = [
    { columnKey: 'file', label: 'File' },
    { columnKey: 'author', label: 'Author' },
    { columnKey: 'lastUpdated', label: 'Last updated' },
    { columnKey: 'lastUpdate', label: 'Last update' },
];

export const ResasPage: React.FunctionComponent = () => {

    const [tableLines, setTableLines] = useState<{
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
                setTableLines(results.data);
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
            <Table arial-label="Default table">
                <TableHeader>
                    <TableRow>
                        {columns.map(column => (
                            <TableHeaderCell key={column.columnKey}>{column.label}</TableHeaderCell>
                        ))}
                    </TableRow>
                </TableHeader>
                <TableBody>
                    {items.map(item => (
                        <TableRow key={item.file.label}>
                            <TableCell>
                                <TableCellLayout media={item.file.icon}>{item.file.label}</TableCellLayout>
                            </TableCell>
                            <TableCell>
                                <TableCellLayout
                                    media={
                                        <Avatar
                                            aria-label={item.author.label}
                                            name={item.author.label}
                                            badge={{ status: item.author.status as PresenceBadgeStatus }}
                                        />
                                    }
                                >
                                    {item.author.label}
                                </TableCellLayout>
                            </TableCell>
                            <TableCell>{item.lastUpdated.label}</TableCell>
                            <TableCell>
                                <TableCellLayout media={item.lastUpdate.icon}>{item.lastUpdate.label}</TableCellLayout>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
            <HighchartsReact highcharts={Highcharts} options={options} />
        </div>
    );
};