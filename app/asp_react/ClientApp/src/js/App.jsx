import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './pages/Layout';
import { Home } from './pages/Home';
import { FetchData } from './pages/FetchData';
import { Counter } from './pages/Counter';

import '../assets/css/custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}