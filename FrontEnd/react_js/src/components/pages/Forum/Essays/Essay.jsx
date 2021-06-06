import React, { useState } from 'react'
import { Link } from 'react-router-dom';
import './Essay.css'

function Essay({essays, loading}) {
    if(loading){
        return <h2>Loading...</h2>
    }

    return (
        <ul style={{marginTop:"20px",width:"100%",maxWidth:"830px"}}>
            {essays.map((essay) =>{
                var hrf = "/essay/" + essay.id;
                var id = essay.id;
                return <li style={{ marginBottom: "16px", width: "100%" }} keys={essay.id}>
                    <Link to={hrf} >
                        <div className={"items"} style={{ width: "100%" }}>
                            <p className={"article-title"}>{essay.topic}</p>
                            <p className={"article-date"}>{essay.username}</p>
                            <p className={"article-date"}>{essay.date}</p>
                        </div>
                    </Link>
                </li>
            })}
        </ul>
    )
}

export default Essay
