import './AddProductModal.scss';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useState } from 'react';
import {Button, Modal, Form} from 'react-bootstrap';
import { useDispatch } from 'react-redux';
import { updateShoppingListProducts } from '../../../redux/shopSlice';

const AddProductModal = ({shoppingLists, productId, productName, productPrice, addFunction, updateFunction}) => {
  const [show, setShow] = useState(false);
  const dispatch = useDispatch();

  const [productAmount, setProductAmount] = useState(1);

  const handleClose = () => setShow(false);
  const handleShow = () => {setShow(true); handleShoppingListChange(shoppingLists[0]["id"]);}

  const handleSubmit = (e) => {
    e.preventDefault();

    let requestData = {
      "productId": productId,
      "amount": e.target.formAmount.value,
      "shoppingListId": e.target.formSelection.value
    }
    console.log(requestData);
    
    let data = checkIfProductInTheListAlready(parseInt(e.target.formSelection.value));
    let shoppingListProductId = data["listProductId"];
    let isProductInTheList = data["amount"] > 0 ? true : false

    if (isProductInTheList){ // Product already exist update
      requestData["id"] = shoppingListProductId;
      updateFunction(requestData);
    } else{
      addFunction(requestData);
    }
    dispatch(updateShoppingListProducts(requestData));
    handleClose();
  }

  const handleShoppingListChange = (shoppingListId) => {
    const productAmount = checkIfProductInTheListAlready(parseInt(shoppingListId));
    productAmount === 0 ? setProductAmount(1) : setProductAmount(productAmount["amount"]);
  }

  const checkIfProductInTheListAlready = (shoppingListId) => {
    var temp = shoppingLists.filter(x => x.id === shoppingListId)[0]["products"]
    .filter(p => p.product["id"] === productId);
    if (temp[0] === undefined)
      return 0;
    else
      return temp[0]
  }

  return (
    <div>
      <Button className="addListButton" variant="warning" onClick={handleShow}>ADD TO LIST</Button>

      <Modal show={show}
        onHide={handleClose}
        backdrop="static"
        keyboard={false}>
        <Modal.Header closeButton>
          <Modal.Title>ADD PRODUCT TO LIST</Modal.Title>
        </Modal.Header>
        <Modal.Body>

          <Form onSubmit={handleSubmit}>
            <Form.Group controlId="formProductName">
              <Form.Label>Product</Form.Label>
              <Form.Control type="text" defaultValue={productName} disabled/>
            </Form.Group>

            <Form.Group controlId="formProductName">
              <Form.Label>Price</Form.Label>
              <Form.Control type="text" defaultValue={`₺ ${productPrice}`} disabled/>
            </Form.Group>

            <Form.Group controlId="formProductName">
              <Form.Label>Total Price</Form.Label>


              <Form.Control type="text" value={`₺ ${(Math.round(productPrice * productAmount * 100) / 100).toFixed(2)}`} disabled/>
            </Form.Group>

            <Form.Group controlId="formAmount">
              <Form.Label>Amount</Form.Label>
              <Form.Control type="number" placeholder="Amount of Product" value={productAmount}
              onInput={(e) => {if(e.target.value < 0) setProductAmount(e.target.value *= -1);
              else if (e.target.value == 0) setProductAmount(1); else { setProductAmount(e.target.value); console.log("t")} } }/>
            </Form.Group>


            <Form.Group controlId="formSelection">
              <Form.Label>Shopping List</Form.Label>
              <Form.Select required onChange={(e) => {handleShoppingListChange(e.target.value)}}>
                {
                  shoppingLists.filter(x => x.isEditable === true).map(sl => {return(
                    <option key={sl.id} value={sl.id}>{sl.name}</option>
                  )})
                }
              </Form.Select>
            </Form.Group>
            <br/>
            <Button variant="primary" type="submit">
              ADD
            </Button>
          </Form>

        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  )
}

export default AddProductModal