"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var Hello = function () {
    var onClick = function () {
        alert('hello');
    };
    var text = 'Hello, React';
    return (React.createElement("div", { onClick: onClick }, text));
};
exports.default = Hello;
//# sourceMappingURL=Hello.js.map