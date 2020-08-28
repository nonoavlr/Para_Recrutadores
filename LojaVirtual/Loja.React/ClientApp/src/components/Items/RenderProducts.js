import React, {useContext, useState } from 'react';
import ProductContext from '../../ProductContext';
import Carousel from 'react-bootstrap/Carousel'
import './RenderProducts.css'
import 'bootstrap/dist/css/bootstrap.min.css';

export function RenderProducts({ gender }){

    const { products, setProducts } = useContext(ProductContext);

    const filterByGender = gender => arr => arr.gender === gender || arr.gender === 'Both';

    return (
        <div>
            {products &&
                <div className='items_vitrine_ul'>
                {
                    products.filter(filterByGender(gender)).map
                        (item => {
                            return (
                                <div className='items_vitrine_li' key={item.productID}>
                                    <div className='imagens_carrousel_ul'>
                                    <Carousel interval={null} bsPrefix='carousel'>
                                        {
                                            item.database.map(i => {
                                                return (
                                                        <Carousel.Item bsPrefix='carousel-item'>
                                                            <img
                                                            className="d-block w-100"
                                                            src={i.link}
                                                            alt={item.title}
                                                            />
                                                        </Carousel.Item>
                                                    )
                                            })
                                        }
                                    </Carousel>  
                                    </div>
                                    <p>Titulo: {item.title}</p>
                                    <p>Nome: {item.name}</p>
                                    <p>Descrição: {item.description}</p>
                                    <p>Preço: R$ {(item.price).toLocaleString('pt-br', { minimumFractionDigits: 2 })}</p>
                                    <div className='stocksize_ul'>
                                        {
                                            item.stockSize.map(i => {
                                                return (
                                                    <div className='stocksize_li' key={i.stockSizeID}>Tamanho: {i.size}, Estoque: {i.stock}</div>
                                                )
                                            })
                                        }
                                    </div>
                                </div>
                            )
                        })   
                }
                </div>
            }
        </div>
    )
}