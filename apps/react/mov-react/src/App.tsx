import React, { useState } from "react";
import { AppContext } from "./AppContext";
import { Layout } from "./Layout";
import { webLightTheme } from "@fluentui/react-components";
import {
  RegionItemContext,
  useRegionItemState,
} from "stores/resas/contexts/RegionItemContext";

export const App: React.FunctionComponent = (theme) => {
  const [state, setState] = useState({
    searchTerm: "*",
    sidebar: {
      isMinimized: false,
    },
    theme: { key: "light", fluentTheme: webLightTheme },
  });

  const [regionItemState, setRegionItemState] = useRegionItemState();

  return (
    <AppContext.Provider value={{ state, setState }}>
      <RegionItemContext.Provider
        value={{ state: regionItemState, setState: setRegionItemState }}
      >
        <Layout />
      </RegionItemContext.Provider>
    </AppContext.Provider>
  );
};
