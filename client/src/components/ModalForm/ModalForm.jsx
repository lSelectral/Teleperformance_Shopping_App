import 'bootstrap/dist/css/bootstrap.min.css';
import { useState } from 'react';
import {Button, Modal, Form} from 'react-bootstrap';

const ModalForm = ({data, createFunction}) => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleSubmit = (e) => {
    e.preventDefault();

    if (data["modalModel"] === "Product"){
      let requestData = {
        "name": e.target.formName.value,
        "description": e.target.formDescription.value,
        "imageUrl": e.target.formImageUrl.value,
        "categoryId": parseInt(e.target.formCategoryId.value),
        "color": e.target.formColor.value,
        "price": parseFloat(e.target.formPrice.value)
      }
      console.log(requestData);
      createFunction(requestData);
    } else {
      console.log(e.target.formCategoryName.value);
    }
  }
  
  return (
    <div>
      <Button variant="primary" onClick={handleShow}>
        {data["createButtonTitle"]}
      </Button>

      <Modal show={show}
        onHide={handleClose}
        backdrop="static"
        keyboard={false}>
        <Modal.Header closeButton>
          <Modal.Title>{data["modalTitle"]}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {data["modalModel"] === "Product" ? 

          <Form onSubmit={handleSubmit}>
            <Form.Group controlId="formName">
              <Form.Label>Product Name</Form.Label>
              <Form.Control type="text" placeholder="Product Name" required/>
            </Form.Group>
            <Form.Group controlId="formDescription">
              <Form.Label>Description</Form.Label>
              <Form.Control type="text" placeholder="Product Description" required/>
            </Form.Group>
            <Form.Group controlId="formColor">
              <Form.Label>Color</Form.Label>
              <Form.Control type="text" placeholder="Product Color" required/>
            </Form.Group>
            <Form.Group controlId="formPrice">
              <Form.Label>Price</Form.Label>
              <Form.Control type="number" placeholder="Product Price" step="0.01"required/>
            </Form.Group>
            <Form.Group controlId="formCategoryId">
              <Form.Label>Category ID</Form.Label>
              <Form.Control type='number' placeholder="Product Category ID" required/>
            </Form.Group>
            <Form.Group controlId="formImageUrl">
              <Form.Label>Image URL</Form.Label>
              <Form.Control type='url' placeholder="Image URL" required/>
            </Form.Group>
            <br/>
            <Button variant="primary" type="submit">
              CREATE
            </Button>
          </Form>
          :
          <Form onSubmit={handleSubmit}>
            <Form.Group controlId="formCategoryName">
              <Form.Label>Category Name</Form.Label>
              <Form.Control type='text' placeholder="Category Name" required/>
            </Form.Group>
            <br/>
            <Button variant="primary" type="submit">
              CREATE
            </Button>
          </Form>}

        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          {/* <Button variant="primary">Understood</Button> */}
        </Modal.Footer>
      </Modal>
    </div>
  )
}

export default ModalForm