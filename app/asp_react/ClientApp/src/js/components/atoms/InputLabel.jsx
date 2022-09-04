import React from "react";
import Input from "@material-ui/core/InputLabel";

export default class InputLabel extends React.Component {
    render() {
        const { content } = this.props;
        return (
            <Input>{content}</Input>
        );
    }
}