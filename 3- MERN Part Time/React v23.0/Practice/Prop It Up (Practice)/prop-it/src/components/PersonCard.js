import React from 'react';

const PersonCard = (props) => {
    const {lastName, firstName, age, hairColor} = props;
    return (
    <div>
        <h1>{lastName}, {firstName}</h1>
        <p>Age: {age}</p>
        <p>Hair Color: {hairColor}</p>
        <br></br>
    </div>
    )
}

export default PersonCard;
