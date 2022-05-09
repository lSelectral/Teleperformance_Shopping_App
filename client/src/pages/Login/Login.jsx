import { useState } from 'react';
import './Login.scss';
import {POST, userEndpoint} from '../../utility/apiCalls';
import { Link, useNavigate } from 'react-router-dom';

const Login = ({setUser, setAdmin}) => {
    const [validationData, setValidationData] = useState({text: "", isValid: true})
    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();

        const email = e.target.email.value
        const password = e.target.password.value

        // Password should be at least 8, max 20 character and have one uppercase, lowercase and number
        // Max 20 char
        var passwordRegex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$/;
        if (password.match(passwordRegex) ? false : true){
            setValidationData({
                text: "Password should be at least 8, max 20 character and have one uppercase, lowercase and number",
                isValid: false
            })
            return;
        }

        const data = {
            email : email,
            password : password,
        };
        console.log(data);
        const sleep = ms => new Promise(r => setTimeout(r, ms));
        POST(userEndpoint + '/auth', (data) => {
            console.log(data);
            localStorage.setItem('token',"Bearer " + data.data["token"]);
            localStorage.setItem("userId", data.data["userId"]);
            setUser(data.data["userId"]);
            if (email.toLowerCase().includes("admin")) {
                localStorage.setItem("admin", "true");
                setAdmin("true");
            }
            
            sleep(500);
            navigate("/");
        }, data,
        (err) => {
            setValidationData({
                text: "Wrong user info. Please check again",
                isValid: false
            })
        }
        );
    }

    return (
        <div className="container">
            <div className="header-background">
                <h1 className='header'>TELEPERFORMANCE</h1>
            </div>
            <div className="wrapper">
                <h1 className="title">LOGIN</h1>
                <form className='register-form' onSubmit={handleSubmit}>

                    <input name='email' placeholder="E-mail" type="email" 
                    className="input-class" required/>

                    <input name='password' placeholder="Password" type="text" 
                    className="input-class" required/>

                    <button type='submit' className="submit-button">LOGIN</button>
                    
                </form>
                {validationData["isValid"] ? <></> : <h5 className='error-text'>{validationData["text"]}</h5>}

                <br/>
                <Link to="/register">
                    Don't have an account yet? Register!
                </Link>
            </div>
        </div>
    )
}

export default Login