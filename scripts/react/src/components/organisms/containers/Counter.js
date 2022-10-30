"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_1 = require("react");
var reducer = function (currentCount, action) {
    switch (action) {
        case 'INCREMENT':
            return currentCount + 1;
        case 'DECREMENT':
            return currentCount - 1;
        case 'DOUBLE':
            return currentCount * 2;
        case 'RESET':
            return 0;
        default:
            return currentCount;
    }
};
var Counter = function (props) {
    var initialValue = props.initialValue;
    var _a = (0, react_1.useReducer)(reducer, initialValue), count = _a[0], dispatch = _a[1];
    return (React.createElement("div", null,
        React.createElement("p", null,
            "Count: ",
            count),
        React.createElement("button", { onClick: function () { return dispatch('DECREMENT'); } }, "-"),
        React.createElement("button", { onClick: function () { return dispatch('INCREMENT'); } }, "+"),
        React.createElement("button", { onClick: function () { return dispatch('DOUBLE'); } }, "\u00D72"),
        React.createElement("button", { onClick: function () { return dispatch('RESET'); } }, "Reset")));
};
exports.default = Counter;
//# sourceMappingURL=Counter.js.map