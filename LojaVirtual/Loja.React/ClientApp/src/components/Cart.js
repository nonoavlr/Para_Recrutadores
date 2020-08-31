import React, { useContext } from 'react';
import ProductContext from '../ProductContext';
import Carousel from 'react-bootstrap/Carousel';
import 'bootstrap/dist/css/bootstrap.min.css';

export function Cart(){

  const {cart, setCart} = useContext(ProductContext);

  return (
    <div>
      {cart &&
          <div>
            {
              console.log(cart),
              cart.map(item =>
              {
                return(
                  <div>
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
                    <p>{item.title}</p>
                    <p>{(item.price).toLocaleString('pt-br', { minimumFractionDigits: 2 })}</p>
                  </div>
                )
              })
            }
          </div>
      }
    </div>
  );
}
