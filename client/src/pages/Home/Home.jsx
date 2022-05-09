import './Home.scss';
import React, { useEffect, useState } from 'react';
import Products from '../../components/Products/Products';
import ShoppingListSidebar from '../../components/ShoppingListSidebar/ShoppingListSidebar';
import {GETALL, categoryEndpoint} from '../../utility/apiCalls';
import { Search } from '@material-ui/icons';
import { useDispatch, useSelector } from 'react-redux';
import Sidebar from '../../components/Sidebar/Sidebar';
import Navbar from '../../components/Navbar/Navbar';
import { updateCategories } from '../../redux/shopSlice';

const Home = () => {
  const [categories, setCategories] = useState([]);
  const [searchKeyWord, setSearchKeyWord] = useState("");
  const [categoryToFilter, setCategoryToFilter] = useState("ALL");
  const dispatch = useDispatch();

  useEffect(() => {
      GETALL(categoryEndpoint, (data) => {setCategories(data.data); dispatch(updateCategories(data.data)); }, null);
      // GET_ALL_SHOPPING_LIST_FROM_USER(shoppingListEndpoint, (data) => setListData(data.data));
  }, [])

  const handleCategoryChange = (e) => {
    setCategoryToFilter(e.target.value);
  }

  const handleSearchInput = (e) => {
    setSearchKeyWord(e.target.value);
  }

  return (
    <div className="nav-container-sub">
      <Navbar/>
      <div className="main-container">
            <Sidebar/>
            <div className='home'>
                <div className="product-filter-container">
                  <div className='filters-container'>
                      <div className="search-container">
                          <input placeholder='Search' type="text" className="category-search" onInput={handleSearchInput}/>
                          <Search/>
                      </div>
                      
                      <label htmlFor="category-select" className="category-select-label"><b>Category:</b></label>
                      <select name="category-select" className="category-select" onChange={handleCategoryChange}>
                          <option key="ALL" value="ALL" className="category-option">ALL</option>
                          {
                              categories.map(c => {return(
                                  <option key={c.name} value={c.name} className="category-option">{c.name}</option>
                              );})
                          }
                      </select>
                  </div>
                  <Products filterCategory={categoryToFilter} keyWord={searchKeyWord}/>
                </div>


                <ShoppingListSidebar/>
            </div>
          </div>
    </div>


  )
}

export default Home