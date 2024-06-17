import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate, Link } from 'react-router-dom';

function Add() {

    const navigate = useNavigate()
    const [name, setName] = useState("")
    const [errors, setErrors] = useState([])

    const onSubmitHandler = (e) => {
        e.preventDefault()
        axios.post('http://localhost:8000/api/authors/new', { name })
            .then(res => navigate("/authors"))
            .catch(err => {
                const errorResponse = err.response.data.errors
                const errorArr = []
                for (const key of Object.keys(errorResponse)) {
                    errorArr.push(errorResponse[key].message)
                }
                setErrors(errorArr)
            })
    }

    return (
        <div className="container mt-5">
            <h1>Favorite authors</h1>
            <Link to={`/authors`}>Home</Link>
            <h3>Add a new author</h3>
            <form onSubmit={(e) => onSubmitHandler(e)}>
                <div className="mb-3">
                    <label htmlFor="name" className="form-label">Name</label>
                    <input type="text" className="form-control" id="name" value={name} onChange={(e) => setName(e.target.value)} />
                </div>
                <div className="mb-3">
                    {errors.map((err, index) => (
                        <p key={index} className='text-danger'>{err}</p>
                    ))}
                </div>
                <div className="mb-3">
                    <button className='btn btn-secondary' onClick={() => navigate(`/authors`)}>Cancel</button>
                    <button className="btn btn-primary">Submit</button>
                </div>
            </form>
        </div>
    );
}

export default Add;