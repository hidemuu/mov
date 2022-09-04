import React from "react";
import { NavItem, NavLink } from 'reactstrap';
import { Link } from "react-router-dom";

export default class NavContent extends React.Component {
    render() {
        const { url, content } = this.props;
        return (
            <NavItem>
                {/* <NavLink tag={Link} className="text-dark" to="/"><HomeRoundedIcon />Home</NavLink> */}
                <NavLink tag={Link} className="text-dark" to={url}>{ content }</NavLink>
            </NavItem>
        );
    }
}