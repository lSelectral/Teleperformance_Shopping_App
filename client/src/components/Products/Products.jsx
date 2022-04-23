import { useEffect, useState } from 'react'
import Product from '../Product/Product'
import './Products.scss'
import {GETALL, productEndpoint} from '../../utility/apiCalls'
const Products = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    GETALL(productEndpoint, (data) => setProducts(data.data));
  }, [])


  return (
    <div>
        <div className="products-container">
            <div className="products-wrapper">
                <Product/>
                <Product/>
                <Product/>
            </div>
        </div>
    </div>
  )
}

export default Products