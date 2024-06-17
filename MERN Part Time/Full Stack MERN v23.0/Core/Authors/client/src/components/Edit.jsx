import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate, useParams , Link} from 'react-router-dom';

function Edit() {
    const navigate = useNavigate()
    const { id } = useParams()
    const [name, setName] = useState("")
    const [errors, setErrors] = useState([])

    useEffect(() => {
        axios.get('http://localhost:8000/api/authors/' + id)
            .then(res => {
                setName(res.data.name)
            })
            .catch(err => {
                console.error(err)
            })
    }, [id])

    const onSubmitHandler = (e) => {
        e.preventDefault()
        axios.patch('http://localhost:8000/api/authors/' + id + '/edit/', { name })
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
            <h3>Edit this author</h3>
            <form onSubmit={(e) => onSubmitHandler(e)}>
                <div className="mb-3">
                    <label htmlFor="name" className="form-label">Name:</label>
                    <input type="text" className="form-control" id="name" name="name" value={name} onChange={(e) => setName(e.target.value)} />
                </div>
                <div className="mb-3">
                    {errors.map((err, index) => (
                        <p key={index} className="text-danger">{err}</p>
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

export default Edit;