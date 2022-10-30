"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_1 = require("react");
var SimpleCounter = function (props) {
    var initialValue = props.initialValue;
    var _a = (0, react_1.useState)(initialValue), count = _a[0], setCount = _a[1];
    return (React.createElement("div", null,
        React.createElement("p", null,
            "Count: ",
            count),
        React.createElement("button", { onClick: function () { return setCount(count - 1); } }, "-"),
        React.createElement("button", { onClick: function () { return setCount(function (prevCount) { return prevCount + 1; }); } }, "+")));
};
exports.default = SimpleCounter;
//# sourceMappingURL=SimpleCounter.js.map