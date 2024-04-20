import React, { useState } from "react";
import { AppContext } from "./AppContext";
import { Layout } from "./Layout";
import { webLightTheme } from "@fluentui/react-components";
import {
  RegionItemContext,
  useRegionItemContextValue,
} from "stores/resas/contexts/RegionItemContext";
import {
  RegionTrendContext,
  useRegionTrendState,
} from "stores/resas/contexts/RegionTrendContext";
import {
  RegionTableContext,
  useRegionTableContextValue,
} from "stores/resas/contexts/RegionTableContext";

export const App: React.FunctionComponent = (theme) => {
  const [state, setState] = useState({
    searchTerm: "*",
    sidebar: {
      isMinimized: false,
    },
    theme: { key: "light", fluentTheme: webLightTheme },
  });

  return (
    <AppContext.Provider value={{ state, setState }}>
      <RegionItemContext.Provider value={useRegionItemContextValue()}>
        <RegionTrendContext.Provider value={useRegionTrendState()}>
          <RegionTableContext.Provider value={useRegionTableContextValue()}>
            <Layout />
          </RegionTableContext.Provider>
        </RegionTrendContext.Provider>
      </RegionItemContext.Provider>
    </AppContext.Provider>
  );
};
