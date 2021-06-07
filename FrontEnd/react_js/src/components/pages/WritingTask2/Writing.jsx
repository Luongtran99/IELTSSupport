import React, {useState,useEffect} from 'react'
import './Writing.css'
import SupportWord from './SupportWords/SupportWord'
import {data} from './data';
import { Delete } from '@material-ui/icons';

const SPACE = 32;
const ENTER = 13;
const QUESTION = 191;
const Phay = 190;
const DIGIT1 = 49;
const DIGIT2 = 50;
const SEMICOLON = 186;
const QUOTE = 222;
const PERIOD = 188;
const BRACKETLEFT = 219;
const BRACKETRIGHT = 221;
const DIGIT9 = 57;
const DIGIT10 = 48;

function Writing() {
    //var url = "https://localhost:44391/api/spell/grammar/";
    // click to button check grammar
    const [show, setShow] = useState(false);
    const [showSideBar, setShowSideBar] = useState(false);
    const [result, setResult] = useState('');
    const [writing, setWriting] = useState('');
    const [clicked, isClicked] = useState(false);
    const changeStateSideBar = () => {
        setShowSideBar(!showSideBar);
    }

    const saveEssays = () => {
        var myHeader = new Headers();
        myHeader.append("Content-Type", "application/json");
        myHeader.append("Authorization","Bearer "+localStorage.getItem("token"));
        var _body = JSON.stringify({
            "text": writing,
            "topic": document.getElementById("topic_area").textContent
        });

        var requestOptions = {
            method: "POST",
            headers: myHeader,
            body: _body,
            redirect: "follow"
        };

        fetch("https://localhost:44391/api/essay", requestOptions)
            .then(response => response.json())
            .then(result => {
                if (result == null) {
                    alert("opps! Something wrong!");
                }
                else {
                    alert("Saved Essay Completely");
                }
            })
            .catch(error => console.log(error));
    }

    const handleChange = (e) =>{
        const k = e.target.value;
        //console.log(k);
        
        setWriting(k);
    }

    const changeDefault = (e) => {
        e.preventDefault();
        //document.getElementById("writing_area").style.display="none";
        //isClicked(true);
        //document.getElementById("id_assistant").innerHTML = "";
        if(writing == ''){
            return;
        }
        var myHeader = new Headers();


        myHeader.append("Content-Type", "application/json");

        var requestOptions = {
            method:"GET",
            headers:myHeader,
            redirect:'follow'
        };
        fetch("https://localhost:44391/api/spell/grammar/" + writing, requestOptions)
        .then(response => response.json())
        .then(k => 
            { 
                setResult(k);
                setShow(true);
            })
        .catch(error => console.log("error", error));
        // var getsupport = document.getElementById("id_assistant");
        // for(let i = 0; i < result.obj.length; i++){
        //     var newli = document.createElement("div");
        //         newli.innerHTML = result.obj[i].message;
                
        //         getsupport.appendChild(newli);
        // }
    }

    const DeleteAll = (e) =>{
        e.preventDefault();
        console.log(result.obj);
    }

    const spellCheck = async (word) => {
        var requestOptions = {
            method: "GET",
            redirect:"follow"
        }

        await fetch("https://localhost:44391/api/spell/search/" + word.trim(), requestOptions)
        .then(response => response.json())
        .then(result =>{
            var getsupport = document.getElementById("id_assistant");
            getsupport.innerHTML = "";
            if (result.code === 200) {
                // var newli = document.createElement("div");
                // newli.innerHTML = word;
                // getsupport.appendChild(newli);
            } else {
                for (let i = 0; i < result.obj.length; i++) {
                  var newli = document.createElement("div");
                  newli.innerHTML = result.obj[i].word;
                  getsupport.appendChild(newli);
                }
            }
            console.log(result);
        })
        .catch(error => console.log("error", error));
    }

    const checkKeyUp = async (event) =>{
        event.preventDefault();
        var x = event.target.value;
        if(
            event.keyCode == SPACE ||
            event.keyCode == ENTER ||
            event.keyCode == QUESTION ||
            event.keyCode == DIGIT1 ||
            event.keyCode == SEMICOLON
          )
        {
      
            var regex = /([a-z]|[A-Z])\w+/g;
            // split text
            var splitChar = x.match(regex);
      
            if (splitChar != null) {
              // spell check
              //splitChar[splitChar.length - 1]
              await spellCheck(splitChar[splitChar.length - 1]);
            }
        }
    }

    return (
        <div style={{height:"100%", minHeight:"650px", width:"100%"}}>
            <div id="save_panel" style={{position:"absolute", height:"100%", width:"100%", display:"none", justifyContent:"center", alignItems:"center"}} onClick={()=>document.getElementById("save_panel").style.display="none"}>
                <div style={{height:"100px", width:"400px", background:"rgb(34 223 171)", display:"flex", justifyContent:"center"}}>
                    <div style={{display:"flex", justifyContent:"center", alignItems:"center", width:"20%"}}>
                        <button className="btn" onClick={() => saveEssays()} style={{padding:"0", margin:"0",height:"50px", width:"80px", backgroundColor:"#fff", color:"#000"}}>
                            Save
                        </button>
                    </div>
                    <div style={{height:"150px",width:"150px",marginTop:"-30px",backgroundColor:"red", borderRadius:"50%", display:"flex",justifyContent:"center",alignItems:"center", fontSize:"4rem"}}>?</div>
                    <div style={{display:"flex", justifyContent:"center", alignItems:"center", width:"20%"}}>
                        <button className="btn"onClick={()=>document.getElementById("save_panel").style.display="none"} style={{padding:"0", margin:"0",height:"50px", width:"80px", backgroundColor:"#fff", color:"#000"}}>
                            Cancel
                        </button>
                    </div>
                </div>
            </div>
            <button  onClick={changeStateSideBar}
            style={{right:"0px", position:"absolute", height:"40px", width:"40px", marginTop:"20px", marginRight:"20px", borderRadius:"50%",fontSize:"20px", backgroundColor:"red"}}>☰</button>
            {showSideBar && <div id="side-bar" 
            style={{right:"0px",border:"1px",borderStyle:"solid" ,height:"200px",width:"150px", position:"absolute", backgroundColor:"white",marginTop:"80px"}}>
                <ul style={{margin:"2px",paddingLeft:"5px",textAlign:"center",paddingTop:"20px"}}>
                    <li style={{padding:"10px", }}>
                        <a href="#" >
                            <div className={"ali"} style={{width:"100%", height:"30px"}} onClick={()=>{
                                if(localStorage.getItem("token")==null){
                                    sessionStorage.setItem("content_buf", writing);
                                    sessionStorage.setItem("topic_buf", document.getElementById("topic_area").innerHTML);
                                    sessionStorage.setItem("save_waiting", true);
                                    window.location.replace("/signin");
                                }else
                                {
                                    document.getElementById("save_panel").style.display="flex";
                                }
                            }}>
                                Save
                            </div>
                        </a>
                    </li>
                    <li style={{padding:"10px"}}>
                        <a href="#" >
                            <div className={"ali"} onClick={(e) => changeDefault(e)} style={{width:"100%", height:"30px"}}>
                                Check Grammar
                            </div>
                        </a>
                    </li>
                    <li style={{padding:"10px"}}>
                        <a href="#" >
                            <div className={"ali"} onClick={(e) => DeleteAll(e)} style={{width:"100%", height:"30px"}}>
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
                            <textarea   contentEditable={true} style={{marginTop:"10px"}}
                                className={"topic_area font_select"} id="topic_area">
                            </textarea>
                        </div>
                        <div style={{marginTop:"20px"}}>
                            <h2>WRITING ASSISTANT</h2>
                            <div className="edit_area scroll" id="id_assistant" style={{height:"19.7rem",maxWidth:"300px"}}>
                            {show && <div>
                                {
                                result.obj.map((i) => 
                            { 
                                return <div className="msghover" style={{borderStyle:"ridge", height:"40px",}}>{i.message}</div>
                            })}</div> }
                            
                            </div>
                        </div>
                    </div>
                </div>
                
                <div style={{ marginLeft:"10px", textAlign:"center", width:"60rem",marginTop:"20px"}} id="right">
                    <div >
                        <h2>Writing IELTS Task 2</h2>
                        <textarea className={"scroll edit_area font_select "} id="writing_area" 
                             spellCheck={false} onKeyUp={(e)=>checkKeyUp(e)} onChange={(e) => handleChange(e)} style={{marginTop:"11px", paddingLeft:"20px"}}>
                                
                        </textarea>
                        {/* {clicked && <div className={"scroll edit_area font_select "} id="writing_area_div" style={{display:"block"}} onClick={() => {isClicked(!clicked);document.getElementById("writing_area").style.display="flex"}}>
                                {result.obj.map((i) =>{
                                    return <>
                                        <span style={{textDecoration:"underline", textDecorationLine:""}}>writing.substring(i.from, i.to)</span>
                                    </>
                                })}
                        </div>} */}
                    </div>
                </div>
                 
            </div>
            {/* {show && <div>{result.obj.map((i) => {return <>{i.message}</>})}</div> } */}
            
        </div>
    )
}

export default Writing
