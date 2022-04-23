import './Sidebar.scss'
import {
  LineStyle,
  Timeline,
  TrendingUp,
  PermIdentity,
  Storefront,
  AttachMoney,
  BarChart,
  MailOutline,
  DynamicFeed,
  ChatBubbleOutline,
  WorkOutline,
  Report,
} from "@material-ui/icons";
import { Link } from "react-router-dom";

const Sidebar = () => {
  return (
      <div className='sidebar'>
          <div className="sidebarWrapper">


              <div className="sidebarMenu">
                  <h3 className="sidebarTitle">Dashboard</h3>
                  <ul className="sidebarList">
                      <Link to="/">
                        <li className="sidebarListItem">
                            <LineStyle/>
                            Home
                        </li>
                      </Link>
                      <Link to="/analytics">
                        <li className="sidebarListItem">
                            <Timeline/>
                            Analytics
                        </li>
                      </Link>
                      <Link to="/sales">
                        <li className="sidebarListItem">
                            <TrendingUp/>
                            Sales
                        </li>
                      </Link>
                  </ul>
              </div>

              <div className="sidebarMenu">
                  <h3 className="sidebarTitle">Quick Menu</h3>
                  <ul className="sidebarList">
                      <Link to="/users">
                        <li className="sidebarListItem">
                            <PermIdentity/>
                            Users
                        </li>
                      </Link>
                      <Link to="/products">
                        <li className="sidebarListItem">
                            <Storefront/>
                            Products
                        </li>
                      </Link>
                      <Link to="/transactions">
                        <li className="sidebarListItem">
                            <AttachMoney/>
                            Transactions
                        </li>
                      </Link>
                      <Link to="/reports">
                        <li className="sidebarListItem">
                            <BarChart/>
                            Reports
                        </li>
                      </Link>
                  </ul>
              </div>

              <div className="sidebarMenu">
                  <h3 className="sidebarTitle">Notification</h3>
                  <ul className="sidebarList">
                      <Link to="/mail">
                          <li className="sidebarListItem">
                              <MailOutline/>
                              Mail
                          </li>
                      </Link>
                      <Link to="/feedback">
                        <li className="sidebarListItem">
                            <DynamicFeed/>
                            Feedback
                        </li>
                      </Link>
                      <Link to="/messages">
                        <li className="sidebarListItem">
                            <ChatBubbleOutline/>
                            Messages
                        </li>
                      </Link>
                  </ul>
              </div>
              <div className="sidebarMenu">
                  <h3 className="sidebarTitle">Staff</h3>
                  <ul className="sidebarList">
                      <Link to="/manage">
                        <li className="sidebarListItem">
                            <WorkOutline/>
                            Manage
                        </li>
                      </Link>
                      <Link to="/analytics">
                        <li className="sidebarListItem">
                            <Timeline/>
                            Analytics
                        </li>
                      </Link>
                      <Link to="/reports">
                        <li className="sidebarListItem">
                            <Report/>
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
