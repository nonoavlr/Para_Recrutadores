import React, { useContext } from 'react';
import ProductContext from '../ProductContext'
import Carousel from 'react-bootstrap/Carousel';
import Button from 'react-bootstrap/Button';
import './CartRenderItem.css'
import 'bootstrap/dist/css/bootstrap.min.css';

export function Cart(){

  const {cart, setCart} = useContext(ProductContext);


  const removeCart = (index) => {
    const newList = cart.filter((_, dex) => dex !== index)
    setCart(newList)
  }

  return (
    <div className='item_body'>
      {cart &&
          <div className='item_layout'>
            {
              cart.map((item, index) =>
              {
                return(
                  <div className='items_vitrine' key={index}>
                    <div className='item_carousel'>
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
                    <div className='item_form'>
                      <p>{item.title}</p>
                      <p>{item.stocksize[0].size}</p>
                      <p>{(item.price).toLocaleString('pt-br', { minimumFractionDigits: 2 })}</p>
                      <Button variant='primary' type='button' onClick={(e) => {removeCart(index)}}>Remover</Button>
                    </div>
                  </div>
                )
              })
            }
          </div>
      }
    </div>
  );
}
