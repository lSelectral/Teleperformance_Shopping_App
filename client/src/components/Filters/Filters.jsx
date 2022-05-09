import './Filters.scss';
import {GETALL, categoryEndpoint} from '../../utility/apiCalls';
import { Search } from '@material-ui/icons';
import { useState, useEffect } from 'react';
const Filters = () => {
    const [categories, setCategories] = useState([]);
    const sleep = ms => new Promise(r => setTimeout(r, ms));

    useEffect(() => {
        GETALL(categoryEndpoint, (data) => { sleep(2000); setCategories(data.data) }, null);
        return;
    }, [])

    const handleCategoryChange = (e) => {
        console.log(e.target.value);
    }
    
    return (
        <div className='filters-container'>
            <div className="search-container">
                <input placeholder='Search' type="text" className="category-search" />
                <Search/>
            </div>
            
            <label htmlFor="category-select" className="category-select-label"><b>Category:</b></label>
            <select name="category-select" className="category-select" onChange={handleCategoryChange}>
                {
                    categories.map(c => {return(
                        <option key={c.id} value={c.name} className="category-option">{c.name}</option>
                    );})
                }
            </select>
        </div>
    )
}

export default Filters