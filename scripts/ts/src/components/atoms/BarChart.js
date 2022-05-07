"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_chartjs_2_1 = require("react-chartjs-2");
var BarChart = /** @class */ (function (_super) {
    __extends(BarChart, _super);
    function BarChart() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    BarChart.prototype.render = function () {
        return (React.createElement(react_chartjs_2_1.Bar, { data: {
                labels: this.props.labels,
                datasets: this.props.datasets,
            }, options: this.props.options }));
    };
    return BarChart;
}(React.Component));
exports.default = BarChart;
//# sourceMappingURL=BarChart.js.map