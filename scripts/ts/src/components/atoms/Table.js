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
var material_table_1 = require("material-table");
var Table = /** @class */ (function (_super) {
    __extends(Table, _super);
    function Table() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Table.prototype.render = function () {
        return (React.createElement("div", null,
            React.createElement(material_table_1.default, { title: this.props.title, columns: this.props.columns, data: this.props.data, options: {
                    paging: false,
                    maxBodyHeight: 500,
                    headerStyle: {
                        position: 'sticky',
                        top: 0,
                        minWidth: 150,
                    },
                } })));
    };
    return Table;
}(React.Component));
exports.default = Table;
//# sourceMappingURL=Table.js.map