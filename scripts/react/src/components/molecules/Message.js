"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var Text = function (props) {
    var content = props.content;
    return (React.createElement("p", { className: "text" }, content));
};
var Message = function (props) {
    var content1 = '';
    var content2 = '';
    return (React.createElement("div", null,
        React.createElement(Text, { content: content1 }),
        React.createElement(Text, { content: content2 })));
};
exports.default = Message;
//# sourceMappingURL=Message.js.map