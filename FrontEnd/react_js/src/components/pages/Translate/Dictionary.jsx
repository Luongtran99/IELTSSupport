import {React, useState, useCallback} from 'react'
import PropTypes from 'prop-types'
import './Dictionary.css'
import Words from './Words/Words'
import {data} from './data'
import { Link } from 'react-router-dom'
//import image from 'https://www.oxfordlearnersdictionaries.com/external/images/product/OALD_producthometop.png?version=2.1.29'

function Dictionary(props) {

    var url = "http://localhost:44391/api/dictionary/";

    
    const [word, setWord] = useState('');
    const [value, setValue] = useState(false);
    const [result, setResult] = useState('');
    const [topshow, setTopShow] = useState(true);

    const handleChange = (e) =>{
        const k = e.target.value;
        setWord(k);
    }

    const submitButton = (e) =>{
        e.preventDefault();
        url = url + word;
        //const k = await data.json();
        //console.log(data);
        setResult(data);
        
        setValue(!value);
        setTopShow(false);
    }

    return (
        <div>
            <div className="container top-container" style={{marginTop:"40px",marginBottom:"40px",borderRadius:"20px"}}>
                <h1>Search Words</h1>
                <div className="main-wrap">
                    <main>
                        <form onSubmit={submitButton} className="form" style={{display:"flex", justifyContent:"center",height:"10vh",width:"120vh"}}>
                            <input type='search' className="search" placeholder={"Search Words"} value={word}  onChange={handleChange}></input>
                            <button type={'submit'} onClick={() => {
                                
                            }} className="btn btn--primary" style={{marginTop:"0px",background:"#3367d6"}}>
                                Search
                            </button>
                        </form>
                    </main>
                </div>
            </div>
            {topshow && <div className="responsive_row" style={{paddingTop:"60px"}}>
                <div className="dic_top_container">
                    <div className="dic_top_background english">
                        <div className="dic row responsive_container" style={{display:"flex", justifyContent:"center"}}>
                            <div className="crtc1_cntrd dic_top_copy">
                                <h1 style={{fontSize:"2rem"}}>Dictionary Advanced Learner's Dictionary</h1>
                                <p></p>
                                <p>It's a new feature to help raise level dictionary for learners of English</p>
                                <p>It's version2, we are publishing out WebAPI for developer and </p>
                                <p>Built based on Oxford Advanced Learner's Dictionary</p>
                                <a href="https://www.oxfordlearnersdictionaries.com/definition/english/" className="buy_book">Buy this book</a>
                            </div>
                            <img className="box-image" border="1" src={"https://www.oxfordlearnersdictionaries.com/external/images/product/OALD_producthometop.png?version=2.1.29"} title="" alt=""/>
                        </div>
                    </div>
                    <svg viewBox="0 0 1200 46" className="product_top_svg_clip" style={{height: "auto"}}><path fill="#ffffff" fill-rule="evenodd" d="M0-7h1200v53H0V-7zm0 30.113V-7h1200v43.495c-37.762 7.58-155.36 7.58-352.791 0C721.412 31.665 480.68.297 248.535.355 197.087.368 114.242 7.955 0 23.113z"></path></svg>
                </div>
                <div className="responsive_row">
                    <div className="white_background">
                        <div className="major-usp" style={{display:"flex"}}>
                            <div className="vrtcl_cntrd">
                                <h1>Build your vocabulary</h1>
                                <p>SupportIELTS is created especially for learners of English, with clear and simple definitions, synonyms, real voice audio and example sentences showing language in use.</p>
                                <p>The A-Z is integrated with the new Oxford 3000 and Oxford 5000 word lists, which provide core vocabulary that every student needs to learn, and OPAL word lists, which contain the most important vocabulary for academic writing and speaking.</p>
                                <a href="#" className="secondaryButton" title="Sample entry">Sample Entry</a>
                            </div>
                            <img className="majorUSPImg" src={"https://www.oxfordlearnersdictionaries.com/external/images/product/OALD_producthomeimage1.svg?version=2.1.29"}></img>
                        </div>
                    </div>
                </div>
            </div>}
            <article style={{height:"auto"}}>
                {value && <Words {...data.obj}></Words>}
            </article>
        </div>
    )
}

export default Dictionary

