import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler } from 'reactstrap';
import { Link } from "react-router-dom";
import NavContent from '../atoms/NavContent';

export default class NavBar extends React.Component {
    render() {
        const { urls, name, toggleNavbar, isCollapsed } = this.props;
        return (
            <header className="sticky-top">
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white bg-white border-bottom box-shadow mb-3" light>
          <Container>
                        <NavbarBrand tag={Link} to="/">{ name }</NavbarBrand>
                <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!isCollapsed} navbar>
                            <ul className="navbar-nav flex-grow">
                                {urls.map((url, index) => (
                                    <NavContent url={url.url} content={url.content} />))}
                            </ul>
                    </Collapse>
          </Container>
        </Navbar>
      </header>
            
        );
    }
}