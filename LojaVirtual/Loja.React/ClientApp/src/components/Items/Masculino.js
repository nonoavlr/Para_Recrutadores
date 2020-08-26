import React, {useState, useEffect } from 'react'

export function Masculino(){

    const [products, setProducts] = useState();

    const fetchItems = () => {
        console.log('passou')
        fetch('Products')
            .then(res => res.json())
            .then(console.log)
            .then(data => setProducts(data))
    }

    useEffect(
        () => fetchItems(), []
    )


    return (
        <div>
            {products &&
                <ul>
                {
                    products.map(
                        item => {
                            return (
                                <li key={item.productID}>
                                    <p>{item.title}</p>
                                    <p>{item.name}</p>
                                    <p>{item.description}</p>
                                    <p>{item.price}</p>
                                </li>
                            )
                        }
                    )
                }
                </ul>
            }
        </div>
    )
}