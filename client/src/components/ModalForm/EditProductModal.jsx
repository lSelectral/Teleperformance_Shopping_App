import 'bootstrap/dist/css/bootstrap.min.css';
import { useState } from 'react';
import {Button, Modal, Form} from 'react-bootstrap';
import { useSelector } from 'react-redux';

const EditProductModal = ({rowData, editFunction}) => {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  
  let categories = useSelector((state) => state.categories);
  
  const handleSubmit = (e) => {
    e.preventDefault();

    let requestData = {
        "id": rowData["id"],
        "name": e.target.formName.value,
        "description": e.target.formDescription.value,
        "imageUrl": e.target.formImageUrl.value,
        "categoryId": parseInt(e.target.formCategoryId.value),
        "color": e.target.formColor.value,
        "price": parseFloat(e.target.formPrice.value)
      }
      console.log(requestData);
      editFunction(requestData);
      handleClose();
  }
  
  return (
    <div>
      <Button variant="primary" onClick={handleShow}>EDIT</Button>

      <Modal show={show}
        onHide={handleClose}
        backdrop="static"
        keyboard={false}>
        <Modal.Header closeButton>
          <Modal.Title>EDIT PRODUCT FORM</Modal.Title>
        </Modal.Header>
        <Modal.Body>

          <Form onSubmit={handleSubmit}>
            <Form.Group controlId="formId">
              <Form.Label>Product ID</Form.Label>
              <Form.Control disabled type="number" defaultValue={rowData["id"]}/>
            </Form.Group>
            <Form.Group controlId="formName">
              <Form.Label>Product Name</Form.Label>
              <Form.Control type="text" placeholder="Product Name" defaultValue={rowData["name"]} required pattern="[A-Za-z\s]+"/>
            </Form.Group>
            <Form.Group controlId="formDescription">
              <Form.Label>Description</Form.Label>
              <Form.Control type="text" placeholder="Product Description" defaultValue={rowData["description"]} required/>
            </Form.Group>
            <Form.Group controlId="formColor">
              <Form.Label>Color</Form.Label>
              <Form.Control type="text" placeholder="Product Color" defaultValue={rowData["color"]} required pattern="[A-Za-z]+"/>
            </Form.Group>
            <Form.Group controlId="formPrice">
              <Form.Label>Price</Form.Label>
              <Form.Control type="number" placeholder="Product Price" defaultValue={rowData["price"]} step="0.01"required/>
            </Form.Group>
            <Form.Group controlId="formCategoryId">
                <Form.Label>Category</Form.Label>
                <Form.Select defaultValue={categories.filter(x => x.name === rowData["category"])[0].id}>
                  {
                    categories.map(c => {return(
                      <option key={c.id} value={c.id}>{c.name}</option>
                    )})
                  }
                </Form.Select>
            </Form.Group>
            <Form.Group controlId="formImageUrl">
              <Form.Label>Image URL</Form.Label>
              <Form.Control type='url' placeholder="Image URL" defaultValue={rowData["imageUrl"]} required/>
            </Form.Group>

            <br/>

            <Button variant="primary" type="submit">
                CREATE
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

export default EditProductModal