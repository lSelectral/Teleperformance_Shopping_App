import { useState } from 'react';
import './Register.scss';
import {POST, userEndpoint} from '../../utility/apiCalls';
import { Link, useNavigate } from 'react-router-dom';

const Register = ({setUser, setAdmin}) => {
    const [validationText, setValidationText] = useState("");
    const [isValidInput, setIsValidInput] = useState(true);
    const navigate = useNavigate();

    const sleep = ms => new Promise(r => setTimeout(r, ms));

    const handleSubmit = (e) => {
        e.preventDefault();

        setIsValidInput(true);

        const firstName = e.target.firstname.value
        const lastName = e.target.lastname.value
        const email = e.target.email.value
        const emailconfirmation = e.target.emailconfirmation.value
        const password = e.target.password.value
        const passowrdConfirmation = e.target.passowrdconfirmation.value

        // Password should be at least 8, max 20 character and have one uppercase, lowercase and number
        // Max 20 char
        var passwordRegex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$/;
        if (email !== emailconfirmation){

            setValidationText("Emails don't match");
            setIsValidInput(false);
            return;
        } else if (password !== passowrdConfirmation){
            setValidationText("Passwords don't match");
            setIsValidInput(false);
            return;
        } else if (password.match(passwordRegex) ? false : true){
            setValidationText("Password should be at least 8, max 20 character and have one uppercase, lowercase and number");
            setIsValidInput(false);
            return;
        }
        else if (email.toLowerCase().includes("admin")){
            setValidationText("Admin word can't be used in mails");
            setIsValidInput(false);
            return;
        }

        if (!isValidInput){
            return;
        }

        const request = {
            firstName : firstName,
            lastName : lastName,
            email : email,
            password : password,
        };
        console.log(request);

        // Save user by request data
        // If successful, send user email and password to get JWT Token
        // Save user id and JWT Token to the local storage
        // Then navigate to the homepage
        POST(userEndpoint, (idData) => {
            localStorage.setItem("userId", idData.data);
            setUser(idData.data);
            POST(userEndpoint + "/auth",
                (token) => {
                localStorage.setItem("token", "Bearer " + token.data["token"]);
                if (email.toLowerCase().includes("admin")) {
                    localStorage.setItem("admin", "true");
                    setAdmin("true");
                }

                sleep(3000);
                navigate('/');
            }, {"email":email, "password":password});
        }, request);
    }

    return (
        <div className="container">
            <div className="header-background">
                <h1 className='header'>TELEPERFORMANCE</h1>
            </div>
            <div className="wrapper">
                <h1 className="title">REGISTER</h1>
                <form className='register-form' onSubmit={handleSubmit}>

                    <input name='firstname' placeholder="Name" type="text" 
                    className="input-class" required/>

                    <input name='lastname' placeholder="Last Name" 
                    type="text" className="input-class" required/>

                    <input name='email' placeholder="E-mail" type="email" 
                    className="input-class" required/>

                    <input name='emailconfirmation' placeholder="Confirm E-mail" type="email" 
                    className="input-class" required/>

                    <input name='password' placeholder="Password" type="text" 
                    className="input-class" required/>

                    <input name='passowrdconfirmation' placeholder="Confirm Password" 
                    type="text" className="input-class" required/>

                    <button type='submit' className="submit-button">REGISTER</button>
                    
                </form>
                {isValidInput ? <></> : <h5 className='error-text'>{validationText}</h5>}
                <br/>
                <Link to="/login">
                    Have an account already? Login!
                </Link>
            </div>
        </div>
    )
}

export default Register