"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var Name = function () {
    var onChange = function (e) {
        console.log(e.target.value);
    };
    return (React.createElement("div", { style: { padding: '16px', backgroundColor: 'grey' } },
        React.createElement("label", { htmlFor: "name" }, "\u540D\u524D"),
        React.createElement("input", { id: "name", className: "input-name", type: "text", onChange: onChange })));
};
exports.default = Name;
//# sourceMappingURL=Name.js.map