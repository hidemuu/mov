import dateFilterType from "../constants/dateFilterType";

export default function getStartDate(endDate: Date, dateFilter: Number) {
    let startDate = endDate;
    if (dateFilter == dateFilterType.WEEK) {
        startDate.setDate(startDate.getDate() - 7);
    } else if (dateFilter == dateFilterType.MONTH) {
        startDate.setDate(startDate.getDate() - 30);
    } else if (dateFilter == dateFilterType.YEAR) {
        startDate.setDate(startDate.getDate() - 365);
    } else {
        startDate.setDate(startDate.getDate() - 365);
    }
    return startDate;
}