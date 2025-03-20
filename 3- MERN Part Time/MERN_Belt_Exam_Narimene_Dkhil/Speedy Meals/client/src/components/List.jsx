import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

function List() {
    const [meals, setMeals] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:8000/api/meals')
            .then(res => setMeals(res.data))
            .catch(err => console.error(err))
    }, [])


    return (
        <div className='container mt-5'>
            <div className='text-end'>
                <Link to={`/meals/new`}>add a meal</Link>
            </div>
            <div>
                <h3>Find inspiration with these delicious meals!</h3>
            </div>
            <br />
            <table className='table table-sm table-bordered table-striped'>
                <thead>
                    <tr>
                        <th>Meal</th>
                        <th>Prep Time</th>
                        <th>Options</th>
                    </tr>
                </thead>
                <tbody>
                    {meals.map(m => (
                        <tr key={m._id}>
                            <td>{m.name}</td>
                            <td>{m.minutes}</td>
                            <td>
                                <Link to={`/meals/${m._id}/details`}>details</Link> |
                                <Link to={`/meals/${m._id}/edit`}>edit</Link>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default List;