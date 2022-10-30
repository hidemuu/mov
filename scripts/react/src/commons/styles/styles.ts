import { createStyles, makeStyles, } from '@material-ui/core/styles';

//スタイルシート生成
const drawerWidth = 240;
const styles = makeStyles((theme) =>
    createStyles({
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
        toolbarIcon: {
            display: "flex",
            alignItems: "center",
            justifyContent: "flex-end",
            padding: "0 8px",
            ...theme.mixins.toolbar,
        },
        appBar: {
            zIndex: theme.zIndex.drawer + 1,
            transition: theme.transitions.create(["width", "margin"], {
                easing: theme.transitions.easing.sharp,
                duration: theme.transitions.duration.leavingScreen,
            }),
        },
        appBarShift: {
            marginLeft: drawerWidth,
            width: `calc(100% - ${drawerWidth}px)`,
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
        drawerPaperClose: {
            overflowX: "hidden",
            transition: theme.transitions.create("width", {
                easing: theme.transitions.easing.sharp,
                duration: theme.transitions.duration.leavingScreen,
            }),
            width: theme.spacing(7),
            [theme.breakpoints.up("sm")]: {
                width: theme.spacing(9),
            },
        },
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
    }),
);

export default styles;