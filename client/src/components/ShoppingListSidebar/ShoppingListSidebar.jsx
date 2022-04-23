import './ShoppingListSidebar.scss'
import {
  AddShoppingCartOutlined,
  ArrowDownOutlined,
  ArrowRightOutlined,
  ShoppingCartOutlined,
} from "@material-ui/icons";
import { Link } from "react-router-dom";
import { ADD, GETALL, shoppingListEndpoint } from '../../utility/apiCalls';
import { useState } from 'react';

const ShoppingListSidebar = ({shoppingLists}) => {
    const [textInput, setTextInput] = useState("");
    // var data = GETALL(shoppingListEndpoint, null);

    const handleCreateNewShoppingList = (e) => {
        ADD(shoppingListEndpoint, {"name": textInput});
    }

    return (
        <div className='list-sidebar'>
            <div className="list-sidebarWrapper">
                <div className="list-sidebarMenu">
                    <h3 className="list-sidebarTitle">Shopping Lists</h3>
                    <ul className="list-sidebarList">

                        <input className='new-shopping-list-input' type="text" pattern="[A-Za-z]" 
                        onChange={(e) => setTextInput(e.target.value)}></input>

                        <button onClick={handleCreateNewShoppingList} className="list-sidebarListItem create-button">
                            <AddShoppingCartOutlined/>
                            Create New
                        </button>

                        <li className="list-sidebarListItem">
                                <ArrowRightOutlined/>
                                <ShoppingCartOutlined/>
                                Breakfast List (5)
                            </li>
                            <li className="list-sidebarListItem">
                                <ArrowRightOutlined/>
                                <ShoppingCartOutlined/>
                                Lunch List (2)
                            </li>
                    </ul>
                </div>


            </div>
        </div>
    )
};

export default ShoppingListSidebar;
