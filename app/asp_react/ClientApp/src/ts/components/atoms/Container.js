"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var Container = function (props) {
    var title = props.title, children = props.children;
    return (React.createElement("div", { style: { background: 'red' } },
        React.createElement("span", null, title),
        React.createElement("div", null, children)));
};
exports.default = Container;
//# sourceMappingURL=Container.js.map