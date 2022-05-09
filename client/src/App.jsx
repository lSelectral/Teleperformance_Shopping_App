import './App.scss';
import Home from './pages/Home/Home';
import Register from './pages/Register/Register';
import Login from './pages/Login/Login';
import AdminProductList from './pages/AdminProductList/AdminProductList'
import AdminCategoryList from './pages/AdminCategoryList/AdminCategoryList'
import {
  BrowserRouter as Router,
  Routes,
  Route,
} from "react-router-dom";
import { useState } from 'react';

function App() {
  const [user, setUser] = useState(localStorage.getItem("userId"))
  const [admin, setAdmin] = useState(localStorage.getItem("admin"))
  
  return (
    <Router>
        <Routes>
          <Route path="/" element={user ? <Home/> : <Login setAdmin={setAdmin} setUser={setUser}/> }/>
          <Route path="register" element={user ? <Home/> : <Register setAdmin={setAdmin} setUser={setUser}/>}/>
          <Route path="login" element={user ? <Home/> : <Login setAdmin={setAdmin} setUser={setUser}/>}/>

          {admin ? <Route path="admin/products" element={admin ?  <AdminProductList/> : <Home/>}/> : null}
          {admin ? <Route path="admin/categories" element={admin ?  <AdminCategoryList/> : <Home/>}/> : null}

          <Route path="*" element={user ? <Home/> : <Login setAdmin={setAdmin} setUser={setUser}/>} />
        </Routes>
    </Router>
  );
}

export default App;
