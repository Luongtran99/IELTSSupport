import { BrowserRouter as Router, Switch, Route, BrowserRouter } from 'react-router-dom';
import Navbar from './components/Navbar/Navbar';
import React from 'react';
import './App.css';
import Footer from './components/pages/Footer/Footer'
import Home from './components/pages/Home/Home'
import Translate from './components/pages/Translate/Translate'

function App() {
  return (
    <>
      <BrowserRouter>
        <Navbar></Navbar>
        <Switch>
          <Route path="/" exact component={Home}></Route>
          <Route path="/translate" component={Translate}></Route>
        </Switch>
        <Footer></Footer>
      </BrowserRouter>
    </>
  );
}

export default App;
