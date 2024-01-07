import React, { FC } from 'react'
import {
  TableBody,
  TableCell,
  TableRow,
  Table,
  TableHeader,
  TableHeaderCell
} from '@fluentui/react-components'
import { ITableColumnContent } from './types/ITableColumnContent'
import { ITableRowContent } from './types/ITableRowContent'

export declare type DataTableProps = {
  rowContents: ITableRowContent[]
  columnContents: ITableColumnContent[]
}

// eslint-disable-next-line react/display-name
export const DataTable: FC<DataTableProps> = React.memo(
  ({ rowContents, columnContents }: DataTableProps) => {
    return (
      <div>
        <Table arial-label="Default table">
          <TableHeader>
            <TableRow>
              {columnContents.map((column) => (
                <TableHeaderCell key={column.columnKey}>
                  {column.label}
                </TableHeaderCell>
              ))}
            </TableRow>
          </TableHeader>
          <TableBody>
            {rowContents.map((rowContent) => (
              <TableRow key={rowContent.id}>
                <TableCell>{rowContent.id}</TableCell>
                <TableCell>{rowContent.name}</TableCell>
                <TableCell>{rowContent.category}</TableCell>
                <TableCell>{rowContent.label}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    )
  }
)
