import React from 'react'
import PropTypes from "prop-types"

//var url = "http://localhost:44391/api/dictionary/";

const Words = ({word, meanings, phonetics}) => {

    const Definition = ({definition, example, synonyms}) =>{
        return <div>
            <div>
                Definition: {definition}
            </div>
            <div>
                Example: {example}
            </div>
            <div>
                Synonyms: {synonyms.map((synonym) => {
                    return <div>
                            {synonym}
                        </div>
                })}
            </div>
        </div>
    }
    
    const Meaning = 
        ({partOfSpeech, definitions}) => {
            return <div>
                <div >
                    PartOfSpeech: {partOfSpeech}
                </div>
                {definitions.map((defi) => {
                    return <Definition {...defi}>
                        
                    </Definition>
                })}
            </div>
        }
    
    const Phonetic = () =>{

    }

    const convertTo = (event) =>{
        event.preventDefault();
        var newaudio = new Audio('data:audio/ogg;base64,'+phonetics[0].audio);
        newaudio.play();
    }

    return (
        <>
            <div>
                {word}
                {meanings.map((meaning, id) => {
                    return <Meaning key={id++} {...meaning}>
                    </Meaning>
                })}
                <button type="button" onClick={convertTo}>Play</button>
            </div>
        </>
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
