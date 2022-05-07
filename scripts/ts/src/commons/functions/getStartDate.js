"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var dateFilterType_1 = require("../constants/dateFilterType");
function getStartDate(endDate, dateFilter) {
    var startDate = endDate;
    if (dateFilter == dateFilterType_1.default.WEEK) {
        startDate.setDate(startDate.getDate() - 7);
    }
    else if (dateFilter == dateFilterType_1.default.MONTH) {
        startDate.setDate(startDate.getDate() - 30);
    }
    else if (dateFilter == dateFilterType_1.default.YEAR) {
        startDate.setDate(startDate.getDate() - 365);
    }
    else {
        startDate.setDate(startDate.getDate() - 365);
    }
    return startDate;
}
exports.default = getStartDate;
//# sourceMappingURL=getStartDate.js.map