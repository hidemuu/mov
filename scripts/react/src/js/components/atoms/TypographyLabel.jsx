import React from "react";
import Typography from "@material-ui/core/Typography";

export default class TypographyLabel extends React.Component {
    render() {
        const { content } = this.props;
        return (
            <Typography variant="body2" color="textSecondary" align="center">
                {content}
            </Typography>
        );
    }
}