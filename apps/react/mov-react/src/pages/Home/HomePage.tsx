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
  const [value, setValue] = React.useState("initial value");

  const onChange: InputProps["onChange"] = (ev, data) => {
    // The controlled input pattern can be used for other purposes besides validation,
    // but validation is a useful example
    if (data.value.length <= 20) {
      setValue(data.value);
    }
  };

  const onKeyDown = (event: { key: string }) => {
    if (event.key === "Enter") {
      // Enterキーが押されたときの処理をここに記述
      console.log("Enter key pressed");
      const v = value;
    }
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
        value={value}
        onChange={onChange}
        onKeyDown={onKeyDown}
        id={inputId}
      />
    </div>
  );
};
