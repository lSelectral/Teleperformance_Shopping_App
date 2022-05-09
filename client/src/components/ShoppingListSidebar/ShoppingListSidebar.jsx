import './ShoppingListSidebar.scss'

import {
  AddShoppingCartOutlined,
  ArrowDownOutlined,
  ArrowRightOutlined,
  DeleteOutlineOutlined,
  ShoppingCartOutlined,
} from "@material-ui/icons";

import {DELETE, 
GET_ALL_SHOPPING_LIST_FROM_USER, 
POST,
UPDATE,
shoppingListEndpoint,
shoppingListProductEndpoint} 
from '../../utility/apiCalls';

import {useEffect, useState} from 'react';

import {
    Accordion,
    AccordionDetails,
    AccordionSummary,
    Tooltip
} from '@mui/material';

import { AddTask, DesignServicesOutlined, ShoppingCartCheckoutOutlined, ExpandMoreOutlined } from '@mui/icons-material';
import { useDispatch, useSelector } from 'react-redux';
import { updateShoppingLists } from '../../redux/shopSlice';
import { Button, Modal } from 'react-bootstrap';

const ShoppingListSidebar = () => {
    const [listData, setListData] = useState([]);
    const [expanded, setExpanded] = useState(false);
    const dispatch = useDispatch();

    /* MODAL */
    const [modalData, setModalData] = useState({"show":false, "id":0});

    const handleClose = () => setModalData({"show":false, "id":0});
    const handleShow = (id) => setModalData({"show":true, "id":id});
    /* MODAL */

    let shoppingListProducts = useSelector((state) => state.shoppingListProducts);

    useEffect(() => {
        GET_ALL_SHOPPING_LIST_FROM_USER((data) => {dispatch(updateShoppingLists(data.data)); setListData(data.data);});
    }, [shoppingListProducts]);

    const handleChange = (panel) => (event, isExpanded) => {
        setExpanded(isExpanded ? panel : false);
    };

    const handleCreateNewShoppingList = (e) => {
        e.preventDefault();
        if (localStorage.getItem("userId") === null)
            return;
        const data = {
            "name": e.target.newListInput.value,
            "userId": localStorage.getItem("userId")
        };
        POST(shoppingListEndpoint, 
            (x) => GET_ALL_SHOPPING_LIST_FROM_USER((data) => { setListData(data.data); dispatch(updateShoppingLists(data.data)) }, null) ,
             data, null);
        e.target.newListInput.value = "";
    }

    const handleShoppingListActivation = (e, listData) => {
        UPDATE(shoppingListEndpoint, (d) => {
            GET_ALL_SHOPPING_LIST_FROM_USER((data) => { setListData(data.data); dispatch(updateShoppingLists(data.data)) }, null);
        }, // OnSuccessful
        {
            id: listData["id"],
            name: listData["name"],
            isEditable: !listData["isEditable"],
            userId: localStorage.getItem("userId")
        },
        null
        );
    }

    const handleShoppingListCompletion = (e,d) => {
        // console.log("Finish shopping");
        var unMarkedProductCount = d["products"].filter(p => p["isAddedToCart"] === false).length;
        // console.log(unMarkedProductCount)
        unMarkedProductCount > 0 ? handleShow(d["id"]) : handleListDelete(d["id"]);
    }

    const handleListDelete = (listId) => {
        if (listData.filter(x => x.id === listId)[0]["isEditable"]){
            DELETE(shoppingListEndpoint, null, listId, null);
            setListData(listData.filter(x => x.id !== listId));
            dispatch(updateShoppingLists(listData.filter(x => x.id !== listId)));
        }
    }

    const handleAddToCart = (e, id, amount, productId, shoppingListId, isAddedToCart) => {
        console.log(isAddedToCart);
        var requestData = {
            "id": id,
            "amount": amount,
            "productId": productId,
            "shoppingListId": shoppingListId,
            "isAddedToCart": isAddedToCart ? false : true
        };
        console.log(requestData);
        UPDATE(shoppingListProductEndpoint, (d) => {
            GET_ALL_SHOPPING_LIST_FROM_USER((data) => { setListData(data.data); dispatch(updateShoppingLists(data.data)) }, null);
        }, requestData, null);
    }

    const handleProductDelete = (e, id) => {
        console.log(id)
        DELETE(shoppingListProductEndpoint, (d) => {
            GET_ALL_SHOPPING_LIST_FROM_USER((data) => { setListData(data.data); dispatch(updateShoppingLists(data.data)) }, null);
        }, id, null);
    }

    return (
        <div className='list-sidebar'>
            <div className="list-sidebarWrapper">
                <div className="list-sidebarMenu">
                    <h3 className="list-sidebarTitle">Shopping Lists</h3>
                    <ul className="list-sidebarList">
                        
                        <form className="input-container" onSubmit={handleCreateNewShoppingList}>
                            <label htmlFor='newListInput'>New List Name:</label>
                            <input name="newListInput" className='new-shopping-list-input' 
                            type="text" pattern="[A-Za-z]+" maxLength={32} required></input>

                            <button type='submit' className="list-sidebarListItem create-button">
                                <AddShoppingCartOutlined/>
                                Create New
                            </button>
                        </form>

                        <br/>

                        {
                            listData.map(d => {return(
                                <Accordion TransitionProps={{ unmountOnExit: true }} key={d.id} 
                                expanded={expanded === d.id} onChange={handleChange(d.id)}>

                                    <AccordionSummary
                                        expandIcon={<ExpandMoreOutlined />}
                                        aria-controls="panel1bh-content"
                                        id="panel1bh-header"
                                    >
                                        <div className="accordion-summary-container">
                                            <div className="icon-name-container">
                                                <ShoppingCartOutlined/>
                                                {d.name} ({d.products.length})
                                            </div>
                                            <div className="action-container">
                                                <Tooltip title="Start Shopping">
                                                    <ShoppingCartCheckoutOutlined 
                                                    // Check if list is editable or not and give style
                                                    className={`going-out-shopping-button ${d.isEditable ? "active" : ""}`}
                                                    onClick={(e) => handleShoppingListActivation(e,d)}/>
                                                </Tooltip>
                                                <Tooltip title="Finish Shopping">
                                                    <AddTask className="shopping-completed-button"
                                                    onClick={(e) => handleShoppingListCompletion(e,d)}/>
                                                </Tooltip>
                                                <Tooltip title="Delete Shopping List">
                                                    <DeleteOutlineOutlined className='delete-button' 
                                                    onClick={(e) => handleListDelete(d.id)}/>
                                                </Tooltip>
                                            </div>
                                        </div>

                                    </AccordionSummary>

                                    <AccordionDetails>
                                        <div className="list-product-container">
                                            {d.products.map(products => {return(
                                                <span key={products.product.id} 
                                                className={`product-title ${products.isAddedToCart ? "inCart" : "outCart"}`}>
                                                    <span className="list-product-name">Name: {products.product.name}</span>
                                                    <span className="list-product-icon">Category: {products.product.category}</span>
                                                    <span className="list-product-amount">Amount: {products.amount}</span> 
                                                    <hr style={{margin:7}}/>
                                                    <div className="product-action-container">
                                                        <Button style={{"fontWeight": "bold"}} size="sm" 
                                                            variant={`${products.isAddedToCart ? "warning" : "success"}`}
                                                            onClick={(e) => 
                                                            handleAddToCart(e, 
                                                            products.listProductId,
                                                            products.amount,
                                                            products.product.id,
                                                            d.id,
                                                            products.isAddedToCart)}>
                                                            {products.isAddedToCart ? "REMOVE FROM CART" : "ADD TO CART"}
                                                        </Button>
                                                        <Button style={{"fontWeight": "bold"}} size="sm" variant='danger' 
                                                        onClick={(e) => handleProductDelete(e,products.listProductId)}>DELETE</Button>
                                                    </div>
                                                </span>
                                            )})}
                                        </div>
                                    </AccordionDetails>
                                </Accordion>
                            )})
                        }

                    </ul>
                </div>

                <Modal show={modalData["show"]}
                    onHide={handleClose}
                    backdrop="static"
                    keyboard={false}>
                    <Modal.Header closeButton>
                    <Modal.Title>There are products, you didn't add to the cart. Still want to delete it?</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>


                    </Modal.Body>
                    <Modal.Footer>
                    <Button variant="danger" onClick={(e) => {handleListDelete(modalData["id"]); handleClose();} }>
                        DELETE!!!
                    </Button>
                    <Button variant="info" onClick={handleClose}>
                        Close
                    </Button>
                    </Modal.Footer>
                </Modal>

            </div>
        </div>
    )
};

export default ShoppingListSidebar;
