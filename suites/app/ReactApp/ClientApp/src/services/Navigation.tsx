﻿import { NavigationItem } from '../models/NavigationItem';
import {
    HomeRegular,
    SearchRegular,
    TextBulletListSquareRegular,
    CalendarMailRegular,
    DocumentRegular,
    TagMultipleRegular,
    ChartPersonRegular
} from '@fluentui/react-icons';
import { DashboardPage } from '../pages/DashboardPage';
import { OutlookPage } from '../pages/OutlookPage';
import { SearchPage } from '../pages/SearchPage';
import { HomePage } from '../pages/HomePage';
import { ResasPage } from '../pages/ResasPage';
import { FilesPage } from '../pages/FilesPage';
import { TaxonomyPage } from '../pages/TaxonomyPage';

export const getNavigation = (isSignedIn: boolean) => {
    let navItems: NavigationItem[] = [];

    navItems.push({
        name: 'Home',
        url: '',
        icon: <HomeRegular />,
        key: 'home',
        requiresLogin: false,
        component: <HomePage />,
        exact: true
    });

    navItems.push({
        name: 'Resas',
        url: 'resas',
        icon: <ChartPersonRegular />,
        key: 'resas',
        requiresLogin: false,
        component: <ResasPage />,
        exact: true
    });

    if (isSignedIn) {
        navItems.push({
            name: 'Dashboard',
            url: 'dashboard',
            icon: <TextBulletListSquareRegular />,
            key: 'dashboard',
            requiresLogin: true,
            component: <DashboardPage />,
            exact: true
        });

        navItems.push({
            name: 'Mail and Calendar',
            url: 'outlook',
            icon: <CalendarMailRegular />,
            key: 'outlook',
            requiresLogin: true,
            component: <OutlookPage />,
            exact: true
        });

        navItems.push({
            name: 'Files',
            url: 'files',
            icon: <DocumentRegular />,
            key: 'files',
            requiresLogin: true,
            component: <FilesPage />,
            exact: true
        });

        navItems.push({
            name: 'Taxonomy',
            url: 'taxonomy',
            icon: <TagMultipleRegular />,
            key: 'files',
            requiresLogin: true,
            component: <TaxonomyPage />,
            exact: true
        });

        navItems.push({
            name: 'Search',
            url: 'search',
            pattern: '/search/:query',
            icon: <SearchRegular />,
            key: 'search',
            requiresLogin: true,
            component: <SearchPage />,
            exact: false
        });
    }
    return navItems;
};