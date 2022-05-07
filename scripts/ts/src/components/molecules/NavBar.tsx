import * as React from "react";
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler } from 'reactstrap';
import { Link } from "react-router-dom";
import NavContent from '../atoms/NavContent';

export default class NavBar extends React.Component<Model.INavBar> {

    render(): JSX.Element {
        return (
            <header className="sticky-top">
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white bg-white border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/">{this.props.name}</NavbarBrand>
                        <NavbarToggler onClick={this.props.toggleNavbar} className="mr-2" />
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.props.isCollapsed} navbar>
                            <ul className="navbar-nav flex-grow">
                                {this.props.urls.map((url, index) => (
                                    <NavContent url={url.url} content={url.content} />))}
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }
}