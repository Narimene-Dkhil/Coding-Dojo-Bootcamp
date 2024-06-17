import './App.css';
import { Routes, Route } from 'react-router-dom';
import List from './components/List';
import Add from './components/Add';
import Edit from './components/Edit';
import One from './components/One';


function App() {
  return (
    <>
      <Routes>
        <Route path="/authors" element={<List/>} />
        <Route path="/authors/new" element={<Add/>} />
        <Route path="/authors/:id/edit" element={<Edit/>} />
        <Route path="/authors/:id" element={<One/>} />
      </Routes>
    </>
  );
}

export default App;
