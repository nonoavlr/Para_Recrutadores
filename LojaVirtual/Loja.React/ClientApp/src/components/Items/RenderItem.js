import React, {useContext, useEffect, useState} from 'react';
import ProductContext from '../../ProductContext';
import {useParams} from 'react-router-dom';
import Carousel from 'react-bootstrap/Carousel'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import '../CartRenderItem.css'
import 'bootstrap/dist/css/bootstrap.min.css';

export function RenderItem(){

    const {itemID} = useParams();
    const [itemFetch, setFetch] = useState();
    const {setCart} = useContext(ProductContext);
    const [cartID, setCartID] = useState();

    const fetchItem = () => {
        fetch('./product.json')
        .then(res => res.json())
        .then(data => {
            setFetch(data)
            if(!cartID) {setCartID(data.stocksize[0].stockSizeID)}
        });
    }

    useEffect(
        () => {fetchItem()},[itemFetch]
    )


    const handleSubmit = (e) => {
        e.preventDefault();
        let stocksize = itemFetch.stocksize.filter(id => id.stockSizeID == cartID);
        let cartItem = { ...itemFetch, stocksize };
        setCart(cart => [...cart, cartItem])
    }


    return(
        <div>
            {itemFetch &&
                <div className='item_layout'>
                    <div className='item_carousel'>
                        <Carousel interval={null} bsPrefix='carousel'>
                            {
                                itemFetch.database.map(i => {
                                    return(
                                        <Carousel.Item key={i.databaseID} bsPrefix='carousel-item'>
                                            <img
                                            className="d-block w-100"
                                            src={i.link}
                                            alt={itemFetch.title}
                                            />
                                        </Carousel.Item>
                                    )
                                })

                            }         
                        </Carousel>
                    </div>
                    <div className='item_form'>
                        <Form onSubmit = {handleSubmit}>
                            <Form.Group>
                                <Form.Label>
                                    <p>{itemFetch.title}</p>
                                    <p>{itemFetch.name}</p>
                                    <p>{itemFetch.description}</p>
                                    <p>R${(itemFetch.price).toLocaleString('pt-br', { minimumFractionDigits: 2 })}</p>
                                    <p>Escolha o Tamanho</p>
                                </Form.Label>
                                <Form.Control as='select' onChange={(e) => {setCartID(e.target.value)}}>
                                    {
                                        itemFetch.stocksize.map(i =>
                                            {
                                                return(
                                                <option key={i.stockSizeID} value={i.stockSizeID}>{i.size}</option>  
                                                )
                                            })
                                    }
                                </Form.Control>                 
                            </Form.Group>
                            <Button variant='primary' type='submit'>Adicionar ao Carrinho</Button>
                        </Form>
                    </div>
                </div>
            }
        </div>
    )
}