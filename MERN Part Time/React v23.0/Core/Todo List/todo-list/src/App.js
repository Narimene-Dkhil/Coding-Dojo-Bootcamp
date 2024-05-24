import './App.css';
import React, {useState, useEffect} from 'react';
import MakeList from './components/MakeList';
import RenderTodoList from './components/RenderTodoList';

function App() {
  const [todoArray, setTodoArray] = useState(() => {
    const savedState = localStorage.getItem("stateString");
    const todoArray = JSON.parse(savedState);
    return todoArray || [];
  });
  useEffect(() => {
    localStorage.setItem("stateString", JSON.stringify(todoArray));
  }, [todoArray]);
  return (
    <div className="App">
      <MakeList todoArray = {todoArray} setTodoArray = {setTodoArray}/>
      <RenderTodoList todoArray = {todoArray} setTodoArray = {setTodoArray} />
    </div>
  );
}

export default App;