import React, { useContext } from 'react';
import ProductContext from '../../ProductContext';
import { Link } from 'react-router-dom';
import Carousel from 'react-bootstrap/Carousel'
import './RenderProducts.css'
import 'bootstrap/dist/css/bootstrap.min.css';

export function RenderProducts({ gender }){

    const { products } = useContext(ProductContext);

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
                                    <Link to={'/Item/' + item.productID}>
                                        <div className='imagens_carrousel_ul'>
                                                <Carousel interval={null} bsPrefix='carousel'>
                                                    {
                                                        item.database.map(i => {
                                                            return (
                                                                <Carousel.Item key={i.databaseID} bsPrefix='carousel-item'>
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
                                        <p>{item.title}</p>
                                        <p>{item.name}</p>
                                        <p>{item.description}</p>
                                        <p>{(item.price).toLocaleString('pt-br', { minimumFractionDigits: 2 })}</p>
                                    </Link>
                                </div>
                            )
                        })   
                }
                </div>
            }
        </div>
    )
}