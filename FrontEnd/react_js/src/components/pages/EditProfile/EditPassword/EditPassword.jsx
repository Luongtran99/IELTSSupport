import React, {useState} from 'react'
import { Link, Route,Switch } from 'react-router-dom'
import '../EditProfile.css'
function EditPassword() {
    return (
        <main style={{width:"100%",minHeight:"650px", height:"auto", backgroundColor:"#fff",color:"#383838",marginTop:"-45px", display:"flex",justifyContent:"center",alignItems:"center"}} role="main">
            <div className="BvMHM" >
                <ul className="wW1cu">
                    <li>
                        <Link to='/editprofile' className="h-aRd">Edit Profile</Link>
                    </li>
                    <li>
                        <Link to='/account/editpassword' className="h-aRd">Change Password</Link>
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
                <article  className="PVkFi">
                    <div className="C_9MP">
                        <div className="LqNQc">
                            <div className="M-jxE">
                                <button class="Ia1UJ" title="Change your phoe">
                                        <img alt="Change your profile image" class="be6sR" src={"https://www.oxfordlearnersdictionaries.com/external/images/product/OALD_producthometop.png?version=2.1.29"}></img>
                                </button>
                                <div >
                                    <form enctype="multipart/form-data" method="POST" role="presentation">
                                        <input accept="image/jpeg,image/png" class="tb_sK" type="file"/>
                                    </form>
                                </div>
                            </div>
                        </div>
                        <div className="XX1Wc" style={{display:"block"}}>
                            <h1 className="kHYQv" title="locery">Locery</h1>
                            <button className="sqdOP" type="button">Change Profile Photo</button>
                        </div>

                    </div>
                    <hr style={{margin:"20px 0px"}}></hr>
                    <form className="kWXsT" style={{marginTop:"20px",marginBottom:"20px"}} id="form-change-password">
                        <div className="eE-OA">
                            <aside className="sxIVS">
                                <label className="pepName">Old Password</label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <input aria-required="false" id="cppOldPassword" placeholder="" type="text" style={{height:"40px"}} class="JLJ-B"></input>
                                    {/* <div style={{fontSize:"12px",paddingLeft:"5px"}}><p>Help people discover your account by using the name you're known by: either your full name, nickname, or business name.</p><p>You can only change your name twice within 14 days.</p></div> */}
                                </div>
                            </div>
                        </div>
                        <div className="eE-OA" style={{margin:"10px 0px"}}>
                            <aside className="sxIVS">
                                <label className="pepName">New Password</label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <input aria-required="false" id="cppNewPassword" placeholder="" type="text" style={{height:"40px"}} class="JLJ-B"></input>
                                    {/* <div style={{fontSize:"12px",paddingLeft:"5px"}}><p>Help people discover your account by using the name you're known by: either your full name, nickname, or business name.</p><p>You can only change your name twice within 14 days.</p></div> */}
                                </div>
                            </div>
                        </div>
                        <div className="eE-OA" style={{margin:"10px 0px"}}>
                            <aside className="sxIVS">
                                <label className="pepName">Confirm</label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <input aria-required="false" id="cppConfirmNP" placeholder="" type="text" style={{height:"40px"}} class="JLJ-B"></input>
                                    {/* <div style={{fontSize:"12px",paddingLeft:"5px"}}><p>Help people discover your account by using the name you're known by: either your full name, nickname, or business name.</p><p>You can only change your name twice within 14 days.</p></div> */}
                                </div>
                            </div>
                        </div>
                        <div className="eE-OA" >
                            <aside className="sxIVS">
                                <label className="pepName"></label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <input aria-required="false" id="cppConfirmNP" placeholder="" type="button" class="btn" value="Change Password"></input>
                                    {/* <div style={{fontSize:"12px",paddingLeft:"5px"}}><p>Help people discover your account by using the name you're known by: either your full name, nickname, or business name.</p><p>You can only change your name twice within 14 days.</p></div> */}
                                </div>
                            </div>
                        </div>
                    </form>
                </article>
            </div>
        </main>
    )
}

export default EditPassword
