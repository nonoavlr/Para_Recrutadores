import React, { Component, useState, useEffect } from 'react';
import ProductContext from './ProductContext'
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Cart } from './components/Cart';
import { About } from './components/Items/About';
import { RenderProducts } from './components/Items/RenderProducts';
import { RenderItem } from './components/Items/RenderItem';
import { OffPrice } from './components/Items/OffPrice';
import { Entrar } from './components/Identity/Entrar';
import { Registrar } from './components/Identity/Registrar';
import './custom.css'


export default function App(){

    const [products, setProducts] = useState();
    const [cart, setCart] = useState();

    const fetchItems = () => {
        fetch('./data.json')
            .then(res => res.json())
            .then(res => { console.log(res); return res; })
            .then(data => setProducts(data))
    }

    useEffect(
        () => fetchItems(), []
    )


    return (
        <Layout>
            <ProductContext.Provider value={{products, setProducts, cart, setCart}}>
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
                <Route path='/Item/:itemID' component={RenderItem} />
            </ProductContext.Provider>
        </Layout>
    );
}
