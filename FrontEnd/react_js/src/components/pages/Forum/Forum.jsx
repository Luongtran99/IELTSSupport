import React, {useState,useEffect} from 'react'
import {data} from './data';
import './Forum.css';
import Essay from './Essays/Essay'
import Pagination from './Pagination/Pagination';

const url = "https://localhost:44391/api/essay/essays";

const Forum = () =>{

    const [guest, setGuest] = useState(true);
    const [essays,setEssays] = useState([]);
    const [loading, setLoading] = useState(false);
    

    useEffect(() => {
        const fetchEssays = async () =>{
            setLoading(true);
            // connect url here
            
            setEssays(data.essays);
            setLoading(false);
        }
        fetchEssays();
    }, []);

    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize, setPageSize] = useState(10);

    const [page, setPage] = useState(1);
    const [result, setResult] = useState(data.essays);

    const onPageNext = () => {
        page = page + 1;
    }

    const onPagePrev = () =>{
        page = page - 1;
    }

     const paginate = (pageNumber) =>{
        setCurrentPage(pageNumber);
    }

    //
    const indexOfLastEssays = currentPage * pageSize;
    const indexOfFirstEssays = indexOfLastEssays - pageSize;
    const currentEssay = essays.slice(indexOfFirstEssays, indexOfLastEssays);

    return <>
        <div style={{height:"100%", minHeight:"650px", width:"100%", backgroundColor:"#fff"}}>
            <div style={{display:"flex",padding:"50px 70px", minHeight:"650px"}}>

                <div style={{width:"30%", textAlign:"center"}}>
                    <div style={{height:"60px", fontSize:"2rem", fontFamily:"SegoeUI, sans"}}>
                        Total Essays Found: <span style={{color:"red"}}>{data.essays.length}</span>
                    </div>
                    <div style={{height:"60px", fontSize:"1.5rem", fontFamily:"SegoeUI, sans"}}>
                        Online User: <span style={{color:"red"}}>{data.essays.length}</span>
                    </div>
                    
                    <div style={{textAlign:"start", marginLeft:"4rem", boxSizing:"border-box"}}>
                        <div>
                            <span style={{color:"#000", fontSize:"2rem"}}>Selection:</span>
                        </div>
                        <ul style={{paddingLeft:"70px", fontSize:"1.2rem"}}>
                            <li style={{margin:"5px 0px"}}>
                                <a href="#" style={{color:"#000"}}>All</a>
                            </li>
                            <li style={{margin:"5px 0px"}}>
                                <a href="#">Top Essays</a>
                            </li>
                            <li style={{margin:"5px 0px"}}>
                                <a href="#" >Your old essays...</a>
                                
                            </li>
                        </ul>
                    </div>
                </div>
                
                <hr></hr>
                <div style={{width:"70%", padding:"0px 30px"}}>
                    <h2 style={{textAlign:"center"}}>Essays</h2>
                    <div style={{width:"100%",display:"flex",justifyContent:"center"}}> 
                        {/* <ul style={{marginTop:"20px",width:"100%",maxWidth:"830px"}}>
                            {data.essays.map((essay) =>{
                                return <Essay key={essay.id} {...essay}></Essay>
                            })}
                        </ul> */}
                        <Essay essays={currentEssay} loading={loading}></Essay>
                    </div>
                    <Pagination pageSize={10} totalEssays={data.noOfEssays} paginate={paginate}></Pagination>
                </div>
                
            </div>
        </div>
    </>
}
export default Forum; 