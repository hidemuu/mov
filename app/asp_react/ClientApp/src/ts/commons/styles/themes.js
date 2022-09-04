"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var styles_1 = require("@material-ui/core/styles");
var colors = require("@material-ui/core/colors");
var themes = (0, styles_1.createTheme)({
    typography: {
        fontFamily: [
            "Noto Sans JP",
            "Lato",
            "游ゴシック Medium",
            "游ゴシック体",
            "Yu Gothic Medium",
            "YuGothic",
            "ヒラギノ角ゴ ProN",
            "Hiragino Kaku Gothic ProN",
            "メイリオ",
            "Meiryo",
            "ＭＳ Ｐゴシック",
            "MS PGothic",
            "sans-serif",
        ].join(","),
    },
    palette: {
        primary: { main: colors.blue[800] }, // テーマの色
    },
});
exports.default = themes;
//# sourceMappingURL=themes.js.map