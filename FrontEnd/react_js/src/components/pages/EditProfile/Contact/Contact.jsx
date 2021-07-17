import { Link, useHistory, useParams } from 'react-router-dom'
import React from 'react'
import SwaggerUI from 'swagger-ui-react'
import "swagger-ui-react/swagger-ui"
function Contact() {
    return (
        <main style={{width:"100%",minHeight:"650px", height:"auto", backgroundColor:"#fff",color:"#383838",marginTop:"-30px", display:"flex",justifyContent:"center",alignItems:"center"}} role="main">
            <div className="BvMHM" >
                <ul className="wW1cu">
                    <li>
                        <Link to='./mainEditProfile' className="h-aRd">Edit Profile</Link>
                    </li>
                    <li>
                        <Link to='./EditPassword' className="h-aRd">Change Password</Link>
                    </li>
                    <li>
                        <Link to='./appAndWebs' className="h-aRd">Apps and Websites</Link>
                    </li>
                    <li>
                        <Link to='./Contact' className="h-aRd">Email and SMS</Link>
                    </li>
                    <li>
                        <Link to='./Notifications' className="h-aRd">Push Notifications</Link>
                    </li>
                    <li>
                        <Link to='./manageContacts' className="h-aRd">Manage Contacts</Link>
                    </li>
                    <li>
                        <Link to='./loginAct' className="h-aRd">login Activity</Link>
                    </li>
                    <li>
                        <Link to='./emailFromSupport' className="h-aRd">Emails from SupportWriting</Link>
                    </li>
                    <li>
                        <Link to='/signin' className="btn">Switch Accounts</Link>
                    </li>
                </ul>
                <article>
                    <SwaggerUI url="https://localhost:44391/swagger/index.html"></SwaggerUI>
                </article>
            </div>
        </main>
    )
}

export default Contact
