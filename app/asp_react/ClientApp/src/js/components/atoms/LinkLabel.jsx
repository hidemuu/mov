import React from "react";
import { Link } from "react-router-dom";

export default class LinkLabel extends React.Component {
    render() {
        const { content } = this.props;
        return (
            <Link color="inherit" to={link}>
                {content}
            </Link>
        );
    }
}