import React, { useState } from 'react';
import './App.css';
import UserForm from './components/UserForm';

function App() {
  const [user, setUser] = useState({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    confirmPassword: "",
  });

  return (
    <div className="App">
      <UserForm user={user} setUser={setUser} />
    </div>
  );
}

export default App;
