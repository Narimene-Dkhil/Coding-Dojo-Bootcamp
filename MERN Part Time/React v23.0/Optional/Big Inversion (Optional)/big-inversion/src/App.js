import React from 'react';
import './App.css';
import MakeList from './components/MakeList';
import RenderTodoList from './components/RenderTodoList';
import { TodoProvider } from './context/TodoContext'; // Corrected path

function App() {
  return (
    <TodoProvider>
      <div className='App'>
        <MakeList />
        <RenderTodoList />
      </div>
    </TodoProvider>
  );
}

export default App;
