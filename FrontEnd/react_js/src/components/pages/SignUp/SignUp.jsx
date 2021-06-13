import React, {useState} from 'react'
import PropTypes from 'prop-types'
import './SignUp.css'
import { Link } from 'react-router-dom'

function SignUp() {


    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const signup = (e) =>{
        e.preventDefault();
        if(username == ''){
            document.getElementById("error-email").innerHTML = "email can not be null";
            return;
        }
        if(password !== document.getElementById("secured_password").value){
            //alert("rewrite your password");            
            document.getElementById("error_duplicated-password").innerHTML = "they are not the same";
            return;
        }

        var myHeader = new Headers();
        myHeader.append("Content-Type", "application/json")

        var raw = JSON.stringify({
            Email:username,
            Password:password,
        })

        var requestOptions = {
            method:"POST",
            body:raw,
            headers:myHeader,
            redirect:"follow"
        };


        fetch("https://localhost:44391/api/account/register", requestOptions)
        .then(response => response.json())
        .then(result => {
            if(result.isSuccess){
                sessionStorage.setItem("token", result.token);
                sessionStorage.setItem("isNewAccount", true);
                window.location.replace("/editprofile");
                return;
            }
            else{
                alert(result.message[0]);
                return;
            }
        })
        .catch(error => console.log(error));
    }

    return (
        <>
            <div className={"center_page"}>
                <article style={{width:"400px", minHeight:"600px",marginBottom:"20px",marginTop:"15px", background:"#fff",borderStyle:"solid"}}>
                    <section style={{width:"100%", height:"20%"}}>
                        <div style={{width:"100%", bottom:"0px", marginTop:"20px", marginBottom:"-20px"}}>
                            <span style={{fontSize:"60px", color:"red", fontFamily:"Lobster", paddingLeft:"0px"}}>
                                SignUp
                            </span>
                        </div>
                    </section>
                    
                    <section style={{width:"100%", marginTop:"5px" }}>
                        <form style={{display:"flex", flexDirection:"column"}}>
                            <div className="input_value">
                                <label></label>
                                <input type="text" placeholder="Your email" onChange={(e) => {
                                    const k = e.target.value;
                                    setUsername(k);
                                }} ></input>
                            </div>
                            <span className="error-message" style={{color:"red"}} id="error-email"></span>
                            <div className="input_value">
                                <label></label>
                                <input type="password" placeholder="Password" onChange={(e) =>{
                                    const k = e.target.value;
                                    setPassword(k);
                                }}></input>
                            </div>
                            <span className="error-message" id="error-password"></span>
                            <div className="input_value">
                                <label></label>
                                <input type="password" placeholder="Secured Password" id="secured_password"></input>
                            </div>
                            <span className="error-message" id="error_duplicated-password"></span>
                            <div style={{width:"100%"}}>
                                <button type="submit" style={{width:"70%"}} className="btn " onClick={(e)=>signup(e)}>SIGN UP</button>
                            </div>
                        </form>
                    </section>
                    <br></br>
                    <div style={{display:"flex", justifyContent:"center"}}>
                        <div style={{width:"30%", height:"2px", backgroundColor:"red",marginTop:"9px",marginRight:"20px"}}></div>
                        <div>OR</div>
                        <div style={{width:"30%", height:"2px", backgroundColor:"red",marginTop:"9px", marginLeft:"20px"}}></div>
                    </div>
                    <div style={{lineHeight: "25px", marginTop: "20px", fontSize:"15px"}}>
                        <p>By signing up, you agree to our <a href="#">Terms</a> , <a href="#">Data Policy</a> and  <a href="#">Cookies Policy</a> .</p>
                    </div>
                    <section style={{width:"100%",marginTop:"20px"}}>
                        <a href="#" style={{color:"#385185"}}><b>SignUp with Facebook</b></a>
                    </section>
                    <section style={{width:"100%",marginTop:"20px"}}>
                        If you have an account, <Link to='/signin' style={{color:"rgba(var(--d69, 0, 149, 246), 1)"}}><b>SignIn</b></Link>
                    </section>
                </article>
            </div>   
        </> 
    )
}

SignUp.propTypes = {
}

export default SignUp
