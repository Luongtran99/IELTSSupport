import React, {useState} from 'react'
import PropTypes from 'prop-types'
import { Height } from '@material-ui/icons';
import './SignIn.css'
import { Link, Redirect } from 'react-router-dom';

const url = "https://localhost:44391/api/account/login";

function SignIn(props) {

    // check username and password

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [cem , setCm] = useState('');
    const [csm, setCsm] = useState('');
    // validate username
    const validateUsername = (username) =>{
        var regex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/g
        if(regex.test(username)){
            return undefined;
        }
        else{
            setCm('Vui lòng nhập email');
            return 'Vui lòng nhập số điện thoại';
        }
    }

    const validatePassword = (password) =>{
        var regex = /[!-),@]/g;
        // check special character

        if(password.length > 6){
            setCsm('Mật khẩu phải dài hơn 6 ký tự ');
            return 'Mật khẩu phải dài hơn 6 ký tự ';
        }
        else{
            return undefined;
        }
    }
    // validate password
    const handleChangeUN=(e)=>{
        
        const k = e.target.value;
        setUsername(k);
    }

    const handleChangePS=(e)=>{
        
        const k = e.target.value;
        setPassword(k);
    }

    const submitForm = () =>{
        // url
        //console.log(username);
        //console.log()
        if(username == ''){
            document.getElementById("error-email").innerHTML = "Vui long nhap sdt";
            return;
        }
        var regex = /[!-),@]/g;
            // check special character

        if(password.length < 6 ){
            document.getElementById("error-password").innerHTML = 'Mật khẩu phải dài hơn 6 ký tự và không chứa các ký tự đặc biệt';
            document.getElementById("error-password").style.color = "red";
            return;
        }

        // fetch to login
        var myHeader = new Headers();
        myHeader.append("Content-Type", "application/json");


        var raw = JSON.stringify({
            email:document.getElementById("email").value,
            password:document.getElementById("password").value
        });

        var requestOptions = {
            method:"POST",
            headers:myHeader,
            body:raw,
            redirect:"follow"
        };

        fetch("https://localhost:44391/api/account/login", requestOptions)
        .then(response => response.json())
        .then(result => {
            if(result.isSuccess){
                sessionStorage.setItem("token", result.token);
                //sessionStorage.setItem("userId", result.Id);
                //sessionStorage.setItem("username", result.userName);
                window.location.replace("/profile");
                return;
            }
            else{
                document.getElementById("error_signin").innerHTML = result.message[0];
                return;
            }
        })
        .catch(error => console.log("error", error));

        // save all in localStorage
        //sessionStorage.setItem("token","2020202");
        
        // redirect to /profile
        //window.location.replace("/profile");
    }

    return (
        <>
            <div className={"center_page"}>
                <article style={{width:"400px",  minHeight:"500px",height:"auto", background:"#fff",borderStyle:"solid"}}>
                    <section style={{width:"100%", height:"20%"}}>
                        <div style={{width:"100%", bottom:"0px", marginTop:"30px", marginBottom:"-20px"}}>
                            <span style={{fontSize:"60px", color:"red", fontFamily:"Lobster", paddingLeft:"0px"}}>
                                SignIn
                            </span>
                        </div>
                    </section>
                    
                    <section style={{width:"100%", marginTop:"15px" }}>
                        <form style={{display:"flex", flexDirection:"column"}} id="login-form">
                            <div className="input_value">
                                <label></label>
                                <input type="text" placeholder="Your email" id="email" value={username} red="" onChange={handleChangeUN}></input>
                            </div>
                            <span className="error-message" id="error-email">{cem}</span>
                            <div className="input_value">
                                <label></label>
                                <input type="password" placeholder="Password" id="password" value={password} onChange={handleChangePS}></input>
                            </div>
                            <span className="error-message" id="error-password">{csm}</span>
                            <div style={{width:"100%"}}>
                                <button type="button" onClick={submitForm} style={{width:"70%"}} className="btn ">SIGN IN</button>
                            </div>
                        </form>
                        <div>
                            <span className="error-message" id="error_signin"></span>
                        </div>
                    </section>
                    <br></br>
                    <div style={{display:"flex", justifyContent:"center"}}>
                        <div style={{width:"30%", height:"2px", backgroundColor:"red",marginTop:"9px",marginRight:"20px"}}></div>
                        <div>OR</div>
                        <div style={{width:"30%", height:"2px", backgroundColor:"red",marginTop:"9px", marginLeft:"20px"}}></div>
                    </div>
                    <section style={{width:"100%",marginTop:"20px"}}>
                        <a href="#" style={{color:"#385185"}}><b>Login with Facebook</b></a>
                    </section>
                    <section style={{width:"100%",marginTop:"20px"}}>
                        If you don't have an account, <Link to="/signup" style={{color:"rgba(var(--d69, 0, 149, 246), 1)"}}><b>SignUp</b></Link>
                    </section>
                </article>
            </div>   
        </>
    )
}

SignIn.propTypes = {
    email: PropTypes.string.isRequired,
    password: PropTypes.string.isRequired
}

export default SignIn;

