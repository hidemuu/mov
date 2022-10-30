declare namespace Model {

    // Label
    export interface ILabel {
        content: string,
    }

    export interface IArticle {
        title: string,
    }

    export interface ICopyright{
        content: string,
    }

    // Chart
    export interface IChart {
        labels: string[],
        datasets: IChartData,
        options: object,
    }

    export interface IChartData {
        label: string,
        numbers: number[],
    }

    export interface IChartType {
        isBar: boolean,
    }

    export interface IChartSelector {
        labels: string[],
        datasets: IChartData[],
        options: object,
        type: IChartType,
    }

    export interface IChartContainer {
        chart: IChart,
        type: IChartType,
        queryLabels: string[],
    }

    export interface IChartScreen {
        chart: IChart,
        queryLabels: object[],
        isAll: boolean,
    }

    export interface IChartTemplate {
        dailyAllCharts: JSX.Element,
        dailyUnitCharts: JSX.Element,
        totalAllCharts: JSX.Element,
        totalUnitCharts: JSX.Element,
    }

    export interface IChartData {
        calc: string,
        endDate: Date,
        isAll: boolean,
        dateFilter: number,
    }

    // Table
    export interface ITable {
        title: string,
        columns: object[],
        data: object[],
    }

    export interface ITableData {
        calc: string,
        endDate: Date,
        dateFilter: number,
    }

    //Tab
    export interface IDateTab {
        onSelectTab: Function,
        selectedTabIndex: number,
        onChangeDatepicker: Function,
        selectedDate: Date,
    }

    // Navigation
    export interface INav {
        url: string,
        content: string,
    }

    export interface INavBar {
        urls: INavBarItem[],
        name: string,
        toggleNavbar: React.MouseEventHandler,
        isCollapsed: boolean,
    }

    export interface INavBarItem {
        url: string,
        content: string,
    }

    // Home
    export interface IHomeTemplate {
        onClickUpdateButton: React.MouseEventHandler,
        contentsTileData: object[],
    }

    // Dashboard
    export interface IDashboardTemplate {
        charts: JSX.Element;
        tables: JSX.Element;
    }

    // Setting
    export interface ISettingTemplate{
        children: React.ReactNode,
        title: string,
    }

    // Register
    export interface IRegisterTemplate{
        currentState: number,
        activeStep: number,
    }

    // Auth
    export interface IAuthUser {
        userId: string,
    }

    export type OperationType = {
        login: (userId: string) => void
        logout: () => void
    }

    // Footer
    export interface IFooter{
        title: string,
    }

    // Header
    export interface IHeader{
        title: string,
    }

    // Layout
    export interface ILayout {
        children: object,
    }

}