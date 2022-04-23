import './App.scss';
import Navbar from './components/Navbar/Navbar';
import Sidebar from './components/Sidebar/Sidebar';
import Home from './pages/Home/Home';
import Register from './pages/Register/Register';
import Login from './pages/Login/Login';
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";

function App() {
  // const user = useSelector(state => state.user.currentUser);
  const user = null;

  return (
    <Router>
      <Navbar/>
      <div className='app-container'>
        <Sidebar/>
        <Routes>
          <Route path="/" element={<Home/>}/>
          <Route path="register" element={user ? <Navigate to="/"/> : <Register/>}/>
          <Route path="login" element={user ? <Navigate to="/"/> : <Login/>}/>
        </Routes>
      </div>

    </Router>
  );
}

export default App;
