# Plotting Our React Blocks (Optional)
Using what we've learned about styles, let's recreate the famous "Plotting your Blocks" assignment from Web Fundamentals this time using React Components.

![Blocks](image.png)


We can consider writing something like this where `Header`, `Navigation`, `Main`, `SubContents`, and `Advertisement` are all components we will need to import into the App.js and the Main component can display `{props.children}`.


```
import React from 'react';
import './App.css';
import Header from './Components/Header';
import Navigation from './Components/Navigation';
import Main from './Components/Main';
import SubContents from './Components/SubContents';
import Advertisement from './Components/Advertisement';
 
                
function App() {
  return (
    <div className="app">
        <Header />
        <Navigation />
        <Main>
            <SubContents />
            <SubContents />
            <SubContents />
            <Advertisement />
        </Main>
    </div>
  );
}
                
export default App;
```

## Requirements:
- Create and style the wireframe using to provided components and colors