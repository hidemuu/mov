import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import { AppContext } from './AppContext';
import AppRoutes from './AppRoutes';
import { Layout } from './Layout';
import { webLightTheme } from '@fluentui/react-components';
import './custom.css';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Routes>
                    {AppRoutes.map((route, index) => {
                        const { element, ...rest } = route;
                        return <Route key={index} {...rest} element={element} />;
                    })}
                </Routes>
            </Layout>
        );
    }
}