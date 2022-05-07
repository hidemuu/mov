import * as React from "react";
import Typography from "@material-ui/core/Typography";

export default class TypographyLabel extends React.Component<Model.ILabel> {

    render(): JSX.Element {
        return (
            <Typography variant="body2" color="textSecondary" align="center">
                {this.props.content}
            </Typography>
        );
    }
}