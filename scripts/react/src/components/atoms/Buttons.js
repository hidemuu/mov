"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var DecrementButton = function (props) {
    var onClick = props.onClick;
    console.log('Decrement');
    return React.createElement("button", { onClick: onClick }, "Decrement");
};
var IncrementButton = React.memo(function (props) {
    var onClick = props.onClick;
    console.log('Increment');
    return React.createElement("button", { onClick: onClick }, "Increment");
});
//# sourceMappingURL=Buttons.js.map