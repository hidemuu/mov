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
var ChartSelector_1 = require("../molecules/ChartSelector");
var ChartContainer_1 = require("../molecules/ChartContainer");
var TypographyLabel_1 = require("../atoms/TypographyLabel");
var ChartScreen = /** @class */ (function (_super) {
    __extends(ChartScreen, _super);
    function ChartScreen() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    ChartScreen.prototype.render = function () {
        this.state.isAllType.isBar = false;
        this.state.type.isBar = true;
        return (React.createElement("div", null, this.props.isAll ?
            React.createElement("div", null,
                React.createElement(TypographyLabel_1.default, { content: "\u4E00\u89A7" }),
                React.createElement(ChartSelector_1.default, { chart: this.props.chart, type: this.state.isAllType })) :
            React.createElement("div", null,
                React.createElement(TypographyLabel_1.default, { content: "\u500B\u5225" }),
                React.createElement(ChartContainer_1.default, { chart: this.props.chart, queryLabels: this.props.queryLabels, type: this.state.type }))));
    };
    return ChartScreen;
}(React.Component));
exports.default = ChartScreen;
//# sourceMappingURL=ChartScreen.js.map