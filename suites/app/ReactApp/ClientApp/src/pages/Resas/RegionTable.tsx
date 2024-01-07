import React, { FC } from 'react'
import {
  TableBody,
  TableCell,
  TableRow,
  Table,
  TableHeader,
  TableHeaderCell
} from '@fluentui/react-components'
import { ITableColumn } from './types/ITableColumn'
import { ITableLine } from '../../stores/resas/types/tables/ITableLine'

export declare type RegionTableProps = {
  regionTableLines: ITableLine[]
  tableColumns: ITableColumn[]
}

// eslint-disable-next-line react/display-name
export const RegionTable: FC<RegionTableProps> = React.memo(
  ({ regionTableLines, tableColumns }: RegionTableProps) => {
    return (
      <div>
        <Table arial-label="Default table">
          <TableHeader>
            <TableRow>
              {tableColumns.map((column) => (
                <TableHeaderCell key={column.columnKey}>
                  {column.label}
                </TableHeaderCell>
              ))}
            </TableRow>
          </TableHeader>
          <TableBody>
            {regionTableLines.map((line) => (
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
    )
  }
)
