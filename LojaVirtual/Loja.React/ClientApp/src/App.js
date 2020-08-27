import React, { Component, useState, useEffect } from 'react';
import ProductContext from './ProductContext'
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Cart } from './components/Cart';
import { About } from './components/Items/About';
import { RenderProducts } from './components/Items/RenderProducts';
import { OffPrice } from './components/Items/OffPrice';
import { Entrar } from './components/Identity/Entrar';
import { Registrar } from './components/Identity/Registrar';
import './custom.css'


export default function App(){

    const [products, setProducts] = useState();

    const fetchItems = () => {
        console.log('passou')
        fetch('Products')
            .then(res => res.json())
            .then(res => { console.log(res); return res; })
            .then(data => setProducts(data))
    }

    useEffect(
        () => fetchItems(), []
    )


    return (
        <Layout>
            <ProductContext.Provider value={{products, setProducts}}>
                <Route exact path='/' component={Home} />
                <Route path='/About' component={About} />
                <Route path='/Cart' component={Cart} />
                <Route path='/Feminino'>
                    <RenderProducts gender='Fem' />
                </Route>
                <Route path='/Masculino'>
                    <RenderProducts gender='Masc'/>
                </Route>
                <Route path='/off-price' component={OffPrice} />
                <Route path='/Login' component={Entrar}/>
                <Route path='/Register' component={Registrar} />
                <Route path='/fetch-data' component={FetchData} />
            </ProductContext.Provider>
        </Layout>
    );
}
