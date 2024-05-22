import './App.css';
import PersonCard from './components/PersonCard';

function App() {
  return (
    <div className="App">
      <PersonCard firstName="Jane" lastName="Doe" initialAge={45} hairColor="Black" />
      <PersonCard firstName="John" lastName="Smith" initialAge={88} hairColor="Brown" />
      <PersonCard firstName="Millard" lastName="Fillmore" initialAge={50} hairColor="Brown" />
      <PersonCard firstName="Maria" lastName="Smith" initialAge={62} hairColor="Brown" />
    </div>
  );
}

export default App; 