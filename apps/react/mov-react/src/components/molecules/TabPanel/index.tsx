import React, { FC, ReactNode, useState } from "react";
import {
  SelectTabData,
  SelectTabEvent,
  Tab,
  TabList,
  makeStyles,
  shorthands,
} from "@fluentui/react-components";

const useStyles = makeStyles({
  panels: {
    ...shorthands.padding(0, "10px"),
    "& th": {
      textAlign: "left",
      ...shorthands.padding(0, "30px", 0, 0),
    },
    width: "700px",
  },
});

declare type TabPanelProps = {
  tabNames: string[];
  components: ReactNode[];
};

export const TabPanel: FC<TabPanelProps> = ({ tabNames, components }) => {
  const styles = useStyles();
  const [selectedTabValue, setSelectedTabValue] = useState<number>(-1);

  const onTabSelect = (event: SelectTabEvent, data: SelectTabData) => {
    setSelectedTabValue(Number(data.value));
  };

  return (
    <div>
      <TabList selectedValue={selectedTabValue} onTabSelect={onTabSelect}>
        {tabNames.map((name, index) => (
          <Tab key={index} value={index}>
            {name}
          </Tab>
        ))}
      </TabList>
      <div className={styles.panels}>{selectedTabValue > -1 && components[selectedTabValue]}</div>
    </div>
  );
};
