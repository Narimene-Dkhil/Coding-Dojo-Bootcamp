import './App.css';
import { Routes, Route } from 'react-router-dom';
import List from './components/List';
import Add from './components/Add';
import Edit from './components/Edit';
import One from './components/One';


function App() {
  return (
    <>
      <div className="container mt-5">
        <h1>Speedy Meals</h1>
      </div>

      <Routes>
        <Route path="/meals" element={<List />} />
        <Route path="/meals/new" element={<Add />} />
        <Route path="/meals/:id/edit" element={<Edit />} />
        <Route path="/meals/:id/details" element={<One />} />
      </Routes>
    </>
  );
}

export default App;
