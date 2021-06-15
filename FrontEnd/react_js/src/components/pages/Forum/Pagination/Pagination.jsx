import React from 'react'
import './Pagination.css'
function Pagination({pageSize, totalEssays, paginate}) {

    const pageNumers = [];

    for(let i = 1; i <= Math.ceil(totalEssays/pageSize); i++){
        pageNumers.push(i);
    }

    return (
        <nav style={{display:"flex", justifyContent:"center"}}>
            <ul className="pagination justify-content-center">
                <li></li>
                {pageNumers.map(number => {
                    return <li key={number} className="page-item">
                        <a onClick={() => {
                            paginate(number)
                        }} href='#' className="page-link">
                            {number}
                        </a>
                    </li>
                })}
                <li></li>
            </ul>
        </nav>
    )
}

export default Pagination
