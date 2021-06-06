import React from 'react'
import { Link, useHistory, useParams } from 'react-router-dom'
function Essays() {
    const { id } = useParams();
    return (
        <>
            <div style={{ height: "100%", minHeight: "650px", width: "100%", backgroundColor: "#fff" }}>
                <div style={{ display: "flex", padding: "50px 150px", minHeight: "650px" }}>
                    {/* {id} */}
                    <div style={{ width: "60%", padding: "20px", border:"2px", boxSizing:"border-box", borderStyle:"ridge" }}>
                        <section style={{ backgroundColor: "#fff", fontSize:"20px" }}>
                            <span>There has been an increasing tendency of providing online courses in addition to
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
                                modern world.</span>
                        </section>
                    </div>
                    <div style={{padding:"20px", width:"40%",border:"2px", boxSizing:"border-box", borderStyle:"ridge"  }}>
                        <div style={{display:"flex", width:"100%"}}>
                            <Link to="/profile" style={{display:"flex"}}>
                                <img style={{height:"50px",width:"50px", borderRadius:"50%",borderColor:"#383838",borderStyle:"ridge",border:"2px", backgroundColor:"#fff"}} src={"https://www.oxfordlearnersdictionaries.com/external/images/product/OALD_producthometop.png?version=2.1.29"}></img>
                                <span style={{fontSize:"20px", marginTop:"7px"}}>Luong.td</span>
                            </Link>
                            <div style={{width:"60%"}}></div>
                            <div style={{right:"0"}}>
                                <button style={{fontSize:"20px", marginTop:"7px", background:"none", border:"none"}}>☰</button>
                            </div>
                        </div>
                        

                        <hr style={{margin:"20px 0px"}}></hr>
                        <div >
                            <h3>Topic:</h3>
                            <p>Some universities offer online courses as an alternative to classes delivered on campus. Do you think this is a positive or negative development?</p>
                        </div>
                        <hr style={{margin:"20px 0px"}}></hr>
                        <div>

                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}

export default Essays
