import * as React from "react";
import CircularProgress from "@material-ui/core/CircularProgress";

export default class Progress extends React.Component<{}> {

    render(): JSX.Element {
        return (
            <CircularProgress color="inherit" />
        );
    }
}