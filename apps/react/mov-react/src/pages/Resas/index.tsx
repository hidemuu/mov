import React from "react";
import { Label, makeStyles, shorthands } from "@fluentui/react-components";
import type { ComboboxProps } from "@fluentui/react-components";
import { RegionTab } from "./components/RegionTab";
import { RegionTrendLineChart } from "./components/RegionTrendLineChart";
import { IRegionTable } from "stores/resas/types/tables/IRegionTable";
import { IRegionTrendResponse } from "stores/resas/types/trends/IRegionTrendResponse";
import { IRegionSelections } from "../../domains/selections/types/IRegionSelections";
import { CityComboBox } from "./components/RegionComboBox/containers/CityComboBox";
import { PrefComboBox } from "./components/RegionComboBox/containers/PrefComboBox";
import { TabPanel } from "components/molecules/TabPanel";
import FluentPyramidChart from "components/atoms/Chart/containers/FluentPyramidChart";
import { ITableColumnContent } from "components/molecules/DataTable/types/ITableColumnContent";
import { RegionTable } from "./components/RegionTable";

const useStyles = makeStyles({
  root: {
    alignItems: "flex-start",
    display: "flex",
    flexDirection: "column",
    justifyContent: "flex-start",
    ...shorthands.padding("50px", "20px"),
    rowGap: "20px",
  },
  grid: {
    ...shorthands.gap("16px"),
    display: "flex",
    flexDirection: "column",
  },
  combobox: {
    // Stack the label above the field with a gap
    display: "grid",
    gridTemplateRows: "repeat(1fr)",
    justifyItems: "start",
    ...shorthands.gap("2px"),
    maxWidth: "400px",
  },
});

export type ResasTemplateProps = {
  inputId: string;
  regionTable: IRegionTable;
  regionTrendLines: IRegionTrendResponse[];
  regionSelections: IRegionSelections;
  onChangeSelectedPrefecture: ComboboxProps["onOptionSelect"];
  onChangeSelectedCity: ComboboxProps["onOptionSelect"];
};

export const Resas = ({
  inputId,
  regionTable,
  regionTrendLines,
  regionSelections,
  onChangeSelectedPrefecture,
  onChangeSelectedCity,
}: ResasTemplateProps) => {
  const styles = useStyles();
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
    <div className={styles.root}>
      <div>
        <Label htmlFor={inputId} style={{ paddingInlineEnd: "12px" }}>
          都道府県コード
        </Label>
        <PrefComboBox
          regionSelections={regionSelections}
          onOptionSelect={onChangeSelectedPrefecture}
        />
        <br />
        <Label htmlFor={inputId} style={{ paddingInlineEnd: "12px" }}>
          都市コード
        </Label>
        <CityComboBox regionSelections={regionSelections} onOptionSelect={onChangeSelectedCity} />
      </div>
      <h2>トレンドグラフ</h2>
      <TabPanel
        tabNames={["LineChart", "Pyramid"]}
        components={[
          <RegionTrendLineChart key={0} regionTrend={regionTrendLines} chartType="fluent" />,
          <FluentPyramidChart key={1}></FluentPyramidChart>,
        ]}
      ></TabPanel>
      <h2>都道府県一覧</h2>
      <TabPanel
        tabNames={["都道府県コード一覧", "都市コード一覧"]}
        components={[
          <RegionTable key={0} regionTableLines={regionTable.pref} tableColumns={tableColumns} />,
          <RegionTable key={1} regionTableLines={regionTable.city} tableColumns={tableColumns} />,
        ]}
      ></TabPanel>
    </div>
  );
};
