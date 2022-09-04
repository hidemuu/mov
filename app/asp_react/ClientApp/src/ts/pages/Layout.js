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
exports.Layout = void 0;
var React = require("react");
var react_router_dom_1 = require("react-router-dom");
var Footer_1 = require("../components/atoms/Footer");
var Layout = /** @class */ (function (_super) {
    __extends(Layout, _super);
    function Layout() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Layout.prototype.render = function () {
        var containerStyle = {
            marginTop: "0px"
        };
        console.log("layout");
        console.log(this.props.children);
        return (React.createElement("div", null,
            React.createElement("div", { className: "container", style: containerStyle },
                React.createElement("div", { className: "row" },
                    React.createElement("div", { className: "col-lg-12" }, this.props.children)),
                React.createElement(Footer_1.default, { title: "Covid Reader" }))));
    };
    return Layout;
}(React.Component));
exports.Layout = Layout;
exports.default = (0, react_router_dom_1.withRouter)(Layout);
//# sourceMappingURL=Layout.js.map