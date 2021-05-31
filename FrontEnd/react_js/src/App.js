import { BrowserRouter as Router, Switch, Route, BrowserRouter } from 'react-router-dom';

import Navbar from './components/Navbar/Navbar';
import React, { useState } from 'react';
import './App.css';
import Footer from './components/pages/Footer/Footer'
import Home from './components/pages/Home/Home'
import Dictionary from './components/pages/Translate/Dictionary'
import Writing from './components/pages/WritingTask2/Writing'


function App() {

  const [color, setColor] = useState("#f1f5f8");

  const changeColor = (x) =>{
    setColor({x});
  }

  return (
    <div style={{backgroundColor: color}} id="main">
      <BrowserRouter >
        <Navbar></Navbar>
        <Switch>
          <Route path="/" exact component={Home}></Route>
          <Route path="/dictionary" component={Dictionary}></Route>
          <Route path="/writing" component={Writing}></Route>
        </Switch>
        <Footer></Footer>
      </BrowserRouter>
    </div>
  );
}

export default App;
