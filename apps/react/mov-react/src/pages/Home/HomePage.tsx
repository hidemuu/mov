import * as React from "react";
import { PageHeader } from "../../components/organisms/PageHeader";
import {
  Input,
  Label,
  makeStyles,
  shorthands,
  useId,
} from "@fluentui/react-components";
import type { InputProps } from "@fluentui/react-components";
import fetchData from "stores/resas/services/fatchData";
import { IRegionItem } from "stores/resas/types/IRegionItem";
import {
  useRegionItemContext,
  updateRegionItemState,
  asStringRegionItemState,
} from "stores/resas/contexts/RegionItemContext";

const useStyles = makeStyles({
  root: {
    display: "flex",
    flexDirection: "column",
    ...shorthands.gap("20px"),
    // Prevent the example from taking the full width of the page (optional)
    maxWidth: "400px",
    // Stack the label above the field (with 2px gap per the design system)
    "> div": {
      display: "flex",
      flexDirection: "column",
      ...shorthands.gap("2px"),
    },
  },
});

export const HomePage: React.FunctionComponent = () => {
  const styles = useStyles();
  const inputId = useId("input");
  const [consoleValue, setConsoleValue] = React.useState(
    "/api/analizers/regions/resas/ResasPrefecture"
  );

  const regionItemContext = useRegionItemContext();

  const onConsoleChange: InputProps["onChange"] = (ev, data) => {
    // The controlled input pattern can be used for other purposes besides validation,
    // but validation is a useful example
    if (data.value.length <= 20) {
      setConsoleValue(data.value);
    }
  };

  const onConsoleKeyDown = (event: { key: string }) => {
    if (event.key === "Enter") {
      // Enterキーが押されたときの処理をここに記述
      console.log("Enter key pressed " + { consoleValue });
      if (
        consoleValue.includes("http://") ||
        consoleValue.includes("https://") ||
        consoleValue.includes("/api")
      ) {
        //httpのURIの場合
        updateRegionItemState(regionItemContext.setState);
      }
    }
  };

  const onConsolePaste = (event: {
    clipboardData: { getData: (arg0: string) => any };
  }) => {
    const pastedText = event.clipboardData.getData("text");
    // ペーストされたテキストを取得し、必要な処理を行う
    console.log("Pasted text:", pastedText);
    setConsoleValue(pastedText);
  };

  return (
    <div className={styles.root}>
      <PageHeader
        title={"Home"}
        description={"Welcome to Mov Suite!"}
      ></PageHeader>
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
      <Label>Response:{asStringRegionItemState(regionItemContext.state)}</Label>
    </div>
  );
};