import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Cart } from './components/Cart';
import { About } from './components/Items/About';
import { Feminino } from './components/Items/Feminino';
import { Masculino } from './components/Items/Masculino';
import { OffPrice } from './components/Items/OffPrice';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    constructor() {
        super();
        this.state = {
            products: [],
            cart: []
        }
    }

  render () {
    return (
        <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/About' component={About} />
        <Route path='/Feminino' component={Feminino} />
        <Route path='/Masculino' component={Masculino} />
        <Route path='/off-price' component={OffPrice} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}
