import { Language, NotificationsNone, Settings } from '@material-ui/icons';
import React from 'react';
import './Navbar.scss';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import { useNavigate } from 'react-router-dom';
import LOGO from '../../resource/logo.svg';
import AVATAR from '../../resource/t_avatar.png';

const Navbar = () => {
    const navigate = useNavigate();
    const [anchorEl, setAnchorEl] = React.useState(null);
    const open = Boolean(anchorEl);
    const handleClick = (event) => {
      setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
      setAnchorEl(null);
    };
    const sleep = ms => new Promise(r => setTimeout(r, ms));

    const logoutHandler = () => {
        handleClose();
        localStorage.removeItem("token");
        localStorage.removeItem("userId");
        localStorage.removeItem("admin");
        sleep(2000);        
        navigate("/login");
    }


    return (
        <div className='custom-navbar'>
            <div className="navbarWrapper">
                <div className="nav-left">
                    <img className="logo" src={LOGO}/>
                    {/* <span className="logo">SELECTRA</span> */}
                </div>
                <div className="nav-right">
                    <div className="icons">
                        <NotificationsNone/>
                        <span className="topIconBadge">2</span>
                    </div>
                    <div className="icons">
                        <Language/>
                        {/* <span className="topIconBadge">3</span> */}
                    </div>
                    <div className="icons">
                        <Settings/>
                        {/* <span className="topIconBadge">4</span> */}
                    </div>

                    <img 
                    src={AVATAR} 
                    alt="Avatar" 
                    className="avatar" id="profile-avatar" onClick={handleClick}/>
                </div>
            </div>
            <Menu
                id="profile-avatar"
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                MenuListProps={{
                'aria-labelledby': 'profile-avatar',
                }}
            >
                <MenuItem onClick={handleClose}>Profile</MenuItem>
                <MenuItem onClick={handleClose}>My account</MenuItem>
                <MenuItem onClick={logoutHandler}>Logout</MenuItem>
            </Menu>
        </div>
    )
};

export default Navbar;
