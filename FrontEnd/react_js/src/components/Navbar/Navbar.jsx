import React from 'react'
import {useState, useEffect} from 'react'
import {Link} from 'react-router-dom'
import './Navbar.css'
import Menu from './Menu/Menu'
import Search from './Search/Search'
import { rgbToHex } from '@material-ui/core'
import logo from '../../assets/images/logo.png'
import Dictionary from '../../components/pages/Translate/Dictionary'

function Navbar() {
    
    const [click, setClick] = useState(false);
    const [button, setButton] = useState(true);
    const [clickAcc, setClickAcc] = useState(false);

    const [visible, setVisible] = useState(false);

    const displayMenu =()=>{
        setVisible(true);
    }

    const hideMenu = () =>{
        setVisible(false);
    }

    const handleClick = () => {
        setClick(!click);
        if(clickAcc){
            setClickAcc(!clickAcc);
        }
    }
    const handleClickAcc = () => {
        setClickAcc(!clickAcc);
        if(click){
            setClick(!click)
        }
    }
    const closeMobileMenu = () => setClick(false);

    const ShowButton = () =>{
        if(window.innerWidth <= 960){
            setButton(false);
        }
        else{
            setButton(true);
        }
    }

    useEffect(() => {
        ShowButton();
    }, [])

    return (
        <>
            <nav className="navbar">
                <div className="navbar-container">
                    <Link to='/' className="navbar-logo" >
                        <h3>
                            <p className="prefix"></p>
                            <div className="suffix">
                                <p style={{color:"red"},{marginTop:"-7px"}} >IELTS</p>
                                <p style={{color:"white",marginTop:"-5px",marginLeft:"20px"}}>Support</p>
                            </div>
                            
                        </h3>    
                        {/* <ruby style={{marginTop:"-4px"}}>
                            Support <rp>(</rp><rt style={{fontSize:"2rem"}}>IELTS</rt><rp>)</rp>
                        </ruby>    */}
                        {/* <img src={logo} className="image"></img>
                        <span style={{display:"none"}}>IELTS Support</span> */}
                    </Link>
                    <ul className="menu-icon">
                        <li className="menu-icon-item">
                            <div onClick={handleClick}>
                                <i className={click ? "fas fa-times" : "fas fa-bars"}></i>
                            </div>
                        </li>
                        <li className="menu-icon-item">
                            <div style={{ marginRight: "50px" }, { color: "red" }} onClick={handleClickAcc}>
                                <i className={clickAcc ? "fas fa-times" : "fa fa-lock"} aria-hidden="true"></i>
                            </div>
                        </li>
                    </ul>
                    
                    
                    <ul className={click ? "nav-menu active":"nav-menu"}>
                        <li className="nav-item">
                            <Link to="/" className="nav-links">
                                Home
                            </Link>
                        </li>
                        <li className="nav-item" onMouseLeave={hideMenu} onMouseOver={displayMenu}>
                            <Link to="/dictionary"  className="nav-links" onClick={closeMobileMenu} >
                                Features
                            </Link>
                            <Menu isVisible={visible}/>
                        </li>
                        <li className="nav-item">
                            <Link to="/forum" className="nav-links" onClick={closeMobileMenu}>
                                Forum   
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/examples" className="nav-links" onClick={closeMobileMenu}>
                                Examples   
                            </Link>
                        </li>
                        
                    </ul>
                    <div className={clickAcc ? "nav-menu active":"nav-menu"}>
                        <div className="Sign">
                            <Link to="/signup" className="contact signup" onClick={closeMobileMenu}>SignUp</Link>
                            /
                            <Link to="/signin" className="contact signin" onClick={closeMobileMenu}>SignIn</Link>
                        </div>
                    </div>
                    
                </div>
            </nav>
        </>
    )
}

export default Navbar
