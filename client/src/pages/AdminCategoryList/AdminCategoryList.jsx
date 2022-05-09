import './AdminCategoryList.scss';
import React, { useState, useEffect } from 'react'
import { categoryEndpoint, GETALL, POST, UPDATE, DELETE } from '../../utility/apiCalls';
import { DataGrid } from '@material-ui/data-grid';
import { DeleteOutline } from '@material-ui/icons';
import { Button } from 'react-bootstrap';
import Navbar from '../../components/Navbar/Navbar';
import Sidebar from '../../components/Sidebar/Sidebar';
import EditCategoryModal from '../../components/ModalForm/EditCategoryModal';
import Snackbar from '@mui/material/Snackbar';
import {
  handleSnackbarOpen,
  handleSnackbarClose
} from '../../utility/snackbarUtility';


const AdminCategoryList = () => {
  const [data, setData] = useState([]);
  const [snackbarState, setSnackbarState] = useState({"state": false, "message": "default"});

  const handleDelete = (id) => {
      setData(data.filter((item) => item.id !== id))
      DELETE(categoryEndpoint, null, id);
  }

  useEffect(() => {
      GETALL(categoryEndpoint, (d) => setData(d.data));
  }, [])

  const handleCreateCategory = (e) => {
    e.preventDefault();
    let value = e.target.createCategoryInput.value
    let inputData = {"name": value};
    POST(categoryEndpoint, 
      (d) => setData([...data, {id: d.data, name: value}]),
     inputData, null);

    e.target.createCategoryInput.value = "";
    handleSnackbarOpen(`${value} category added`, setSnackbarState);
  }

  const updateCategory = (inputData) => {
    UPDATE(categoryEndpoint, (d) => {GETALL(categoryEndpoint, (d) => setData(d.data))}, inputData, null);
  }


  const columns = [
    { field: 'id', headerName: 'ID', width: 100 },
    { field: 'name', headerName: 'Name', width: 320},
    { field: 'action', headerName: 'Actions', width: 180, renderCell: (params) => {
        return(
            <>
                <EditCategoryModal key={params.row.id} categoryId={params.row.id} editFunction={updateCategory}/>
                <DeleteOutline className="userListDelete" onClick={() => handleDelete(params.row.id)}/>
            </>
        )
    }},
];


  return (

    <div className="nav-container-sub">
      <Navbar/>
      <div className="main-container">
        <Sidebar/>
        <div className='category-container'>
          <div className="category-wrapper">
            <h6 className='insert-category-modal-title'>CATEGORIES</h6>
            <form className="form" onSubmit={handleCreateCategory}>
              <label htmlFor="createCategoryInput" className="create-category-input-label">
                New Category Name:
              </label>
              <input name="createCategoryInput" type="text" 
              className="create-category-input" required 
              pattern="[A-Za-z\s]+"title="Only alpha letters" maxLength={20}/>
              <Button type='submit' variant="primary">CREATE</Button>
            </form>
          </div>


          <DataGrid className='category-data-grid' rows={data}
              columns={columns}
              checkboxSelection
              pageSize={8}
              disableSelectionOnClick
              // onCellEditCommit = 
              density='standard'
              isRowSelectable={false}
              isCellEditable={false}
          />
          <Snackbar
                open={snackbarState['state']}
                autoHideDuration={2000}
                onClose={handleSnackbarClose(setSnackbarState)}
                message={snackbarState['message']}
          />
        </div>
      </div>
    </div>


  )
}

export default AdminCategoryList