import React, { FC, useState } from "react";
import { ITableColumnContent } from "components/molecules/DataTable/types/ITableColumnContent";
import {
  SelectTabData,
  SelectTabEvent,
  Tab,
  TabList,
  TabValue,
  makeStyles,
  shorthands,
} from "@fluentui/react-components";
import { RegionTable } from "../RegionTable";
import { IRegionTable } from "stores/resas/types/tables/IRegionTable";

const useStyles = makeStyles({
  panels: {
    ...shorthands.padding(0, "10px"),
    "& th": {
      textAlign: "left",
      ...shorthands.padding(0, "30px", 0, 0),
    },
  },
});

function useTableColumns(): ITableColumnContent[] {
  const tableColumns: ITableColumnContent[] = [
    { columnKey: "id", label: "id" },
    { columnKey: "name", label: "name" },
    { columnKey: "category", label: "category" },
    { columnKey: "label", label: "label" },
  ];
  return tableColumns;
}

export declare type RegionTabProps = {
  regionTable: IRegionTable;
};

export const RegionTab: FC<RegionTabProps> = ({ regionTable }) => {
  const styles = useStyles();
  const tableColumns: ITableColumnContent[] = useTableColumns();
  const [selectedTabValue, setSelectedTabValue] = useState<TabValue>("conditions");

  const onTabSelect = (event: SelectTabEvent, data: SelectTabData) => {
    setSelectedTabValue(data.value);
  };

  return (
    <div>
      <TabList selectedValue={selectedTabValue} onTabSelect={onTabSelect}>
        <Tab value="tab1">都道府県コード一覧</Tab>
        <Tab value="tab2">都市コード一覧</Tab>
      </TabList>
      <div className={styles.panels}>
        {selectedTabValue === "tab1" && (
          <RegionTable regionTableLines={regionTable.pref} tableColumns={tableColumns} />
        )}
        {selectedTabValue === "tab2" && (
          <RegionTable regionTableLines={regionTable.city} tableColumns={tableColumns} />
        )}
      </div>
    </div>
  );
};
