import { useEffect, useState } from "react";
import { Api, ValidateUserRequest } from "../../services/main.service";
import React from "react";
import { useNavigate } from "react-router";



const Login = () => {
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');

    const api = new Api();
    let navigate = useNavigate();
    const user =  localStorage.getItem('user-data');

    useEffect(() => {
        if(user){
            navigate('/Grades');
        }
    },[]);

    const submitForm = async (e:any) => {
        e.preventDefault();

        const request: ValidateUserRequest = {
            password: password,
            userName: login
        }
        
        var res = await api.api.userValidateUserCreate(request);

        if(res.data){
            localStorage.setItem('user-data', JSON.stringify(res.data));
            navigate('/grades');
        }

    };

    return (
        <div className={'login-container align-middle'}>
            <div className={'align-middle m-4'}>
                <h3 className="text-diary text-center">SIGN IN</h3>
                <form onSubmit={(e) => submitForm(e)}>
                    <div className="form-group m-1">
                        <label className="text-diary text-center">Login</label>
                        <input onChange={(e) => setLogin(e.target.value)} required type="login" className="form-control" id="inputLogin" aria-describedby="" placeholder="Enter login"/>
                    </div>
                    <div className="form-group m-1">
                        <label className="text-diary text-center">Password</label>
                        <input onChange={(e) => setPassword(e.target.value)}required type="password" className="form-control" id="inputPassword" placeholder="Password"/>
                    </div>
                    <div className="mt-3 text-center">
                        <button type="submit" className="btn diary-button btn-primary">Sign in</button>
                    </div>
                </form>
            </div>
        </div>
    );
}
export default Login;
