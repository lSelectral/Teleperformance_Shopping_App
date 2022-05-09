import { useEffect, useState } from 'react'
import Product from '../Product/Product'
import './Products.scss'
import {categoryEndpoint, GETALL, productEndpoint} from '../../utility/apiCalls'
import Filters from '../Filters/Filters'
const Products = ({filterCategory, keyWord}) => {
  const [productDatas, setProductDatas] = useState([]);

  useEffect(() => {
    GETALL(productEndpoint, (data) => setProductDatas(data.data), null);
  }, [])

  return (
    <div>
        <div className="products-container">
            <div className="products-wrapper">
              {
                productDatas.filter(x => x.name.toLowerCase().includes(keyWord.toLowerCase()) && 
                (x.category === filterCategory || filterCategory === "ALL")).map(p => {
                return(
                  <Product productData={p} key={p.id}/>
                )
                })
              }
            </div>
        </div>
    </div>
  )
}

export default Products