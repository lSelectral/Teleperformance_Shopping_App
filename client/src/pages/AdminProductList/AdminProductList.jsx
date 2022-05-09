import './AdminProductList.scss';
import {DeleteOutline} from '@material-ui/icons'
import { DataGrid } from "@material-ui/data-grid";
import { useEffect, useState } from 'react';
import { categoryEndpoint, DELETE, GETALL, POST, productEndpoint, UPDATE } from '../../utility/apiCalls';
import InsertProductModal from '../../components/ModalForm/InsertProductModal';
import EditProductModal from '../../components/ModalForm/EditProductModal';
import Navbar from '../../components/Navbar/Navbar';
import Sidebar from '../../components/Sidebar/Sidebar';
import Snackbar from '@mui/material/Snackbar';
import {
  handleSnackbarOpen,
  handleSnackbarClose
} from '../../utility/snackbarUtility';
import { useDispatch } from 'react-redux';
import { updateCategories } from '../../redux/shopSlice';

const UserList = () => {
    const [data, setData] = useState([]);
    const [snackbarState, setSnackbarState] = useState({"state": false, "message": "default"});

    const [searchKeyWord, setSearchKeyWord] = useState("");
    const [categoryToFilter, setCategoryToFilter] = useState("ALL");

    const dispatch = useDispatch();
    const handleDelete = (id) => {
        DELETE(productEndpoint, () => {handleSnackbarOpen(`Product with ${id} ID deleted`, setSnackbarState);}, id, null);
    }

    const addProduct = (inputData) => {
        POST(productEndpoint, () => {handleSnackbarOpen(`New product added`, setSnackbarState);},inputData, null);
    }

    const updateProduct = (inputData) => {
        UPDATE(productEndpoint, () => {handleSnackbarOpen(`Product updated`, setSnackbarState);}, inputData, null)
    }

    useEffect(() => {
        GETALL(productEndpoint, (d) => {setData(d.data);});
        GETALL(categoryEndpoint, (d) => {dispatch(updateCategories(d.data));});
      }, [])
    

    const columns = [
        { field: 'id', headerName: 'ID', width: 90 },
        { field: 'name', headerName: 'Name', minWidth: 220, renderCell: (params) => {
            return (
                <div className="userListUser">
                    <img className='userListImage' src={params.row.imageUrl}/>
                    {params.row.name}
                </div>
            )
        }},
        { field: 'description', headerName: 'Description', minWidth: 250},
        { field: 'color', headerName: 'Color', minWidth: 120},
        { field: 'price', headerName: 'Price', minWidth: 120},
        { field: 'category', headerName: 'Category', minWidth: 150 },
        { field: 'action', flex: 1, headerName: 'Actions', renderCell: (params) => {
            var i = data.indexOf(params.row)
            return(
                <>
                    <EditProductModal rowData={data[i]} editFunction={updateProduct}/>
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
                <div className= 'userList'>
                    <InsertProductModal createFunction={addProduct} 
                    setCategoryToFilter={setCategoryToFilter} setSearchKeyWord={setSearchKeyWord}/>
                    <DataGrid className='admin-product-grid' 
                    rows={data.filter(x => x.name.toLowerCase().includes(searchKeyWord.toLowerCase()) && 
                        (x.category === categoryToFilter || categoryToFilter === "ALL"))}

                    columns={columns}
                    // checkboxSelection
                    pageSize={8}
                    disableSelectionOnClick
                    // onCellEditCommit = 
                    density='comfortable'
                    isRowSelectable={false}
                    isCellEditable={false}/>
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
};

export default UserList;