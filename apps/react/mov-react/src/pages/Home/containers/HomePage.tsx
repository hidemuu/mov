import * as React from "react";
import { useId } from "@fluentui/react-components";
import type { InputProps } from "@fluentui/react-components";
import { useRegionItemContext } from "stores/resas/contexts/RegionItemContext";
import { HomeTemplate } from "..";

export const HomePage: React.FunctionComponent = () => {
  const inputId = useId("input");
  const [consoleValue, setConsoleValue] = React.useState(
    "/api/analizers/regions/resas/ResasPrefecture",
  );

  const regionItemStore = useRegionItemContext();

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
        regionItemStore.update();
      }
    }
  };

  const onConsolePaste = (event: { clipboardData: { getData: (arg0: string) => any } }) => {
    const pastedText = event.clipboardData.getData("text");
    // ペーストされたテキストを取得し、必要な処理を行う
    console.log("Pasted text:", pastedText);
    setConsoleValue(pastedText);
  };

  return (
    <HomeTemplate
      inputId={inputId}
      consoleValue={consoleValue}
      onConsoleChange={onConsoleChange}
      onConsoleKeyDown={onConsoleKeyDown}
      onConsolePaste={onConsolePaste}
    ></HomeTemplate>
  );
};
