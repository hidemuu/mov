declare namespace Field {

    // FetchData
    export interface IFetchData {
        id: object,
        index: number,
        date: Date,
        calc: string,
        countryName: string,
        prefName: string,
        cityName: string,
        deathNumber: number,
        cureNumber: number,
        patientNumber: number,
        recoveryNumber: number,
        severeNumber: number,
        testNumber: number,
    }

    // Chart
    export interface IChartIndex {
        endDate: Date,
        tabNumber: number
    }

    export interface IChartScreen {
        isAllType: Model.IChartType,
        type: Model.IChartType,
    }

    export interface IChartTemplate {
        calc: string,
        isAll: boolean,
        endDate: Date,
        tabNumber: number
    }

    export interface IChartData {
        data: IFetchData[],
        chart: Model.IChart,
    }

    // Table
    export interface ITableIndex {
        endDate: Date,
        tabNumber: number
    }

    export interface ITableData {
        data: IFetchData[],
        table: Model.ITable,
    }

    // Dashboard
    export interface IDashboard {
        selectedDate: Date,
        selectedTabIndex: number,
    }

    // Settings
    export interface ISettingTemplate {
        open: boolean,
    }

    // Register
    export interface IRegisterTemplate{
        activeStep: number,
        currentState: number,
    }

}