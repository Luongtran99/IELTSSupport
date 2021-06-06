import React, {useState} from 'react'
import { Link, Route,Switch } from 'react-router-dom'
import './EditProfile.css'
// import mainEditProfile from './mainEditProfile/mainEditProfile'
// import notification from './Notifications/notification'
// import emailSupport from './emailFromSupport/emailSupport'
// import EditPassword from './EditPassword/EditPassword'
// import Contact from './Contact/Contact'
// import appAndWebs from './appAndWebs/appAndWebs'
// import loginAct from './loginAct/loginAct'
// import manageContacts from './manageContacts/manageContact'

function EditProfile() {
    return (
        <main style={{width:"100%",minHeight:"650px", height:"auto", backgroundColor:"#fff",color:"#383838",marginTop:"-30px", display:"flex",justifyContent:"center",alignItems:"center"}} role="main">
            <div className="BvMHM" style={{height:"auto",marginTop:"4rem", marginBottom:"2rem"}} >
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
                <hr></hr>
                <article className="PVkFi">
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
                    <form className="kWXsT" style={{marginTop:"20px"}}>
                        <div className="eE-OA">
                            <aside className="sxIVS">
                                <label className="pepName">Name</label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <input aria-required="false" id="pepName" placeholder="Name" type="text" class="JLJ-B"></input>
                                    <div style={{fontSize:"12px",paddingLeft:"5px"}}><p>Help people discover your account by using the name you're known by: either your full name, nickname, or business name.</p><p>You can only change your name twice within 14 days.</p></div>
                                </div>
                            </div>
                        </div>
                        <div className="eE-OA">
                            <aside className="sxIVS">
                                <label className="pepName">Username</label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <input aria-required="false" id="pepUsername" placeholder="Name" type="text" class="JLJ-B" value="luong.td"></input>
                                    <div style={{fontSize:"12px",paddingLeft:"5px"}}><p>In most cases, you'll be able to change your username back to luong.dt for another 14 days. Learn More</p></div>
                                </div>
                            </div>
                        </div>
                        <div className="eE-OA">
                            <aside className="sxIVS">
                                <label className="pepName">Website</label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <input aria-required="false" id="pepWebsite" placeholder="Website" type="text" class="JLJ-B" value=""></input>
                                    {/* <div style={{fontSize:"12px",paddingLeft:"5px"}}><p>In most cases, you'll be able to change your username back to luong.dt for another 14 days. Learn More</p></div> */}
                                </div>
                            </div>
                        </div>
                        <div className="eE-OA" style={{marginTop:"10px"}}>
                            <aside className="sxIVS">
                                <label className="pepName">Bio</label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <textarea aria-required="false" id="pepBio" placeholder="" type="text" class="JLJ-B" style={{minHeight:"70px"}} value=""></textarea>
                                    <div style={{fontSize:"12px",paddingLeft:"5px"}}>
                                        <h4 style={{}}>Personal Information</h4>
                                        <p>Provide your personal information, even if the account is used for a business, a pet or something else. This won't be a part of your public profile</p>
                                    </div> 
                                </div>
                            </div>
                        </div>
                        <div className="eE-OA" style={{marginTop:"10px"}}>
                            <aside className="sxIVS">
                                <label className="pepName">Email</label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <input aria-required="false" id="pepEmail" placeholder="@gmail.com" type="text" class="JLJ-B" value=""></input>
                                    {/* <div style={{fontSize:"12px",paddingLeft:"5px"}}><p>In most cases, you'll be able to change your username back to luong.dt for another 14 days. Learn More</p></div> */}
                                </div>
                            </div>
                        </div>
                        <div className="eE-OA" style={{marginTop:"10px"}}>
                            <aside className="sxIVS">
                                <label className="pepName">PhoneNumber</label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <input aria-required="false" id="pepPhoneNumber" placeholder="Phone Number" type="text" class="JLJ-B" value=""></input>
                                    {/* <div style={{fontSize:"12px",paddingLeft:"5px"}}><p>In most cases, you'll be able to change your username back to luong.dt for another 14 days. Learn More</p></div> */}
                                </div>
                            </div>
                        </div>
                        <div className="eE-OA" style={{marginTop:"10px"}}>
                            <aside className="sxIVS">
                                <label className="pepName">Gender</label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <input aria-required="false" id="pepGender" placeholder="Gender" type="text" class="JLJ-B" value=""></input>
                                    {/* <div style={{fontSize:"12px",paddingLeft:"5px"}}><p>In most cases, you'll be able to change your username back to luong.dt for another 14 days. Learn More</p></div> */}
                                </div>
                            </div>
                        </div>
                        <div className="eE-OA" style={{marginTop:"10px"}}>
                            <aside className="sxIVS">
                                <label className="pepName"></label>
                            </aside>
                            <div className="ada5V">
                                <div className="fi8zo">
                                    <button type="submit" class="btn ">Submit</button>
                                </div>
                            </div>
                        </div>
                    </form>
                </article>
            </div>
        </main>
    )
}

export default EditProfile
