import React, {useState,useEffect} from 'react'
import {data} from './data';
import './Forum.css';
import Essay from './Essays/Essay'
import Pagination from './Pagination/Pagination';
import axios from 'axios'
import { Link } from 'react-router-dom';

const url = "https://localhost:44391/api/essay/essays";

const Forum = () =>{

    const [guest, setGuest] = useState(true);
    const [essays,setEssays] = useState([]);
    const [loading, setLoading] = useState(false);
    const [a, setA] = useState([]);
    useEffect(() => {
        const fetchEssays = async () =>{
            setLoading(true);
            // connect url her
            // var myHeader = new Headers();
            // myHeader.append("Content-Type", "application/json");
            // var requestOptions = {
            //     method:"GET",
            //     headers:myHeader,
            //     redirect:"follow"
            // };
            // await fetch("https://localhost:44391/api/essay/essays/1", requestOptions)
            // .then(response => response.json())
            // .then(result => {console.log(result)})
            // .catch(error => console.log("error"))
            const res = await axios.get('https://localhost:44391/api/essay/essays/1');
            setA(res.data.essays);
            console.log(a);
            
            setEssays(res.data);
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

    const [query, setQuery] = useState('');
    const [filteredData, setFilteredData] = useState([]);
    const [buf, setBuf] = useState([]);
    
    const handleInputChange = (e, ) =>{
        const query = e;
        setBuf(a.filter((val) => {
            if(query == ""){
                return val
            }
            else if(val.topic.toLowerCase().includes(e.toLowerCase())){
                return val
            }
        }))
        setFilteredData(buf);
    }


    const paginate = (pageNumber) =>{
        setCurrentPage(pageNumber);
    }

    //
    const indexOfLastEssays = currentPage * pageSize;
    const indexOfFirstEssays = indexOfLastEssays - pageSize;
    const currentEssay = a.slice(indexOfFirstEssays, indexOfLastEssays);

    return <>
        <div style={{height:"100%", minHeight:"650px", width:"100%", backgroundColor:"#fff"}}>
            <div style={{display:"flex",padding:"50px 70px", minHeight:"650px"}}>

                <div style={{width:"30%", textAlign:"center"}}>
                    <div style={{height:"60px", fontSize:"2rem", fontFamily:"SegoeUI, sans"}}>
                        Total Essays Found: <span style={{color:"red"}}>{a.length}</span>
                    </div>
                    <div style={{height:"60px", fontSize:"1.5rem", fontFamily:"SegoeUI, sans"}}>
                        Online User: <span style={{color:"red"}}>{a.length}</span>
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
                    <div style={{textAlign:"start", marginLeft:"4rem", boxSizing:"border-box"}}>
                        <div>
                            <span style={{color:"#000", fontSize:"2rem"}}>Search:</span>
                        </div>
                        <div className="searchForm">
                            <div style={{display:"flex", justifyContent:"center"}}>
                                <i class="fa fa-search fa-2x" style={{display:"flex", justifyContent:"center", alignItems:"center", outline:"none"}}aria-hidden="true"></i>
                                <form>
                                    <input style={{height:"40px", width:"200px", marginLeft:"5px",paddingLeft:"5px", borderRadius:"20px"}}
                                        placeholder="Search for..."
                                        onChange={(event) => {
                                            setQuery(event.target.value);
                                            handleInputChange(event.target.value);
                                        }}
                                        onMouseOut={() => setFilteredData(buf)}
                                    />
                                </form>
                            </div>
                            <div style={{display:"flex", alignItems:"center", justifyContent:"center", flexDirection:"column"}}>{filteredData.map(i => { 
                                var hrf = '/essay/' + i.id; 
                                return <div>
                                    <Link to={hrf}>
                                        {i.topic}
                                    </Link>
                                </div> })}</div>
                        </div>
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
                    <Pagination pageSize={10} totalEssays={essays.noOfEssays} paginate={paginate}></Pagination>
                </div>
                
            </div>
        </div>
    </>
}
export default Forum; 