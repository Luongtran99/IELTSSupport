import React, {useState} from 'react'
import './Writing.css'
import SupportWord from './SupportWords/SupportWord'
import {Button} from '../../Navbar/Button/Button'
import { Link } from 'react-router-dom';
import {data} from './data';

function Writing() {

    const [showSideBar, setShowSideBar] = useState(false);
    const [defaults, setDefault] = useState(true);
    const [result, setResult] = useState('');

    const changeStateSideBar = () => {
        setShowSideBar(!showSideBar);
    }

    const changeDefault = () => {
        document.getElementById("check_grammar_result").style.display = "block"
    }

    return (
        <div style={{height:"100%", minHeight:"650px", width:"100%"}}>
            <button  onClick={changeStateSideBar}
            style={{right:"0px", position:"absolute", height:"40px", width:"40px", marginTop:"20px", marginRight:"20px", borderRadius:"50%",fontSize:"20px"}}>☰</button>
            {showSideBar && <div id="side-bar" 
            style={{right:"0px",border:"1px",borderStyle:"solid" ,height:"200px",width:"150px", position:"absolute", backgroundColor:"white",marginTop:"80px"}}>
                <ul style={{margin:"2px",paddingLeft:"5px",textAlign:"center",paddingTop:"20px"}}>
                    <li style={{padding:"10px", }}>
                        <a href="#" >
                            <div className={"ali"} style={{width:"100%", height:"30px"}}>
                                Save
                            </div>
                        </a>
                    </li>
                    <li style={{padding:"10px"}}>
                        <a href="#" >
                            <div className={"ali"} onClick={changeDefault} style={{width:"100%", height:"30px"}}>
                                Check Grammar
                            </div>
                        </a>
                    </li>
                    <li style={{padding:"10px"}}>
                        <a href="#" >
                            <div className={"ali"} style={{width:"100%", height:"30px"}}>
                                Delete All
                            </div>
                        </a>
                    </li>
                    <li>
                        <a></a>
                    </li>
                </ul>
            </div>}
            <div style={{display:"flex", marginLeft:"20px"}}>
                <div style={{display:"flex", justifyContent:"center", textAlign:"center", marginTop:"20px"}} id="left">
                    <div>
                        <h2>Topic</h2>
                        <div style={{borderRadius:"5px"}}>
                            <textarea   contentEditable={true} 
                                className={"topic_area font_select"} id="topic_area">
                            </textarea>
                        </div>
                        <div style={{marginTop:"20px"}}>
                            <h2>Support Words</h2>
                            <SupportWord ></SupportWord>
                        </div>
                    </div>
                </div>
                
                <div style={{ marginLeft:"10px", textAlign:"center", width:"60rem",marginTop:"20px"}} id="right">
                    <div >
                        <h2>Writing IELTS Task 2</h2>
                        <div className={"edit_area font_select"} id="writing_area" 
                             contentEditable={true} spellCheck={true}>

                        </div>
                    </div>
                </div>
                 
            </div>
            <div id="check_grammar_result" style={{display:"none", width:"100%", textAlign:"center", minHeight:"200px", height:"auto"}}>
                    <h2>Result</h2>
                    <div >

                    </div>
            </div> 
        </div>
    )
}

export default Writing
