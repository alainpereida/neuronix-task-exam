import React, { useState } from "react";
import { CONFIG } from "../../constants/app-config";
import { saveToken } from "../../api/jwt.service";

const Login = () => {
    const [password, setPassword] = useState("");
    const [email, setEmail] = useState("");
    const [passwordError, setpasswordError] = useState("");
    const [emailError, setemailError] = useState("");

    const handleValidation = (event) => {
        let formIsValid = true;

        if (!email.match(/^[^\s@]+@[^\s@]+\.[^\s@]+$/)) {
            formIsValid = false;
            setemailError("Email Not Valid");
            return false;
        } else {
            setemailError("");
            formIsValid = true;
        }

        /*if (!password.match(/^[a-zA-Z]{8,22}$/)) {
            formIsValid = false;
            setpasswordError(
                "Only Letters and length must best min 8 Chracters and Max 22 Chracters"
            );
            return false;
        } else {
            setpasswordError("");
            formIsValid = true;
        }*/

        return formIsValid;
    };

    const loginSubmit = async (e) => {
        e.preventDefault();
        const isValid = handleValidation();
        
        if (!isValid)
            return
        
        const response = await fetch(CONFIG.API_HOST + '/api/auth/login', {
            method: 'POST',
            headers: {
                'Access-Control-Allow-Origin':'*',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                userName: email,
                password: password
            })
        });
        const accessToken = await response.json();
        saveToken(accessToken.dataResponse.token);
    };

    return (
        <div id="login-root">
            <div className="row d-flex justify-content-center">
                <div className="col-md-4">
                    <h1>Login</h1>
                    <form id="loginform" onSubmit={loginSubmit}>
                        <div className="form-group">
                            <label>Email address</label>
                            <input
                                type="email"
                                className="form-control"
                                id="EmailInput"
                                name="EmailInput"
                                aria-describedby="emailHelp"
                                placeholder="Enter email"
                                onChange={(event) => setEmail(event.target.value)}
                            />
                            <small id="emailHelp" className="text-danger form-text">
                                {emailError}
                            </small>
                        </div>
                        <div className="form-group">
                            <label>Password</label>
                            <input
                                type="password"
                                className="form-control"
                                id="exampleInputPassword1"
                                placeholder="Password"
                                onChange={(event) => setPassword(event.target.value)}
                            />
                            <small id="passworderror" className="text-danger form-text">
                                {passwordError}
                            </small>
                        </div>
                        <button type="submit" className="btn btn-primary">
                            Submit
                        </button>
                    </form>
                </div>
            </div>
        </div>
    )
}

export default Login;
