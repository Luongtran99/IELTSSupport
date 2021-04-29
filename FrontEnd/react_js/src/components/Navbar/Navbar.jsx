import React from 'react'
import {useState, useEffect} from 'react'
import {Link} from 'react-router-dom'
import './Navbar.css'
import Menu from './Menu/Menu'
import Search from './Search/Search'
import { rgbToHex } from '@material-ui/core'


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
                        <span>IELTS</span>Support
                        <i class="fab fa-github" aria-hidden="true"></i>
                    </Link>
                    <ul className="menu-icon">
                        <li className="menu-icon-item">
                            <div onClick={handleClick}>
                                <i className={click ? "fas fa-times" : "fas fa-bars"}></i>
                            </div>
                        </li>
                        <li className="menu-icon-item">
                            <div style={{ marginRight: "50px" }, { color: "red" }} onClick={handleClickAcc}>
                                <i class={clickAcc ? "fas fa-times" : "fa fa-lock"} aria-hidden="true"></i>
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
                            <Link to="/features" className="nav-links" onclick={closeMobileMenu} >
                                Features
                            </Link>
                            <Menu isVisible={visible}/>
                        </li>
                        <li className="nav-item">
                            <Link to="/forum" className="nav-links" onclick={closeMobileMenu}>
                                Forum   
                            </Link>
                        </li>
                        <li className="nav-item">
                            <Link to="/examples" className="nav-links" onclick={closeMobileMenu}>
                                Examples   
                            </Link>
                        </li>
                        
                    </ul>
                    <div className={clickAcc ? "nav-menu active":"nav-menu"}>
                        <div className="Sign">
                            <Link to="/signup" className="contact signup" onclick={closeMobileMenu}>SignUp</Link>
                            /
                            <Link to="/signin" className="contact signin" onclick={closeMobileMenu}>SignIn</Link>
                        </div>
                    </div>
                    
                </div>
            </nav>
        </>
    )
}

export default Navbar
