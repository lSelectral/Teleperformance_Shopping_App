import './Sidebar.scss'
import {
  LineStyle,
  PermIdentity,
  CategoryOutlined,
  Storefront,
  AttachMoney,
  BarChart,
} from "@material-ui/icons";
import { Link } from "react-router-dom";
import { ShoppingCartOutlined } from '@mui/icons-material';

const Sidebar = () => {
  return (
      <div className='sidebar'>
          <div className="sidebarWrapper">


              <div className="sidebarMenu">
                  <h3 className="sidebarTitle">User</h3>
                  <ul className="sidebarList">
                      <Link to="/">
                        <li className="sidebarListItem">
                            <LineStyle/>
                            Home
                        </li>
                      </Link>
                  </ul>
              </div>

              
              <div className="sidebarMenu">
                  <h3 className="sidebarTitle">Admin</h3>
                  <ul className="sidebarList">
                      <Link to="/admin/users">
                        <li className="sidebarListItem">
                            <PermIdentity/>
                            Users
                        </li>
                      </Link>
                      <Link to="/admin/categories">
                        <li className="sidebarListItem">
                            <CategoryOutlined/>
                            Categories
                        </li>
                      </Link>
                      <Link to="/admin/products">
                        <li className="sidebarListItem">
                            <Storefront/>
                            Products
                        </li>
                      </Link>
                      <Link to="/admin/reports">
                        <li className="sidebarListItem">
                            <BarChart/>
                            Reports
                        </li>
                      </Link>
                  </ul>
              </div>
          </div>
      </div>
  )
};

export default Sidebar;
