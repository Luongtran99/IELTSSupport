import React, { useState } from 'react'
import { Link } from 'react-router-dom';
import './News.css'
function News() {

    const [date, setDate] = useState(new Date());

    return (
        <>
            <article className={"make_center"}>
                <div className={"make_center large"}>
                    <section class={"make_center"}>
                        <div style={{justifyContent:"center", textAlign:"center",verticalAlign:"center"}}>
                            <h2>Topic for today</h2>
                            <section  style={{fontFamily:"SegoeUI sans",fontSize:"1.5rem"}}>
                                Some universities offer online courses as an alternative to classes delivered
                                on campus. Do you think this is a positive or negative development?
                            </section>
                            <div className={"postDetails"}>
                                <b>HIGHEST STAR</b>
                                <p style={{marginBottom:"0px"}}>Author: Locery</p>
                                <p style={{marginBottom:"0px"}}>Total stars: 120 <i class="fa fa-star" aria-hidden="true"></i> </p>
                                <Link to="/"></Link>
                            </div>
                        </div>
                        <div style={{backgroundColor:"#fff",padding:" 1rem", borderRadius:"20px"}}>
                            <section style={{backgroundColor:"#fff"}}>
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
                    </section> 
                </div>
            </article>
            
            <article class={"make_center"} >
                <div className={"make_center large news"}>
                    <div style={{width:"100%",display:"flex",justifyContent:"center"}}>
                        <p style={{fontSize:"0.8rem"}}>
                            <h2 style={{color:"red"}}>IELTS NEWS</h2> at {date.toUTCString()}
                        </p>
                    </div>
                    <div style={{width:"100%",display:"flex",justifyContent:"center"}}> 
                        <ul style={{marginTop:"20px",width:"100%",maxWidth:"830px"}}>
                            <li style={{marginBottom:"16px",width:"100%"}}>
                                <a href="#" >
                                    <div className={"items"} style={{width:"100%"}}>
                                        <p className={"article-title"}>IELTS achieves international standard for quality and excellence in language assessment</p>
                                        <p className={"article-date"}>May 2021</p>
                                    </div>
                                </a>
                            </li>
                            <li style={{marginBottom:"16px",width:"100%"}}>
                                <a href="#" >
                                    <div className={"items"} style={{width:"100%"}}>
                                        <p className={"article-title"}>An update on test bookings in Canada</p>
                                        <p className={"article-date"}>April 2021</p>
                                    </div>
                                </a>
                            </li>
                            <li style={{marginBottom:"16px",width:"100%"}}>
                                <a href="#" >
                                    <div className={"items"} style={{width:"100%"}}>
                                        <p className={"article-title"}>IELTS Smart Learning helps improve spoken English capabilities in China</p>
                                        <p className={"article-date"}>March 2021</p>
                                    </div>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </article>   
        </>
    )
}

export default News
