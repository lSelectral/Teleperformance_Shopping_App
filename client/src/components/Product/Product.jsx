import React from 'react';
import './Product.scss';

const Product = () => {
  return (
    <div className='product-container'>
        <div className="wrapper">
          <img src="https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco/5e1b2266-e664-4ddc-ae5e-511453bb5b6b/air-max-270-g-golf-ayakkab%C4%B1s%C4%B1-gTpCFg.png" alt="Product Image" 
          className="product-img" />
          <br/>
          <span className="product-title">Name: Nike Air</span>
          <span className="product-category">Category: Ayakkabı</span>
          <span className="product-color">Color: Beyaz</span>
          <span className="product-price">Price: 550.00</span>
          <button className="add-to-list">ADD TO LIST</button>
        </div>
    </div>
  )
}

export default Product