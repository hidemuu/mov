"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Clock = void 0;
var React = require("react");
var react_1 = require("react");
var UPDATE_CYCLE = 1000;
var KEY_LOCALE = 'KEY_LOCALE';
var Locale;
(function (Locale) {
    Locale["US"] = "en-US";
    Locale["JP"] = "ja-JP";
})(Locale || (Locale = {}));
var getLocaleFromString = function (text) {
    switch (text) {
        case Locale.US:
            return Locale.US;
        case Locale.JP:
            return Locale.JP;
        default:
            return Locale.US;
    }
};
var Clock = function () {
    var _a = (0, react_1.useState)(new Date()), timestamp = _a[0], setTimestamp = _a[1];
    var _b = (0, react_1.useState)(Locale.US), locale = _b[0], setLocale = _b[1];
    (0, react_1.useEffect)(function () {
        var timer = setInterval(function () {
            setTimestamp(new Date());
        }, UPDATE_CYCLE);
        return function () {
            clearInterval(timer);
        };
    }, []);
    (0, react_1.useEffect)(function () {
        var savedLocale = localStorage.getItem(KEY_LOCALE);
        if (savedLocale !== null) {
            setLocale(getLocaleFromString(savedLocale));
        }
    }, []);
    (0, react_1.useEffect)(function () {
        localStorage.setItem(KEY_LOCALE, locale);
    }, [locale]);
    return (React.createElement("div", null,
        React.createElement("p", null,
            React.createElement("span", { id: "current-time-label" }, "\u73FE\u5728\u6642\u523B"),
            React.createElement("span", null,
                ":",
                timestamp.toLocaleString(locale)),
            React.createElement("select", { value: locale, onChange: function (e) { return setLocale(getLocaleFromString(e.target.value)); } },
                React.createElement("option", { value: "en-US" }, "en-US"),
                React.createElement("option", { value: "ja-JP" }, "ja-JP")))));
};
exports.Clock = Clock;
//# sourceMappingURL=Clock.js.map