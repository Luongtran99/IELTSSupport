import React from 'react'
import PropTypes from 'prop-types'
import './Dictionary.css'
import Words from './Words/Words'

function Dictionary(props) {
    return (
        <>
            <div className="container top-container" >
                <h1>Search Words</h1>
                <div className="main-wrap">
                    <main>
                        <form method={postMessage} className="form" style={{display:"flex", justifyContent:"center",height:"10vh",width:"120vh"}}>
                            <input type={'search'} className="" placeholder={"Search Words"}></input>
                            <button type={'submit'} className="btn btn--primary" style={{marginTop:"0px"}}>Search</button>
                        </form>
                    </main>
                </div>
            </div>
            <React.Fragment>
                <Words></Words>
            </React.Fragment>
        </>
    )
}

export default Dictionary

