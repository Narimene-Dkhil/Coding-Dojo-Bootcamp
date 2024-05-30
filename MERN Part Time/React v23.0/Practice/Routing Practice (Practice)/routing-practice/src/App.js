import React from "react";
import {BrowserRouter, Routes, Route, Link} from "react-router-dom"
import Home from "./components/Home";
import OtherRoutes from "./components/OtherRoutes";
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <div>
        <Link to={"/home"}>Go Home</Link>
      </div>
      <Routes>
        <Route path="/home" element={<Home/>}/>
        <Route path="/:input" element={<OtherRoutes/>}/>
        <Route path="/:input/:color1/:color2" element={<OtherRoutes/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;