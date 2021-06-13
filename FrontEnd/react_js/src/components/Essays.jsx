import React, { useState, useEffect } from 'react'
import { Link, useHistory, useParams } from 'react-router-dom'
import './Essays.css'

function Essays() {
    const { id } = useParams();

    const [showSetting, setShowSetting] = useState(false);
    const [edit, setEdit] = useState(false);
    const [essayDetail, setEssayDetail] = useState([]);
    const [context, setContent] = useState('');
    const [username, setUsername] = useState('');
    useEffect(async () => {
        await fetch("https://localhost:44391/api/essay/"+id, {
            method:"GET",
            redirect:"follow"
        })
        .then(response => response.json())
        .then(result => {
            //console.log(result);
            setEssayDetail(result);
            setContent(result.text);
        })
        .catch(error=> console.log(error))
        // no optimize
        var myHeader = new Headers();
            myHeader.append("Content-Type", "application/json");
            myHeader.append("Authorization", "Bearer " + sessionStorage.getItem("token"));

        var requestOptions={
            method:"GET",
            headers:myHeader,
            redirect:"follow"
        }
        // 
        await fetch("https://localhost:44391/api/user", requestOptions)
            .then(response => response.json())
            .then(result =>{
                setUsername(result.userName);
                //console.log(infor);
            })
            .catch(error => console.log(error));
    }, [])


    return (
        <>
            <div style={{ height: "100%", minHeight: "650px", width: "100%", backgroundColor: "#fff" }}>
                <div style={{ display: "flex", padding: "50px 150px", minHeight: "650px" }}>
                    {/* {id} */}
                    <div style={{ width: "60%", padding: "20px", border: "2px", boxSizing: "border-box", borderStyle: "ridge" }}>
                        {!edit && <section style={{ backgroundColor: "#fff", fontSize: "20px" }}>
                            {/* <span>There has been an increasing tendency of providing online courses in addition to
                            formal ones by universities around the world. Concerning the effects of such a
                            trend, I firmly believe that the availability of computer-based courses should be
                                considered as a completely beneficial movement.</span>
                            <br></br>
                            <span>To begin with, it is a fallacy to consider the provisions of internet courses as a
                            negative trend. In fact, some people insist that opting for online courses could lead
                            to the probability of forming generations of students who would lack critical social
                            skills such as inter-personal and teamwork capabilities. However, such a claimed
                            scenario would not happen with the support of advanced online communication
                            platforms. Thanks to the introduction of effective communication tools such as
                            Skype or Facetime, students could easily interact with each other for academic
                            discussions  or  team  assignments,  ensuring  their  chances  to  enhance  essential
                            communication skills. Therefore, it seems obvious to me that presumed negative
                                impacts of visual classes would not be a matter.</span>
                            <br></br>
                            <span>On the other hand, I would strongly argue that the provision of online courses as
                            alternatives  is  beneficial  to  both  students  and  universities.  Firstly,  access  to
                            Internet-based  courses  would  enable  students,  especially  those  who  reside  in
                            remote regions, to get access to higher education with ultimate flexibility and
                            convenience. Compared to traditional courses which require student attendance
                            and fixed class schedules. Internet-based ones allow students to study at their own
                            pace by granting them full rights to decide their schedules and academic progress.
                            Secondly? with regard to universities, offering online courses could help them
                            reach more students worldwide with reduced investments. Since classes could be
                            conducted online with no geographic restrictions, colleges would be spared from
                            the costs of expanding their schools yet still able to provide courses for more
                                national and international students.</span>
                            <br></br>
                            <span>To conclude, the existence of computer-based courses as alternative options to
                            formal  classes  should  be  considered  as  a  profitable  education  progress  in  the
                                modern world.</span> */}
                            {context.split('\n').map((par) =>{
                                return <span>
                                    {par}
                                    <br></br>
                                </span>
                            })}
                        </section>
                        || <div style={{ backgroundColor: "#fff", fontSize: "20px",outline:"none"}} contentEditable="true">
                            {context.split('\n').map((par) =>{
                                return <span>
                                    {par}
                                    <br></br>
                                </span>
                            })}
                        </div>}
                    </div>
                    <div style={{ padding: "20px", width: "40%", border: "2px", boxSizing: "border-box", borderStyle: "ridge" }}>
                        <div style={{ display: "flex", width: "100%" }}>
                            <Link to="/profile" style={{ display: "flex" }}>
                                <img style={{ height: "50px", width: "50px", borderRadius: "50%", borderColor: "#383838", borderStyle: "ridge", border: "2px", backgroundColor: "#fff" }} src={"https://www.oxfordlearnersdictionaries.com/external/images/product/OALD_producthometop.png?version=2.1.29"}></img>
                                <span style={{ fontSize: "20px", marginTop: "7px" }}>{username}</span>
                            </Link>
                            <div style={{ width: "60%" }}></div>
                            <div style={{ right: "0" }}>
                                <button onClick={() => setShowSetting(!showSetting)} style={{ fontSize: "20px", marginTop: "7px", background: "none", border: "none" }}>☰</button>
                                {showSetting && <div id="side-bar"
                                    style={{ right: "150px", border: "1px", borderStyle: "solid", minHeight: "200px",height:"auto", width: "150px", position: "absolute", backgroundColor: "white"}}>
                                    <ul style={{ margin: "2px", paddingLeft: "5px", textAlign: "center", paddingTop: "20px" }}>
                                        <li style={{ padding: "10px", }}>
                                            <a href="#" >
                                                <div className={"ali"} style={{ width: "100%", height: "30px" }} onClick={() =>{
                                                    setEdit(true);
                                                    
                                                }}>
                                                    Edit
                                                </div>
                                            </a>
                                        </li>
                                        <li style={{ padding: "10px" }}>
                                            <a href="#" >
                                                <div className={"ali"} style={{ width: "100%", height: "30px" }}>
                                                    Delete
                                                </div>
                                            </a>
                                        </li>
                                        <li style={{ padding: "10px" }}>
                                            <a href="#" >
                                                {/* <div className={"ali"} onClick={(e) => {
                                                    e.preventDefault();
                                                    var p = document.getElementById("writing_area").innerHTML;
                                                    var a = p.substring(1, 4);
                                                    p = p.replace(a, "<span style=\"text-decoration:underline;text-decoration-color:yellow;padding-left:0\">" + a + "</span>");

                                                    document.getElementById("writing_area").innerHTML = p;
                                                    console.log(document.getElementById("writing_area").innerHTML.search("hello").length);
                                                    console.log(document.getElementById("writing_area").textContent.length)
                                                }} style={{ width: "100%", height: "30px" }}> */}
                                                <div className="ali">
                                                    Delete All
                                                </div>
                                            </a>
                                        </li>
                                        {edit && <li style={{ padding: "10px" }} >
                                            <a href="#">
                                                <div className={"ali"} style={{ width: "100%", height: "30px" }}>Save</div>
                                            </a>
                                        </li>}
                                    </ul>
                                </div>}
                            </div>
                        </div>


                        <hr style={{ margin: "20px 0px" }}></hr>
                        <div >
                            <h3>Topic:</h3>
                            <p>{essayDetail.topic}</p>
                        </div>
                        <hr style={{ margin: "20px 0px" }}></hr>
                        <div>
                            {/* <b>HIGHEST STAR</b>
                            <p style={{ marginBottom: "0px" }}>Author: Locery</p> */}
                            <p style={{ marginBottom: "0px" }}>Total stars: 120 <i class="fa fa-star" aria-hidden="true"></i> </p>
                            <Link to="/"></Link>
                            <button className="btn">Rate</button>
                            <div class="rate">
                                <input type="radio" id="star5" name="rate" value="5" />
                                <label for="star5" title="5 stars">5 stars</label>
                                <input type="radio" id="star4" name="rate" value="4" />
                                <label for="star4" title="4 stars">4 stars</label>
                                <input type="radio" id="star3" name="rate" value="3" />
                                <label for="star3" title="3 stars">3 stars</label>
                                <input type="radio" id="star2" name="rate" value="2" />
                                <label for="star2" title="2 stars">2 stars</label>
                                <input type="radio" id="star1" name="rate" value="1" />
                                <label for="star1" title="1 star">1 star</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

export default Essays
