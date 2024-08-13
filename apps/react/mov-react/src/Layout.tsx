import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Header } from "./components/organisms/Header";
import { SideNavigation } from "./components/organisms/SideNavigation";
import { HomePage } from "./pages/Home/containers/HomePage";
import { useIsSignedIn } from "./domains/auth/hooks/useIsSignedIn";
import { INavigationItem } from "./domains/navigations/types/INavigationItem";
import { getNavigation } from "./domains/navigations/services/getNavigation";
import { FluentProvider, makeStyles, mergeClasses, shorthands } from "@fluentui/react-components";
import { tokens } from "@fluentui/react-theme";
import { applyTheme } from "@microsoft/mgt-react";
import { useAppContext } from "./AppContext";

const useStyles = makeStyles({
  sidebar: {
    display: "flex",
    flexDirection: "column",
    flexWrap: "nowrap",
    height: "100%",
    minWidth: "295px",
    boxSizing: "border-box",
    backgroundColor: tokens.colorNeutralBackground6,
  },
  main: {
    backgroundColor: tokens.colorNeutralBackground1,
    display: "flex",
    flexDirection: "row",
    width: "auto",
    height: "calc(100vh - 50px)",
    boxSizing: "border-box",
  },
  minimized: {
    minWidth: "auto",
  },
  page: {
    display: "flex",
    flexDirection: "column",
    flexWrap: "nowrap",
  },
  content: {
    display: "flex",
    flexDirection: "column",
    flexWrap: "nowrap",
    width: "100%",
    height: "auto",
    boxSizing: "border-box",
    ...shorthands.margin("10px"),
    ...shorthands.overflow("auto"),
  },
});

export const Layout: React.FunctionComponent = (theme) => {
  const styles = useStyles();
  const [navigationItems, setNavigationItems] = React.useState<INavigationItem[]>([]);
  const isSignedIn = true;
  const appContext = useAppContext();

  React.useEffect(() => {
    setNavigationItems(getNavigation(isSignedIn));
  }, [isSignedIn]);

  React.useEffect(() => {
    // Applies the theme to the MGT components
    applyTheme(appContext.state.theme.key as any);
  }, [appContext]);

  return (
    <FluentProvider theme={appContext.state.theme.fluentTheme}>
      <div className={styles.page}>
        <BrowserRouter basename={process.env.REACT_APP_BASE_DIR ?? "/"}>
          <Header></Header>
          <div className={styles.main}>
            <div
              className={mergeClasses(
                styles.sidebar,
                `${appContext.state.sidebar.isMinimized ? styles.minimized : ""}`,
              )}
            >
              <SideNavigation items={navigationItems}></SideNavigation>
            </div>
            <div className={styles.content}>
              <Routes>
                {navigationItems.map(
                  (item) =>
                    ((item.requiresLogin && isSignedIn) || !item.requiresLogin) && (
                      <Route path={item.url} element={item.component} key={item.key} />
                    ),
                )}
                <Route path="*" element={<HomePage />} />
              </Routes>
            </div>
          </div>
        </BrowserRouter>
      </div>
    </FluentProvider>
  );
};
