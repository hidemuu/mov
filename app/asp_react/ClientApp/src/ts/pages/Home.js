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
var Home = /** @class */ (function (_super) {
    __extends(Home, _super);
    function Home() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    //マウント時イベントハンドラ
    Home.prototype.componentDidMount = function () {
    };
    //API更新ボタンクリックイベント
    Home.prototype.handleUpdateButtonClick = function () {
        fetch('api/home')
            .then(function (response) {
            if (response.status === 200) {
                return response.text();
            }
            else {
                throw new Error();
            }
        })
            .then(function (data) {
            alert(data);
        })
            .catch(function (error) {
            alert("error");
            console.log(error);
        });
    };
    Home.prototype.render = function () {
        //コンテンツリスト
        var contentsTileData = [];
        return (React.createElement("div", null));
    };
    return Home;
}(React.Component));
exports.default = Home;
//# sourceMappingURL=Home.js.map