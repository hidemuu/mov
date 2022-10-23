declare namespace Field {

    
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

    // Table
    export interface ITableIndex {
        endDate: Date,
        tabNumber: number
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