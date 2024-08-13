import * as React from "react";
import { PageHeader } from "../../components/organisms/PageHeader";
import { Input, Label, makeStyles, shorthands } from "@fluentui/react-components";
import type { InputProps } from "@fluentui/react-components";
import { useRegionItemContext } from "stores/resas/contexts/RegionItemContext";
import { FileTable } from "./components/Table/FileTable";
import { Outlook } from "./components/Outlook/Outlook";
import { SearchResult } from "./components/Search/SearchResult";
import { TaxonomyPage } from "./components/Taxonomy/containers/TaxonomyPage";

const useStyles = makeStyles({
  root: {
    display: "flex",
    flexDirection: "column",
    ...shorthands.gap("20px"),
    // Prevent the example from taking the full width of the page (optional)
    // maxWidth: "400px",
    // Stack the label above the field (with 2px gap per the design system)
    "> div": {
      display: "flex",
      flexDirection: "column",
      ...shorthands.gap("2px"),
    },
  },
});

export type HomeProps = {
  inputId: string;
  consoleValue: string;
  onConsoleChange: InputProps["onChange"];
  onConsoleKeyDown: InputProps["onKeyDown"];
  onConsolePaste: InputProps["onPaste"];
};

export const Home = ({
  inputId,
  consoleValue,
  onConsoleChange,
  onConsoleKeyDown,
  onConsolePaste,
}: HomeProps) => {
  const styles = useStyles();

  const regionItemStore = useRegionItemContext();

  return (
    <div className={styles.root}>
      <PageHeader title={"Home"} description={"Welcome to Mov Suite!"}></PageHeader>
      <Label>Console</Label>
      <Input
        placeholder="inline"
        aria-label="inline"
        value={consoleValue}
        onChange={onConsoleChange}
        onKeyDown={onConsoleKeyDown}
        onPaste={onConsolePaste}
        id={inputId}
      />
      <Label>Response:{regionItemStore.asString()}</Label>
      <FileTable />
      <Outlook />
      <SearchResult />
      <TaxonomyPage />
    </div>
  );
};
