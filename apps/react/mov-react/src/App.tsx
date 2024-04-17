import React, { useState } from "react";
import { AppContext } from "./AppContext";
import { Layout } from "./Layout";
import { webLightTheme } from "@fluentui/react-components";
import {
  RegionItemContext,
  useRegionItemState,
} from "stores/resas/contexts/RegionItemContext";
import {
  RegionTrendContext,
  useRegionTrendState,
} from "stores/resas/contexts/RegionTrendLineContext";
import {
  RegionTableContext,
  useRegionTableState,
} from "stores/resas/contexts/RegionTableLineContext";

export const App: React.FunctionComponent = (theme) => {
  const [state, setState] = useState({
    searchTerm: "*",
    sidebar: {
      isMinimized: false,
    },
    theme: { key: "light", fluentTheme: webLightTheme },
  });

  const [regionItemState, setRegionItemState] = useRegionItemState();
  const [regionTrendState, setRegionTrendState] = useRegionTrendState();
  const [
    regionTablePrefState,
    setRegionTablePrefState,
    regionTableCityState,
    setRegionTableCityState,
  ] = useRegionTableState();

  return (
    <AppContext.Provider value={{ state, setState }}>
      <RegionItemContext.Provider
        value={{ state: regionItemState, setState: setRegionItemState }}
      >
        <RegionTrendContext.Provider
          value={{ state: regionTrendState, setState: setRegionTrendState }}
        >
          <RegionTableContext.Provider
            value={{
              prefState: regionTablePrefState,
              setPrefState: setRegionTablePrefState,
              cityState: regionTableCityState,
              setCityState: setRegionTableCityState,
            }}
          >
            <Layout />
          </RegionTableContext.Provider>
        </RegionTrendContext.Provider>
      </RegionItemContext.Provider>
    </AppContext.Provider>
  );
};
