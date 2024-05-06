import React, { FC } from "react";
import { ITableColumnContent } from "components/molecules/DataTable/types/ITableColumnContent";
import { ITableItemResponse } from "stores/resas/types/tables/ITableItemResponse";
import { DataTable } from "components/molecules/DataTable";

export declare type RegionTableProps = {
  regionTableLines: ITableItemResponse[];
};

// eslint-disable-next-line react/display-name
export const RegionTable: FC<RegionTableProps> = React.memo(
  ({ regionTableLines }: RegionTableProps) => {
    function useTableColumns(): ITableColumnContent[] {
      const tableColumns: ITableColumnContent[] = [
        { columnKey: "id", label: "id" },
        { columnKey: "name", label: "name" },
        { columnKey: "category", label: "category" },
        { columnKey: "label", label: "label" },
      ];
      return tableColumns;
    }

    const tableColumns: ITableColumnContent[] = useTableColumns();

    return (
      <div>
        <DataTable
          rowContents={regionTableLines.map((x) => ({
            id: x.id,
            category: x.category,
            label: x.label,
            name: x.name,
            content: x.content,
          }))}
          columnContents={tableColumns}
        />
      </div>
    );
  },
);
