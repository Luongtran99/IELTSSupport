import React from 'react'
import PropTypes from "prop-types"
import './Words.css';
//var url = "http://localhost:44391/api/dictionary/";

const Words = ({word, meanings, phonetics}) => {

    const Definition = ({definition, example, synonyms}) => {
        return <div style={{lineHeight:"30px"}}>
            <div >
                <span style={{fontWeight:"600", fontSize:"1.15rem"}}>{definition}</span>
            </div>
            <div>
                <span>{example ? "Example: " + example : "Example: "  }</span>
            </div>
            <div style={{display:"flex"}}>
                <span>{synonyms ? "Synonyms: " + synonyms : null}</span>
            </div>
        </div>
    }
    
    const Meaning = 
        ({partOfSpeech, definitions}) => {
            return <div>
                <div className={"row_bar"}></div>
                <h2 style={{marginBottom:"0px", marginTop:"5px"}}>{word}</h2>
                <div>
                    <span style={{fontWeight:"700", fontSize:"14px", fontStyle:"italic"}}>{partOfSpeech}</span>
                </div>
                <div style={{display:"flex"}}>
                    {phonetics.map((phonetic) => {
                        return <div style={{display:"flex"}}>
                            <div onClick={convertTo}>
                                <i class="fa fa-play-circle" aria-hidden="true"></i>
                            </div>
                            <div style={{marginLeft:"4px"}}>
                                {phonetic.text}
                            </div>
                        </div>
                    })}                
                </div>
                <div className={"row_bar"}></div>
                {definitions.map((defi, id) => {
                    return <Definition key={id++} {...defi}>
                        
                    </Definition>
                })}
            </div>
        }
    
    const Phonetic = () =>{

    }

    const convertTo = (event) =>{
        event.preventDefault();
        var newaudio = new Audio('data:audio/ogg;base64,'+ phonetics[0].audio);
        newaudio.play();
    }

    return (
        <section class="words_details">
            <div style={{width:"40rem"}}>
                <div>
                    Meaning of <b>{word}</b> in English
                </div>
                
                
                {meanings.map((meaning, id) => {
                    return <section>
                        <Meaning key={id++} {...meaning}>
                        </Meaning>
                    </section>
                })}
                <div className={"row_bar"}></div>
            </div>
        </section>
    )
}

Words.propTypes = {
    word: PropTypes.string.isRequired,
    meanings : PropTypes.arrayOf(PropTypes.shape({
        partOfSpeech: PropTypes.string.isRequired,
        definitions: PropTypes.arrayOf(PropTypes.shape({
            definition:PropTypes.string.isRequired,
            example: PropTypes.string,
            synonyms: PropTypes.arrayOf(PropTypes.string)
        }))
    })).isRequired,
    phonetics: PropTypes.arrayOf(PropTypes.shape({
        text:PropTypes.string.isRequired,
        audio: PropTypes.string
    }).isRequired)
}

export default Words
