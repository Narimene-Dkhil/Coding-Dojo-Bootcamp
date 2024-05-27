import React, { useState } from "react";
import axios from 'axios';
import './App.css';

function App() {
  const [pokemonList, setPokemonList] = useState([]);

  const fetchPokemon = () => {
    axios.get("https://pokeapi.co/api/v2/pokemon?limit=1010")
      .then(response => {
        // set the Pokemon list with the response data
        setPokemonList(response.data.results);
      })
      .catch(err => {
        console.error('Error fetching Pokémon:', err);
      });
  };

  return (
    <div className="App">
      <button onClick={fetchPokemon}>Fetch Pokemon</button>
      {pokemonList.map((pokemon, index) => (
        <p key={index}>{pokemon.name}</p>
      ))}
    </div>
  );
}

export default App;
