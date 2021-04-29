import React from 'react'
import { Link } from 'react-router-dom'
import './Menu.css'

const Menu = ({isVisible}) => {
    return (
        <div style={isVisible? {display:"block"}:{display:"none"}}>
            <ul className="nav_sub_menu">
                <li className="nav_sub_menu_item">
                    <Link to="/translate" className="nav-links">
                        Dictionary
                    </Link>
                </li>
                <li className="nav_sub_menu_item">
                    <Link to="/writing" className="nav-links">
                        Writing Task 2
                    </Link>
                </li>
                <li className="nav_sub_menu_item">
                    <Link to="/test" className="nav-links">
                        Test
                    </Link>
                </li>
                <li className="nav_sub_menu_item">
                    <Link to="/skills" className="nav-links">
                        Practice Skills
                    </Link>
                </li>
            </ul>
        </div>
    )
}

export default Menu
