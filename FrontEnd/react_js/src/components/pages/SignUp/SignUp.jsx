import React from 'react'
import PropTypes from 'prop-types'
import './SignUp.css'
import { Link } from 'react-router-dom'

function SignUp(props) {
    return (
        <>
            <div className={"center_page"}>
                <article style={{width:"400px", height:"600px",marginTop:"15px", background:"#fff",borderStyle:"solid"}}>
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
                                <input type="text" placeholder="Your email" ></input>
                            </div>
                            <span className="error-message" id="error-email"></span>
                            <div className="input_value">
                                <label></label>
                                <input type="password" placeholder="Password"></input>
                            </div>
                            <span className="error-message" id="error-password"></span>
                            <div className="input_value">
                                <label></label>
                                <input type="password" placeholder="Secured Password"></input>
                            </div>
                            <span className="error-message" id="error_duplicated-password"></span>
                            <div style={{width:"100%"}}>
                                <button type="submit" style={{width:"70%"}} className="btn ">SIGN UP</button>
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
