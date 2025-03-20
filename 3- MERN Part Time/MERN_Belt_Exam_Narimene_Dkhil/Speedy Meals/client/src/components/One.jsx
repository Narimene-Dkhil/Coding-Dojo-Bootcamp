import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, useParams, useNavigate } from 'react-router-dom';

function One() {

    const { id } = useParams();
    const navigate = useNavigate();
    const [m, setM] = useState({});

    useEffect(() => {
        axios.get('http://localhost:8000/api/meals/' + id + '/details')
            .then(res => setM(res.data))
            .catch(err => console.error(err));
    }, [id]);

    const deleteMeal = (id) => {
        axios.delete('http://localhost:8000/api/meals/delete/' + id)
            .then(res => navigate('/meals'))
            .catch(err => console.error(err));
    };

    return (
        <div className="container mt-5">
            <div className='text-end'>
                <Link to={`/meals`}>back to home</Link>
            </div>
            <br />
            <div className="card">
                <div className='card-header'>
                    <h3>{m.name} recipe</h3>
                    <div className="text-end">
                        <button className="btn btn-danger" onClick={() => deleteMeal(m._id)}>Remove</button>
                    </div>
                </div>
                <div className="card-body">
                    <p className="fw-bold">Cook time {m.minutes} minutes</p>
                    <p className="fw-bold">Ingredients</p>
                    <p>{m.ingredientOne} <br /> {m.ingredientTwo} <br /> {m.ingredientThree}</p>
                    <p className="fw-bold">Directions</p>
                    <p>{m.directions}</p>
                </div>
            </div>
        </div>
    );
}

export default One;
