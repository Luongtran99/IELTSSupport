import React from 'react'

function SupportWord({message, from, to}) {
    return (
        <div style={{height:"auto", width:"30rem", background:"white", borderRadius:"5px",boxShadow:"1px 1px 12px rgba(90, 179, 174, 0.753)"}}>
            {message}
        </div>
    )
}

export default SupportWord;