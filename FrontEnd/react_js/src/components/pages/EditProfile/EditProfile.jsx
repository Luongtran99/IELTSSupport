import React, {useState, useEffect} from 'react'
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
    const [userDetail, setUserDetail] = useState([]);
    const [show, setShow] = useState([false]);
    const [selectedFile, setSelectedFile] = useState();
    const [token, setToken] = useState();
    var myHeader = new Headers();
    myHeader.append("Content-Type","application/json");
    myHeader.append("Authorization", "Bearer "+ sessionStorage.getItem("token"));
    // update user

    // change user profile image
    const editImage = (e) => {
        e.preventDefault();
        setSelectedFile(e.target.files[0]);
        document.getElementById("save_panel").style.display = "flex";
        var myHeaders = new Headers();
        myHeaders.append("Authorization", "Bearer "+sessionStorage.getItem("token"));
        //myHeaders.append("Cookie", ".AspNetCore.Identity.Application=CfDJ8Oz-3WPzo5xGrQPZqgLp7qX9nsqSI6ZcxlvgLbklYkEheO9SP6L6NqGbyR2L0sf7HoxW4JNZOSW99vC_8edrxE-EzifxlYAIKueaEommkXwZgM7vIlLq3cwwMNTyDdRxcbY6_PvHQ-StE2SG33uCN5VGoSg4hnh6KKjtXdwsSViQrQkZsMn85TPlsVOvv5TmTa-e4NdWFTiN9wO7U54WRt34wv11P47R35-MAThtQB_sSFj338ZJp2Inv0WIA5V9Jdzsbk-Fovpf5uZmsFbYH8uX3NkEkyLf71BzcMb1dOl2d5Va5jQyxl6jBGEb2kEEV7cf86zjqxu_X8Igyididq2DK3gfn1s60BMz4npZyteATMrfEsCLElCWhvv6UvZh02rkV_aTaKhx8xW1J8wdOS1ImuJO4x6G_KcHS8_KkD2dCfEBFDkWva4_VMO9Tov1K8rNHnBVoSf9BrkPnTRiGu-n4TDyGh5IZkfnpgcBKx4gdxBBNT6w72CrN3hx3ohFzXeoqCV2ved4pSZ6Ev1VrmJj6zbUuFLdv66-WGtSdC5kc1fVhKVphUPIBSNRqgBZiY6_s1WF8OuclvYv1vPBW90NUz7ZDEIV9z50RtEu31ZG9mW6bwEqSlxwLyIf94ITMA");

        var formdata = new FormData();
        formdata.append("file", e.target.files[0], e.target.files[0].name);

        var requestOptions = {
            method: 'POST',
            headers: myHeaders,
            body: formdata,
            redirect: 'follow'
        };

        fetch("https://localhost:44391/api/User/edit_avatar", requestOptions)
            .then(response => response.json())
            .then(result => console.log(result))
            .catch(error => console.log('error', error));

        
        document.getElementById("update-image").src = URL.createObjectURL(e.target.files[0]);
    }

    // get user details
    useEffect(()=>{
        setToken(sessionStorage.getItem("token"));
        fetch("https://localhost:44391/api/user", {
            method:"GET",
            headers:myHeader,
            redirect:"follow"
        })
        .then(response => response.json())
        .then(result =>{
            //console.log(result);
            if(sessionStorage.getItem("username") == null){
                sessionStorage.setItem("username", result.userName);
            }
            if(sessionStorage.getItem("userId") == null){
                sessionStorage.setItem("userId", result.Id);
            }

            document.getElementById("pepName").value = result.userName;
            document.getElementById("pepUsername").value = result.userName;
            document.getElementById("pepEmail").value = result.email;
            document.getElementById("pepPhoneNumber").value = result.phoneNumber;
            document.getElementById("pepBio").value = result.bio;
            document.getElementById("pepWebsite").value = result.webSite;
            setUserDetail(result);
            console.log(userDetail);
        })
        .catch(error => console.log(error));
    }, [])

    const EditUserInfo = (e) => {
        var raw = JSON.stringify(
            {   "username": document.getElementById("pepUsername").value,
                "email": document.getElementById("pepEmail").value,
                "phonenumber": document.getElementById("pepPhoneNumber").value,
                "Bio": document.getElementById("pepBio").value,
                "Website": document.getElementById("pepWebsite").value,
                "Gender": "1" 
            });

        var requestOptions = {
            method: 'POST',
            headers: myHeader,
            body: raw,
            redirect: 'follow'
        };

        fetch("https://localhost:44391/api/User/edit", requestOptions)
            .then(response => response.json())
            .then(result => console.log(result))
            .catch(error => console.log('error', error));
    }

    return (
        <main style={{width:"100%",minHeight:"650px", height:"auto", backgroundColor:"#fff",color:"#383838",marginTop:"-30px", display:"flex",justifyContent:"center",alignItems:"center"}} role="main">
            <div id="save_panel" style={{position:"absolute", minHeight:"400px", width:"400px", display:"none", justifyContent:"center", alignItems:"center", zIndex:"2"}}>
                <div class="Ia1UJ" style={{display:"block", boxSizing:"border-box",border:"5px", borderStyle:"ridge"}}>
                    <img id="update-image" style={{position:"relative", width:"100%", height:"350px"}} className="be6sR" src="#"></img>
                    <div style={{width:"100%", height:"50px", display:"flex", justifyContent:"center", alignItems:"center", background:"#fff"}}>
                        <button className="btn sqdOP" style={{margin:"20px"}} type="button">Save Image</button>
                        <button className="btn sqdOP" style={{margin:"20px", color:"red"}} onClick={()=>document.getElementById("save_panel").style.display="none"} type="button">Cancel</button>
                    </div>
                </div>
            </div>
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
                                <button class="Ia1UJ" title="Change your phone" onClick={() => document.getElementById("image-file").click()}>
                                    <img alt="Change your profile image" class="be6sR" src={`data:image/jpeg;base64,${userDetail.profileImage}`}></img>
                                </button>
                                <div >
                                    <form enctype="multipart/form-data" method="POST" role="presentation">
                                        <input accept="image/jpeg,image/png" id="image-file" class="tb_sK" type="file" onChange={(e) => editImage(e)}/>
                                    </form>
                                </div>
                            </div>
                        </div>
                        <div className="XX1Wc" style={{display:"block"}}>
                            <h1 className="kHYQv" title="locery">{userDetail.userName}</h1>
                            <button className="sqdOP" type="button" onClick={() => document.getElementById("image-file").click()} onChange={(e) => editImage(e)}>Change Profile Photo</button>
                        </div>
                    </div>
                    <form className="kWXsT" style={{marginTop:"20px",marginBottom:"20px"}}>
                        <div className="eE-OA">
                            <aside className="sxIVS">
                                <label className="pepName">Name</label>
                            </aside>
                            <div className="ada5V">
                                <div className="_4EzTm" style={{width:"100%", maxWidth:"355px"}}>
                                    <input aria-required="true" id="pepName" placeholder="Name" type="text" class="JLJ-B" ></input>
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
                                    <input aria-required="false" id="pepUsername" placeholder="Name" type="text" class="JLJ-B" value={userDetail.userName}></input>
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
                                    <input aria-required="false" id="pepWebsite" placeholder="Website" type="text" class="JLJ-B" ></input>
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
                                    <textarea aria-required="false" id="pepBio" placeholder="" type="text" class="JLJ-B" style={{minHeight:"70px", paddingTop:"5px"}} ></textarea>
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
                                    <input aria-required="false" id="pepEmail" placeholder="@gmail.com" type="text" class="JLJ-B" ></input>
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
                                    <input aria-required="false" id="pepPhoneNumber" placeholder="Phone Number" type="text" class="JLJ-B" ></input>
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
                                    <input aria-required="false" id="pepGender" placeholder="Gender" type="text" class="JLJ-B" value={userDetail.gender == 1 ? "Male":"Female"}></input>
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
                                    <button type="button" class="btn " onClick={EditUserInfo}>Submit</button>
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
