"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Input = void 0;
var React = require("react");
var react_1 = require("react");
var useInput = function () {
    var _a = (0, react_1.useState)(''), state = _a[0], setState = _a[1];
    var onChange = (0, react_1.useCallback)(function (e) {
        setState(e.target.value);
    }, []);
    (0, react_1.useDebugValue)("Input: ".concat(state));
    return [state, onChange];
};
var Input = function () {
    var _a = useInput(), text = _a[0], onChangeText = _a[1];
    return (React.createElement("div", null,
        React.createElement("input", { type: "text", value: text, onChange: onChangeText }),
        React.createElement("p", null,
            "Input: ",
            text)));
};
exports.Input = Input;
//# sourceMappingURL=Input.js.map