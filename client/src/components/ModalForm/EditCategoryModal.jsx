import 'bootstrap/dist/css/bootstrap.min.css';
import { useState } from 'react';
import {Button, Modal, Form} from 'react-bootstrap';

const EditCategoryModal = ({categoryId, editFunction}) => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleSubmit = (e) => {
    e.preventDefault();

    let requestData = {
        "id": e.target.formId.value,
        "name": e.target.formName.value,
    }
    console.log(requestData);
    editFunction(requestData);
    handleClose();
  }
  
  return (
    <div>
      <Button variant="primary" onClick={handleShow}>Edit</Button>

      <Modal show={show}
        onHide={handleClose}
        backdrop="static"
        keyboard={false}>
        <Modal.Header closeButton>
          <Modal.Title>Edit Category</Modal.Title>
        </Modal.Header>
        <Modal.Body>

          <Form onSubmit={handleSubmit}>
          <Form.Group controlId="formId">
              <Form.Label>Category ID</Form.Label>
              <Form.Control value={categoryId} type="number" placeholder="Category ID" disabled/>
            </Form.Group>
            <Form.Group controlId="formName">
              <Form.Label>New Category Name</Form.Label>
              <Form.Control type="text" placeholder="New Category Name" required pattern="[A-Za-z\s]+"/>
            </Form.Group>
            <br/>
            <Button variant="primary" type="submit">
              UPDATE
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

export default EditCategoryModal