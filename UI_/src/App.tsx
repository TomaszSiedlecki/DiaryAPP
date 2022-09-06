import React from 'react';
import logo from './logo.svg';
import './App.css';
import Login from './components/login/login';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import About from './components/about/about';
import Grades from './components/grades/grades';
import Logout from './components/logout/logout';
import Navigation from './components/navigation/navigation';
import GuardedRoutes from './utils/guardedRoute';
const App = () => {
  return (
    <div className={'root'}>
      <Navigation></Navigation>
      <BrowserRouter>
        <Routes>
          <Route element={<GuardedRoutes/>}>
            <Route path="/About" element={<About/>}/>
            <Route path="/Grades" element={<Grades/>}/>
            <Route path="/Logout" element={<Logout/>}/>
          </Route>
          <Route path="/Login" element={<Login/>}  />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
