import * as React from "react";
import { Route } from 'react-router';

import Layout from './pages/Layout';
import Home from './pages/Home';

export default class App extends React.Component<{}> {

    render(): JSX.Element {
        return (
            <div>
            </div>
            //<Layout>
            //    <Route exact path='/' component={Home} />
            //</Layout>
        );
    }
}