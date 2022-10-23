import React from "react";
import Typography from "@material-ui/core/Typography";
import { Link } from "react-router-dom";

export default class Copyright extends React.Component {
    render() {
        const { content } = this.props;
        return (
            <Typography variant="body2" color="textSecondary" align="center">
                {"Copyright © "}
                <Link color="inherit" to="/">
                    {content}
                </Link>{" "}
                {new Date().getFullYear()}
                {"."}
            </Typography>
        );
    }
}