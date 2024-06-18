import './App.css';
import { useState } from 'react';
import Display from './components/Display';

function App() {

  const [tasks, setTasks] = useState([])

  const [oneTask, setOneTask] = useState("")

  const addTask = (e) => {
    e.preventDefault()
    const newObj = { text: oneTask, done: false }
    setTasks([...tasks, newObj])
    setOneTask("")
  }

  const deleteTask = (idx) => {
    setTasks(tasks.filter((t, i) => i !== idx))
  }

  const updateTask = (idx) => {
    const tasksCopy = tasks
    tasksCopy[idx].done = !tasksCopy[idx].done
    setTasks(tasksCopy)
  }


  return (
    <div className="App">
      <form onSubmit={(e) => addTask(e)}>
        <input type="text" onChange={(e) => setOneTask(e.target.value)} value={oneTask} />
        <button>Add</button>
      </form>
      <br />
      <Display tasks={tasks} deleteTask={deleteTask} updateTask={updateTask} />
    </div>
  );
}

export default App;
