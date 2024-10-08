﻿import * as React from "react";
import { PageHeader } from "../../../../components/organisms/PageHeader";
import { AllResults, PeopleResults } from ".";
import {
  SelectTabData,
  SelectTabEvent,
  Tab,
  TabList,
  TabValue,
  makeStyles,
  shorthands,
} from "@fluentui/react-components";
import { useAppContext } from "../../../../AppContext";
import { ExternalItemsResults } from "./containers/ExternalItemsResults";
import { FilesResults } from "./containers/FilesResults";

const useStyles = makeStyles({
  panels: {
    ...shorthands.padding("10px"),
  },
  container: {
    maxWidth: "1028px",
    width: "100%",
  },
});

export const SearchResult: React.FunctionComponent = () => {
  const styles = useStyles();
  const appContext = useAppContext();
  const [query] = React.useState(new URLSearchParams(window.location.search).get("q"));

  const [selectedTab, setSelectedTab] = React.useState<TabValue>("allResults");

  const onTabSelect = (event: SelectTabEvent, data: SelectTabData) => {
    setSelectedTab(data.value);
  };

  return (
    <>
      <PageHeader
        title={"Search"}
        description={
          "Use this Search Center to test Microsot Graph Toolkit search components capabilities"
        }
      ></PageHeader>

      <div className={styles.container}>
        <TabList selectedValue={selectedTab} onTabSelect={onTabSelect}>
          <Tab value="allResults">All Results</Tab>
          <Tab value="driveItems">Files</Tab>
          <Tab value="externalItems">External Items</Tab>
          <Tab value="people">People</Tab>
        </TabList>
        <div className={styles.panels}>
          {selectedTab === "allResults" && (
            <AllResults searchTerm={query ?? appContext.state.searchTerm}></AllResults>
          )}
          {selectedTab === "driveItems" && (
            <FilesResults searchTerm={query ?? appContext.state.searchTerm}></FilesResults>
          )}
          {selectedTab === "externalItems" && (
            <ExternalItemsResults
              searchTerm={query ?? appContext.state.searchTerm}
            ></ExternalItemsResults>
          )}
          {selectedTab === "people" && (
            <PeopleResults searchTerm={query ?? appContext.state.searchTerm}></PeopleResults>
          )}
        </div>
      </div>
    </>
  );
};
