import {React, useState, useCallback} from 'react'
import PropTypes from 'prop-types'
import './Dictionary.css'
import Words from './Words/Words'
import {data} from './data'
function Dictionary(props) {

    var url = "http://localhost:44391/api/dictionary/";

    
    const [word, setWord] = useState('');
    const [value, setValue] = useState(false);
    const [result, setResult] = useState('');

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
            <article style={{height:"auto", minHeight:"300px"}}>
                {value && <Words {...data.obj}></Words>}
            </article>
        </div>
    )
}

export default Dictionary

