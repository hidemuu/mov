import React from "react";
import { Label, makeStyles, shorthands } from "@fluentui/react-components";
import type { ComboboxProps } from "@fluentui/react-components";
import { IRegionTable } from "stores/resas/types/tables/IRegionTable";
import { IRegionTrendResponse } from "stores/resas/types/trends/IRegionTrendResponse";
import { IRegionSelections } from "../../domains/selections/types/IRegionSelections";
import { CityComboBox } from "./components/RegionComboBox/containers/CityComboBox";
import { PrefComboBox } from "./components/RegionComboBox/containers/PrefComboBox";
import { TabPanel } from "components/molecules/TabPanel";
import FluentPyramidChart from "components/atoms/Chart/containers/FluentPyramidChart";
import { RegionTable } from "./components/RegionTable";
import Map from "components/atoms/Map";
import { FluentRegionTrendLineChart } from "./components/RegionTrendLineChart/containers/FluentRegionTrendLineChart";

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
        <Label htmlFor={inputId} style={{ paddingInlineEnd: "12px" }}>
          都市コード
        </Label>
        <CityComboBox regionSelections={regionSelections} onOptionSelect={onChangeSelectedCity} />
      </div>
      <h2>トレンドグラフ</h2>
      <TabPanel
        tabNames={["LineChart", "Pyramid", "HeatMap"]}
        components={[
          <FluentRegionTrendLineChart key={0} regionTrend={regionTrendLines} />,
          <FluentPyramidChart key={1}></FluentPyramidChart>,
          <Map key={2} />,
        ]}
      ></TabPanel>
      <h2>統計</h2>
      <h2>都道府県一覧</h2>
      <TabPanel
        tabNames={["都道府県コード一覧", "都市コード一覧"]}
        components={[
          <RegionTable key={0} regionTableLines={regionTable.pref} />,
          <RegionTable key={1} regionTableLines={regionTable.city} />,
        ]}
      ></TabPanel>
    </div>
  );
};
