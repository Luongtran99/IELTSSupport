import React from 'react'
import { Link } from 'react-router-dom'
import './Menu.css'

const Menu = ({isVisible}) => {
    
    
    return (
        <div style={isVisible? {display:"block",color:"black"}:{display:"none",color:"black"}}>
            <ul className="nav_sub_menu">
                <li className="nav_sub_menu_item">
                    <Link to="/dictionary" className="nav-links" style={{color:"black"}}>
                        Dictionary
                    </Link>
                </li> 
                <li className="nav_sub_menu_item">
                    <Link to="/writing" className="nav-links"style={{color:"black"}} >
                        Writing Task 2
                    </Link>
                </li>
                <li className="nav_sub_menu_item">
                    <Link to="/test" className="nav-links" style={{color:"black"}}>
                        Test
                    </Link>
                </li>
                <li className="nav_sub_menu_item">
                    <Link to="/skills" className="nav-links " style={{color:"black"}}>
                        Practice Skills
                    </Link>
                </li>
            </ul>
        </div>
    )
}

export default Menu
