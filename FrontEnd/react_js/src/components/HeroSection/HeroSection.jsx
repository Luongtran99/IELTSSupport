import React from 'react'
import {useState, useEffect} from 'react'
import PropTypes from 'prop-types'
import './HeroSection.css'
import { Slide } from '@material-ui/core';
import {Button} from '../Navbar/Button/Button'


import img1 from '../../assets/images/img-1.jpg'
import img2 from '../../assets/images/img-2.jpg'
import img3 from '../../assets/images/img-3.jpg'
import img4 from '../../assets/images/img-4.jpg'
import img5 from '../../assets/images/img-5.jpg'

const collection = [
    { src: img1, caption: "Caption one" },
    { src: img2, caption: "Caption two" },
    { src: img3, caption: "Caption three" },
    { src: img4, caption: "Caption four" },
    { src: img5, caption: "Caption five" }
  ];


function HeroSection() {
    
    return (
        // <div>
        //     <Slide input={collection}
        //         ratio={`3:2`}
        //         mode={`automatic`}
        //         timeout={`3000`}></Slide>
        // </div>
        <div className="hero-container">
            <video src=""></video>
            <h1>IMPROVE IELTS EVERY DAY</h1>
            <p>Make your words meaningful</p>
            <div className='hero-btns'>
                <Button
                    className='btns'
                    buttonStyle='btn--outline'
                    buttonSize='btn--large'
                >
                    GET STARTED
                </Button>
                <Button
                    className='btns'
                    buttonStyle='btn--primary'
                    buttonSize='btn--large'
                    onClick={console.log('hey')}
                >
                    WATCH SUPPORT <i className='far fa-play-circle' />
                </Button>
            </div>
        </div>
    )
}

Slide.PropTypes = {
    image: PropTypes.object.isRequired,
    title: PropTypes.string.isRequired
}


export default HeroSection
