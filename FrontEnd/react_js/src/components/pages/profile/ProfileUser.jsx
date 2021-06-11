import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom';
import './ProfileUser.css'
import axios from 'axios'
import Essay from '../Forum/Essays/Essay'
import {data} from './data'


const url = "https://localhost:44391/api/user";

function ProfileUser() {

    const [infor, setUserInfo] = useState('');
    const [isEssays, setIsEssays] = useState(true);
    const [essays, settEssays] = useState([]);
    useEffect(async () => {
        if (localStorage.getItem("token") == null) {
            window.location.replace("/signin");
        }
        else{
            // fetch data
            var myHeader = new Headers();
            myHeader.append("Content-Type", "application/json");
            myHeader.append("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJsdW9uZ0BnbWFpbC5jb20iLCJqdGkiOiI5ZjI0ZDQ4Zi05NjJkLTRjZjAtOWZlOC0yODVkOGQ1YjQ3OTEiLCJlbWFpbCI6Imx1b25nQGdtYWlsLmNvbSIsImlkIjoiZGRmZmRiMzItZTFhZS00ZWE5LTliNDktYTlkNjg4N2Q5YThhIiwibmJmIjoxNjIzMTMzNzMyLCJleHAiOjE2MjMxNDA5MzIsImlhdCI6MTYyMzEzMzczMn0.7LdW3adlYuB2XKAqcaRxIp-czcIiO_GMsXtFW68Ju6g");

            var requestOptions={
                method:"GET",
                headers:myHeader,
                redirect:"follow"
            }
            // git essays
            await fetch("https://localhost:44391/api/essay", requestOptions)
            .then(response => response.json())
            .then(result =>{
                settEssays(result);
                console.log(essays);
            })
            .catch(error => console.log(error));

            // get info
            await fetch("https://localhost:44391/api/user", requestOptions)
            .then(response => response.json())
            .then(result =>{
                setUserInfo(result);
                console.log(infor);
            })
            .catch(error => console.log(error));
        }
    }, [])

    return (
        <div style={{ width: "100%", minHeight: "560px", height: "auto",backgroundColor:"#fff" }}>
            <div className="v9tJq">
                <header className="vtbgv">
                    <div className="XjzKX">
                        <div className="_4dMfM">
                            <div className="M-jxE">
                                <button className="Ia1UJ" title="Change your profile images">
                                    <img alt="Change your profile image" class="be6sR" src={"https://www.oxfordlearnersdictionaries.com/external/images/product/OALD_producthometop.png?version=2.1.29"}></img>
                                </button>
                                <div>
                                    <form method="POST" role="presentation">
                                        <input accept={"image/jpeg,image/png"} class="tb_sK" type="file"></input>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                    <section className="zwlfE">
                        <div className="nZSzR">
                            <h2 className="_7UhW9">{infor.userName}</h2>
                            <div className="QzzMF" style={{marginLeft:"20px"}}>
                                <Link to="/editprofile" className="sqdOP" >Edit your profile</Link>
                            </div>
                            <div className="AFWDX" style={{marginLeft:"20px"}}>
                                <button class="wp06b" type="button">
                                    <div class="QBdPU ">
                                        <svg aria-label="Tùy chọn" class="_8-yf5 " fill="#262626" height="24" viewBox="0 0 48 48" width="24"><path clip-rule="evenodd" d="M46.7 20.6l-2.1-1.1c-.4-.2-.7-.5-.8-1-.5-1.6-1.1-3.2-1.9-4.7-.2-.4-.3-.8-.1-1.2l.8-2.3c.2-.5 0-1.1-.4-1.5l-2.9-2.9c-.4-.4-1-.5-1.5-.4l-2.3.8c-.4.1-.8.1-1.2-.1-1.4-.8-3-1.5-4.6-1.9-.4-.1-.8-.4-1-.8l-1.1-2.2c-.3-.5-.8-.8-1.3-.8h-4.1c-.6 0-1.1.3-1.3.8l-1.1 2.2c-.2.4-.5.7-1 .8-1.6.5-3.2 1.1-4.6 1.9-.4.2-.8.3-1.2.1l-2.3-.8c-.5-.2-1.1 0-1.5.4L5.9 8.8c-.4.4-.5 1-.4 1.5l.8 2.3c.1.4.1.8-.1 1.2-.8 1.5-1.5 3-1.9 4.7-.1.4-.4.8-.8 1l-2.1 1.1c-.5.3-.8.8-.8 1.3V26c0 .6.3 1.1.8 1.3l2.1 1.1c.4.2.7.5.8 1 .5 1.6 1.1 3.2 1.9 4.7.2.4.3.8.1 1.2l-.8 2.3c-.2.5 0 1.1.4 1.5L8.8 42c.4.4 1 .5 1.5.4l2.3-.8c.4-.1.8-.1 1.2.1 1.4.8 3 1.5 4.6 1.9.4.1.8.4 1 .8l1.1 2.2c.3.5.8.8 1.3.8h4.1c.6 0 1.1-.3 1.3-.8l1.1-2.2c.2-.4.5-.7 1-.8 1.6-.5 3.2-1.1 4.6-1.9.4-.2.8-.3 1.2-.1l2.3.8c.5.2 1.1 0 1.5-.4l2.9-2.9c.4-.4.5-1 .4-1.5l-.8-2.3c-.1-.4-.1-.8.1-1.2.8-1.5 1.5-3 1.9-4.7.1-.4.4-.8.8-1l2.1-1.1c.5-.3.8-.8.8-1.3v-4.1c.4-.5.1-1.1-.4-1.3zM24 41.5c-9.7 0-17.5-7.8-17.5-17.5S14.3 6.5 24 6.5 41.5 14.3 41.5 24 33.7 41.5 24 41.5z" fill-rule="evenodd"></path></svg></div>
                                </button>
                            </div>
                        </div>
                        <ul class="k9GMp ">
                            <li class="Y8-fY ">
                                <span class="-nal3 ">
                                    <span class="g47SY ">0</span> bài viết</span>
                            </li>
                            <li class="Y8-fY ">
                                <a class="-nal3 " href="/luong.dt/followers/" tabindex="0">
                                    <span class="g47SY " title="7">7</span> người theo dõi
                                    </a>
                            </li>
                            <li class="Y8-fY " style={{marginLeft:"20px"}}>
                                <a class="-nal3 " href="/luong.dt/following/" tabindex="0">Đang theo dõi 
                                <span class="g47SY ">35</span> người dùng</a>
                            </li>
                        </ul>
                        <div class="-vDIg">
                            <h1 class="rhpdm">Trần Lương</h1>
                            <br></br>
                        </div>
                    </section>
                </header>
                <br></br>
                <div style={{width:"100%", height:"1px", backgroundColor:"red"}}></div>
                <div className="fx7hk" style={{marginBottom:"-20px"}}>
                    <a class="_9VEo1" href="#" onClick={() => setIsEssays(true)}>
                        <span className="smsjF " style={{fontSize:"20px"}}>
                            Essays
                        </span>
                    </a>
                    <a class="_9VEo1" onClick={() => setIsEssays(false)}>
                        <span className="smsjF" style={{fontSize:"20px"}}>
                            Saved
                        </span>
                    </a>
                </div>
                <br></br>
                <div style={{width:"100%", height:"1px", backgroundColor:"red"}}></div>
                <main style={{width:"100%", height:"auto"}}>
                    {isEssays && <ul style={{display:"grid", gridTemplateColumns:"1fr 1fr 1fr", listStyleType:"none"}}>
                        <li class="overf" style={{borderStyle:"ridge", marginBottom: "16px", width: "100%",maxWidth:"300px",overflow:"hidden", border:"5px", margin:"15px" }}>
                            <Link to="/writing" style={{display:"flex", justifyContent:"center", alignItems:"center"}}>
                                {/* <div className={"items"} style={{ width: "100%" }}>
                                    <p className={"article-title overs"} style={{overflow:"hidden"}}></p>
                                    <p className={"article-date"}></p>
                                    <p className={"article-date"}>New Essays</p>
                                </div> */}
                                <button className="btn" style={{}}>New Essays</button>
                            </Link>
                        </li>
                        {essays.map((essay) => {

                            var hrf = "/essay/"+essay.id;
                            return <li class="overf" style={{borderStyle:"ridge", marginBottom: "16px", width: "100%",maxWidth:"300px",overflow:"hidden", border:"5px", margin:"15px" }} keys={essay.id}>
                                <Link to={hrf} >
                                <div className={"items"} style={{ width: "100%" }}>
                                    <p className={"article-title overs"} style={{overflow:"hidden"}}>{essay.topic}</p>
                                    <p className={"article-date"}>{essay.username}</p>
                                    <p className={"article-date"}>{essay.date}</p>
                                </div>
                            </Link>
                        </li>
                        })}
                    </ul> || <ul style={{display:"grid", gridTemplateColumns:"1fr 1fr 1fr", listStyleType:"none"}}>
                        {essays.map((essay) => {
                            return <li class="overf" style={{borderStyle:"ridge", marginBottom: "16px", width: "100%",maxWidth:"300px",overflow:"hidden", border:"5px", margin:"15px" }} keys={essay.id}>
                                <a href="#" >
                                <div className={"items"} style={{ width: "100%" }}>
                                    <p className={"article-title overs"} style={{overflow:"hidden"}}>{essay.topic}</p>
                                    <p className={"article-date"}>{essay.username}</p>
                                    <p className={"article-date"}>{essay.date}</p>
                                </div>
                            </a>
                        </li>
                        })}
                    </ul>}
                </main>
            </div>
        </div>
    )
}

export default ProfileUser
