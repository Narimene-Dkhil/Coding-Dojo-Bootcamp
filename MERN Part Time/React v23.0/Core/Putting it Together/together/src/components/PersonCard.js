import React, {useState} from 'react';

const PersonCard = (props) => {
    const {lastName, firstName, initialAge, hairColor} = props;

    const [age, setAge] = useState(initialAge);

    const handleBirthday = () => {
        setAge(age + 1);
    };

    
    return (
    <div>
        <h1>{lastName}, {firstName}</h1>
        <p>Age: {age}</p>
        <p>Hair Color: {hairColor}</p>
        <button onClick={handleBirthday}>Birthday Button for {firstName} {lastName}</button>
        <br></br>
    </div>
    )
}

export default PersonCard; 