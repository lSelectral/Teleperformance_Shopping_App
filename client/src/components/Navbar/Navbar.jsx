import { Language, NotificationsNone, Settings } from '@material-ui/icons';
import React from 'react';
import './Navbar.scss'

const Navbar = () => {
  return (
      <div className='navbar'>
          <div className="navbarWrapper">
              <div className="left">
                  <span className="logo">SELECTRA</span>
              </div>
              <div className="right">
                  <div className="icons">
                      <NotificationsNone/>
                      <span className="topIconBadge">2</span>
                  </div>
                  <div className="icons">
                      <Language/>
                      <span className="topIconBadge">3</span>
                  </div>
                  <div className="icons">
                      <Settings/>
                      <span className="topIconBadge">4</span>
                  </div>

                  <img 
                  src="https://pfpmaker.com/_nuxt/img/profile-3-1.3e702c5.png" 
                  alt="Avatar" 
                  className="avatar" />
              </div>
          </div>
      </div>
  )
};

export default Navbar;
