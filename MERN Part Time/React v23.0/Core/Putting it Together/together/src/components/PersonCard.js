import React, {useState} from 'react'; 

const PersonCard = (props) => {
    const {lastName, firstName, age, hairColor} = props;

    const [count, setCount] = useState (age);

    const handleClick = () => {
        setCount(count + 1);
    }

    return (
    <div>
        <h1>{lastName}, {firstName}</h1>
        <p>Age: {count}</p>
        <p>Hair Color: {hairColor}</p>
        <button onClick={handleClick}>Birthday button for {firstName} {lastName}</button>
        <br></br>
    </div>
    )
}

export default PersonCard;