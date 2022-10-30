"use strict";
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
var styles_1 = require("@material-ui/core/styles");
//スタイルシート生成
var drawerWidth = 240;
var styles = (0, styles_1.makeStyles)(function (theme) {
    var _a;
    return (0, styles_1.createStyles)({
        root: {
            display: "flex",
        },
        board: {
            backgroundColor: "#F2F2F2",
        },
        home: {
            display: 'flex',
            flexWrap: 'wrap',
            justifyContent: 'space-around',
            overflow: 'hidden',
            backgroundColor: theme.palette.background.paper,
        },
        toolbar: {
            paddingRight: 24,
        },
        toolbarIcon: __assign({ display: "flex", alignItems: "center", justifyContent: "flex-end", padding: "0 8px" }, theme.mixins.toolbar),
        appBar: {
            zIndex: theme.zIndex.drawer + 1,
            transition: theme.transitions.create(["width", "margin"], {
                easing: theme.transitions.easing.sharp,
                duration: theme.transitions.duration.leavingScreen,
            }),
        },
        appBarShift: {
            marginLeft: drawerWidth,
            width: "calc(100% - ".concat(drawerWidth, "px)"),
            transition: theme.transitions.create(["width", "margin"], {
                easing: theme.transitions.easing.sharp,
                duration: theme.transitions.duration.enteringScreen,
            }),
        },
        menuButton: {
            marginRight: 36,
        },
        menuButtonHidden: {
            display: "none",
        },
        title: {
            flexGrow: 1,
        },
        pageTitle: {
            marginBottom: theme.spacing(1),
        },
        drawerPaper: {
            position: "relative",
            whiteSpace: "nowrap",
            width: drawerWidth,
            transition: theme.transitions.create("width", {
                easing: theme.transitions.easing.sharp,
                duration: theme.transitions.duration.enteringScreen,
            }),
        },
        drawerPaperClose: (_a = {
                overflowX: "hidden",
                transition: theme.transitions.create("width", {
                    easing: theme.transitions.easing.sharp,
                    duration: theme.transitions.duration.leavingScreen,
                }),
                width: theme.spacing(7)
            },
            _a[theme.breakpoints.up("sm")] = {
                width: theme.spacing(9),
            },
            _a),
        appBarSpacer: theme.mixins.toolbar,
        content: {
            flexGrow: 1,
            height: "100vh",
            overflow: "auto",
        },
        container: {
            paddingTop: theme.spacing(4),
            paddingBottom: theme.spacing(4),
        },
        paper: {
            padding: theme.spacing(2),
            margin: theme.spacing(1),
            marginTop: "auto",
            display: "flex",
            overflow: "auto",
            flexDirection: "column",
            backgroundColor: "#FFF",
        },
        link: {
            textDecoration: "none",
            color: theme.palette.text.secondary,
        },
        formControl: {
            margin: theme.spacing(2),
            marginBottom: theme.spacing(5),
        },
        gridList: {
            width: 500,
            height: 700,
        },
        typography: {
            marginTop: theme.spacing(0),
            marginBottom: theme.spacing(0),
        },
        grid: {
            margin: "auto",
            paddingTop: 10,
            paddingBottom: 10,
            paddingLeft: 10,
            paddingRight: 10,
        },
        button: {
            marginTop: "auto",
            marginBottom: theme.spacing(5),
            width: "250px",
            height: "200px",
            fontSize: "30px",
            margin: theme.spacing(1),
        },
        backdrop: {
            color: "#fff"
        },
    });
});
exports.default = styles;
//# sourceMappingURL=styles.js.map