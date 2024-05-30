import React from "react";
import {BrowserRouter, Routes, Route} from "react-router-dom"
import Planets from "./components/Planets";
import People from "./components/People";
import Search from "./components/Search";
import Error from "./components/Error";
import './App.css';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <div className="searchBar">
          <Search/>
        </div>
        <Routes>
          <Route path="/people/:index" element={<People/>}/>
          <Route path="/planets/:index" element={<Planets/>}/>
          <Route path="/error" element={<Error/>}/>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;