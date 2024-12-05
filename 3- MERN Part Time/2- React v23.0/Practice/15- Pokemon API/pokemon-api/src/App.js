import React, { useState } from "react";
import './App.css';

function App() {
  const [pokemonList, setPokemonList] = useState([]);

  const fetchPokemon = () => {
    fetch("https://pokeapi.co/api/v2/pokemon?limit=1010")
      .then(response => {
        // not the actual JSON response body but the entire HTTP response
        return response.json();
      })
      .then(response => {
        // we now run another promise to parse the HTTP response into usable JSON
        // console.log(response.results);
        setPokemonList(response.results);
      })
      .catch(err => {
        console.log(err);
      });
  };

  return (
    <div className="App">
      <button onClick={fetchPokemon}>Fetch Pokemon</button>
      {pokemonList.map((list, index) => {
        return (
          <p key={index}>{list.name}</p>
        );
      })}
    </div>
  );
}

export default App;
