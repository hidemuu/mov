import React, { FC } from 'react';
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
    ForwardRefComponent,
  } from "@fluentui/react-components";
import { RegionTableLines } from '../../features/models/RegionTableLines';
import { TableColumn } from './models/TableColumn';
import { TableLine } from '../../features/models/TableLine';

export declare type RegionTableProps = {
    regionTableLines : TableLine[], 
    tableColumns : TableColumn[]
}

export const RegionTable: FC<RegionTableProps> = React.memo(({ regionTableLines, tableColumns} : RegionTableProps) => {
    
    return(
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
                    {regionTableLines.map(line => (
                        <TableRow key={line.id}>
                            <TableCell>{line.id}</TableCell>
                            <TableCell>{line.name}</TableCell>
                            <TableCell>{line.category}</TableCell>
                            <TableCell>{line.label}</TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </div>);
});