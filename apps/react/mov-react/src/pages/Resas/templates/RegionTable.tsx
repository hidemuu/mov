import React, { FC } from 'react'
import { ITableColumnContent } from 'components/molecules/DataTable/types/ITableColumnContent'
import { ITableItem } from 'stores/resas/types/tables/ITableItem'
import { DataTable } from 'components/molecules/DataTable'

export declare type RegionTableProps = {
  regionTableLines: ITableItem[]
  tableColumns: ITableColumnContent[]
}

// eslint-disable-next-line react/display-name
export const RegionTable: FC<RegionTableProps> = React.memo(
  ({ regionTableLines, tableColumns }: RegionTableProps) => {
    return (
      <div>
        <DataTable
          rowContents={regionTableLines.map((x) => ({
            id: x.id,
            category: x.category,
            label: x.label,
            name: x.name,
            content: x.content
          }))}
          columnContents={tableColumns}
        />
      </div>
    )
  }
)
