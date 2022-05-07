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
var core_1 = require("@material-ui/core");
var LineChart_1 = require("../atoms/LineChart");
var BarChart_1 = require("../atoms/BarChart");
var styles_1 = require("../../styles/styles");
var ChartSelector = /** @class */ (function (_super) {
    __extends(ChartSelector, _super);
    function ChartSelector() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ChartSelector.prototype.render = function () {
        return (React.createElement("div", null,
            React.createElement(core_1.Grid, { item: true, className: (0, styles_1.default)().grid, xs: 12 }, this.props.type.isBar
                ? React.createElement(BarChart_1.default, { labels: this.props.chart.labels, datasets: this.props.chart.datasets, options: this.props.chart.options })
                : React.createElement(LineChart_1.default, { labels: this.props.chart.labels, datasets: this.props.chart.datasets, options: this.props.chart.options }))));
    };
    return ChartSelector;
}(React.Component));
exports.default = ChartSelector;
//# sourceMappingURL=ChartSelector.js.map