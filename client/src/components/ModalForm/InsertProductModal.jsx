import 'bootstrap/dist/css/bootstrap.min.css';
import './InsertProductModal.scss';
import { useState } from 'react';
import {Button, Modal, Form, Image} from 'react-bootstrap';
import { useSelector } from 'react-redux';
import { Search } from '@material-ui/icons';

const InsertProductModal = ({createFunction, setSearchKeyWord, setCategoryToFilter}) => {
  const [show, setShow] = useState(false);
  const [imageUrl, setImageUrl] = useState("");

  const handleClose = () => {setShow(false); setImageUrl("")};
  const handleShow = () => setShow(true);

  let categories = useSelector((state) => state.categories);

  const handleSubmit = (e) => {
    e.preventDefault();

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
      handleClose();
      setImageUrl("");
  }

  const handleUrlInput = (e) => {
    checkURL(e.target.value) ? setImageUrl(e.target.value) : setImageUrl("");
  }

  function checkURL(url) {
    return(url.match(/\.(jpeg|jpg|gif|png)$/) != null);
  }

  const handleCategoryChange = (e) => {
    setCategoryToFilter(e.target.value);
  }

  const handleSearchInput = (e) => {
    setSearchKeyWord(e.target.value);
  }
  
  return (
    <div className='insert-product-modal'>
      <h6 className='insert-product-modal-title'>PRODUCTS</h6>
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
      <Button variant="primary" onClick={handleShow}>CREATE PRODUCT</Button>

      <Modal show={show}
        onHide={handleClose}
        backdrop="static"
        keyboard={false}>
        <Modal.Header closeButton>
          <Modal.Title>CREATE PRODUCT FORM</Modal.Title>
        </Modal.Header>
        <Modal.Body>

          <Form onSubmit={handleSubmit}>
            <div style={{display:'flex'}}>
              <div style={{flex:3}}>
              <Form.Group controlId="formName">
                <Form.Label>Product Name</Form.Label>
                <Form.Control type="text" placeholder="Product Name" required pattern="[A-Za-z\s]+"/>
              </Form.Group>
              <Form.Group controlId="formDescription">
                <Form.Label>Description</Form.Label>
                <Form.Control type="text" placeholder="Product Description" required/>
              </Form.Group>
              <Form.Group controlId="formColor">
                <Form.Label>Color</Form.Label>
                <Form.Control type="text" placeholder="Product Color" required pattern="[A-Za-z]+"/>
              </Form.Group>
              <Form.Group controlId="formPrice">
                <Form.Label>Price</Form.Label>
                <Form.Control type="number" placeholder="Product Price" step="0.01"required/>
              </Form.Group>
              <Form.Group controlId="formCategoryId">
                <Form.Label>Category</Form.Label>
                <Form.Select>
                  {
                    categories.map(c => {return(
                      <option key={c.id} value={c.id}>{c.name}</option>
                    )})
                  }
                </Form.Select>
              </Form.Group>
              <Form.Group controlId="formImageUrl">
                <Form.Label>Image URL</Form.Label>
                <Form.Control onInput={handleUrlInput} type='url' placeholder="Image URL" required/>
              </Form.Group>
              </div>
              {checkURL(imageUrl) ? <img className='test-img' stlye={{width:60, height:60}} src={imageUrl}/> : null}
            </div>


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

export default InsertProductModal