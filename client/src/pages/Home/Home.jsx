import './Home.scss';
import React from 'react';
import FeaturedInfo from '../../components/FeaturedInfo/FeaturedInfo';
import Products from '../../components/Products/Products';
import ShoppingListSidebar from '../../components/ShoppingListSidebar/ShoppingListSidebar';


const Home = () => {
  return (
    <div className='home'>
        <Products/>
        <ShoppingListSidebar/>
    </div>
  )
}

export default Home