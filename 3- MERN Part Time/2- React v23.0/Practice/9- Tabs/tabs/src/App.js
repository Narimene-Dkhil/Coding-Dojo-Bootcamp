import './App.css';
import React, {useState} from 'react';
import Tabs from './components/Tabs';

function App() {
  const[tabArray, setTabArray] = useState([
    {label: "Tab 1", content: "Tab 1 content"},
    {label: "Tab 2", content: "Tab 2 content"},
    {label: "Tab 3", content: "Tab 3 content"}]);

  const[tabIndex, setTabIndex] = useState(0);

  return (
    <div className="App">
      <Tabs tabArray = {tabArray} setTabArray={setTabArray} tabIndex={tabIndex} setTabIndex={setTabIndex}/>
    </div>
  );
}

export default App;