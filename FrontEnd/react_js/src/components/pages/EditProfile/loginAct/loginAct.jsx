import React from 'react'

function loginAct() {
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
                    
                </article>
            </div>
        </main>
    )
}

export default loginAct
