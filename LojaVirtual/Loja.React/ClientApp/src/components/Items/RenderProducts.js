import React, {useContext } from 'react'
import ProductContext from '../../ProductContext'

export function RenderProducts({ gender }){

    const { products, setProducts } = useContext(ProductContext);

    const filterByGender = gender => arr => arr.gender === gender || arr.gender === 'Both';

    return (
        <div>
            {products &&
                <ul>
                {
                    products.filter(filterByGender(gender)).map
                        (item => {
                            return (
                                <li key={item.productID}>
                                    <p>Titutlo: {item.title}</p>
                                    <p>Nome: {item.name}</p>
                                    <p>Descrição: {item.description}</p>
                                    <p>Preço: R$ {(item.price).toLocaleString('pt-br', { minimumFractionDigits: 2 })}</p>
                                    <ul>
                                        {
                                            item.stockSize.map(i => {
                                                return (
                                                    <li key={i.stockSizeID}>Tamanho: {i.size}, Estoque: {i.stock}</li>
                                                )
                                            })
                                        }
                                    </ul>
                                </li>
                            )
                        })   
                }
                </ul>
            }
        </div>
    )
}