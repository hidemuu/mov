import * as React from "react";
import Typography from "@material-ui/core/Typography";
import { Link } from "react-router-dom";

export default class Copyright extends React.Component<Model.ICopyright, {}> {

    render(): JSX.Element {
        return (
            <Typography variant="body2" color="textSecondary" align="center">
                {"Copyright © "}
                <Link color="inherit" to="/">
                    {this.props.content}
                </Link>{" "}
                {new Date().getFullYear()}
                {"."}
            </Typography>
        );
    }
}