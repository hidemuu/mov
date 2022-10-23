import { Theme } from "@material-ui/core/styles";
import { createTheme } from "@material-ui/core/styles";
import * as colors from "@material-ui/core/colors";

const themes = createTheme({
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

export default themes;