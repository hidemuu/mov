import React from "react";
import { INavigationItem } from "../types/INavigationItem";
import {
  HomeRegular,
  SearchRegular,
  CalendarMailRegular,
  DocumentRegular,
  TagMultipleRegular,
  ChartPersonRegular,
} from "@fluentui/react-icons";
import { HomePage } from "pages/Home/containers/HomePage";
import { ResasPage } from "pages/Resas/containers/ResasPage";
import { GamePage } from "pages/Game/GamePage";

export const getNavigation = (isSignedIn: boolean): INavigationItem[] => {
  const navItems: INavigationItem[] = [];

  navItems.push({
    name: "Home",
    url: "",
    icon: <HomeRegular />,
    key: "home",
    requiresLogin: false,
    component: <HomePage />,
    exact: true,
  });

  navItems.push({
    name: "Resas",
    url: "resas",
    icon: <ChartPersonRegular />,
    key: "resas",
    requiresLogin: false,
    component: <ResasPage />,
    exact: true,
  });

  navItems.push({
    name: "Game",
    url: "game",
    icon: <TagMultipleRegular />,
    key: "game",
    requiresLogin: false,
    component: <GamePage />,
    exact: true,
  });

  if (isSignedIn) {
  }
  return navItems;
};
