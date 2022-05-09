import React from 'react';
import './Product.scss';
import {shoppingListProductEndpoint, POST, UPDATE} from '../../utility/apiCalls'
import AddProductModal from '../../components/ModalForm/AddProductModal/AddProductModal'
import { useSelector } from 'react-redux';
import { Tooltip } from '@mui/material';
const Product = ({productData}) => {

  const addProduct = (data) => {
    POST(shoppingListProductEndpoint, null, data, null);
  }

  const updateProduct = (data) => {
    UPDATE(shoppingListProductEndpoint, null, data, null);
  }

  let shoppingLists = useSelector((state) => state.shoppingLists);


  return (
    <div className='product-container'>
        <div className="wrapper">
          <img className="product-img" alt={productData.name} src={productData.imageUrl}/>
          <Tooltip title={productData.name}>
            <span className="product-title">{productData.name}</span>
          </Tooltip>
          <div className="inner-data-container">
            <div className="left-container">
              <span className="left-text">Category:</span>
              <span className="left-text">Color:</span>
              <span className="left-text">Price:</span>
            </div>

            <div className="right-container">
              <span className="product-category">{productData.category}</span>
              <span className="product-color">{productData.color}</span>
              <span className="product-price">₺ {productData.price}</span>
            </div>
          </div>

          <AddProductModal shoppingLists={shoppingLists} productId={productData.id} productPrice={productData.price} 
          productName={productData.name} addFunction={addProduct} updateFunction={updateProduct}/>
        </div>
    </div>
  )
}

export default Product