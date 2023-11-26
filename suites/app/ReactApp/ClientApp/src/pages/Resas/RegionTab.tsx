import { FC, useState } from "react";
import { TableColumn } from "./models/TableColumn";
import { SelectTabData, SelectTabEvent, Tab, TabList, TabValue } from "@fluentui/react-components";
import { RegionTable } from "./RegionTable";
import { RegionTableLines } from "./models/RegionTableLines";
import { useStyles } from "./hooks/useStyles";

export declare type RegionTabProps = {
    regionTableLines : RegionTableLines, 
    tableColumns : TableColumn[],
}

export const RegionTab: FC<RegionTabProps> = ({ regionTableLines, tableColumns}) => {
    const styles = useStyles();
    const [selectedTabValue, setSelectedTabValue] =
    useState<TabValue>("conditions");

    const onTabSelect = (event: SelectTabEvent, data: SelectTabData) => {
        setSelectedTabValue(data.value);
    };

    return(
        <div>
            <TabList selectedValue={selectedTabValue} onTabSelect={onTabSelect}>
                    <Tab value="tab1">都道府県コード一覧</Tab>
                    <Tab value="tab2">都市コード一覧</Tab>
            </TabList>
            <div className={styles.panels}>
                    {selectedTabValue === "tab1" && <RegionTable regionTableLines={regionTableLines.pref} tableColumns={tableColumns} />}
                    {selectedTabValue === "tab2" && <RegionTable regionTableLines={regionTableLines.city} tableColumns={tableColumns} />}
            </div>
        </div>
        );
};