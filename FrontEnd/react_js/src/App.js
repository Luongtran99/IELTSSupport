import { BrowserRouter as Router, Switch, Route, BrowserRouter } from 'react-router-dom';

import Navbar from './components/Navbar/Navbar';
import React, { useState } from 'react';
import './App.css';
import Footer from './components/pages/Footer/Footer'
import Home from './components/pages/Home/Home'
import Dictionary from './components/pages/Translate/Dictionary'
import Writing from './components/pages/WritingTask2/Writing'
import SignIn from './components/pages/SignIn/SignIn'
import SignUp from './components/pages/SignUp/SignUp'
import Forum from './components/pages/Forum/Forum'
import AuthRoute from './components/AuthRoute/AuthRoute'
import Profile from './components/pages/profile/ProfileUser'
import EditProfile from './components/pages/EditProfile/EditProfile'
import EditPassword from './components/pages/EditProfile/EditPassword/EditPassword'
import Essays from './components/Essays';

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
          <Route path="/signin" component={SignIn}></Route>
          <Route path="/signup" component={SignUp}></Route>
          <Route path="/forum" component={Forum}></Route>
          <Route path="/profile" component={Profile}></Route>
          <Route path="/editprofile" component={EditProfile}></Route>
          <Route path="/account/editpassword" component={EditPassword}></Route>
          <Route path="/editprofile" component={EditProfile}></Route>
          <Route path="/essay/:id">
            <Essays></Essays>
          </Route>
          <AuthRoute path="/home" ></AuthRoute>
        </Switch>
        <Footer></Footer>
      </BrowserRouter>
    </div>
  );
}

export default App;
