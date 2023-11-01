import React, { useState } from "react";
import { CONFIG } from "../../constants/app-config";
import { saveToken } from "../../api/jwt.service";
import { useNavigate  } from 'react-router-dom'

const Login = () => {
    const navigate = useNavigate();
    const [email, setEmail] = useState("");
    const [emailError, setemailError] = useState("");

    const handleValidation = (event) => {
        let formIsValid = true;

        if (!email.match(/^[^\s@]+@[^\s@]+\.[^\s@]+$/)) {
            setemailError("Email Not Valid");
            return false;
        } else {
            setemailError("");
            formIsValid = true;
        }
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
                password: ''
            })
        });
        const accessToken = await response.json();
        saveToken(accessToken.dataResponse.token);
        navigate('/assignments');
        window.location.reload();
    };

    return (
        <div id="login-root">
            <div className="row d-flex justify-content-center">
                <div className="col-md-4">
                    <h1>Inicio de sesión</h1>
                    <form id="loginform" onSubmit={loginSubmit}>
                        <div className="form-group">
                            <label>Correo electrónico</label>
                            <input
                                type="email"
                                className="form-control"
                                id="EmailInput"
                                name="EmailInput"
                                aria-describedby="emailHelp"
                                placeholder="Correo electrónico"
                                onChange={(event) => setEmail(event.target.value)}
                            />
                            <small id="emailHelp" className="text-danger form-text">
                                {emailError}
                            </small>
                        </div>
                        <div className="m-4 d-flex justify-content-center">
                            <button type="submit" className="btn btn-primary">
                                Iniciar Sesión
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    )
}

export default Login;
