import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate, Link } from 'react-router-dom';

function List() {
    const navigate = useNavigate();
    const [authors, setAuthors] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:8000/api/authors')
            .then(res => setAuthors(res.data))
            .catch(err => console.error(err))
    }, [])

    const deleteAuthor = (id) => {
        axios.delete('http://localhost:8000/api/authors/delete/' + id)
            .then(res => setAuthors(authors.filter(a => a._id !== id)))
            .catch(err => console.error(err))
    }

    return (
        <div className='container mt-5'>
            <h1>Favorite authors</h1>
            <button onClick={() => navigate('/authors/new')} className='btn btn-primary'>Add an author</button>
            <table className='table table-sm table-bordered'>
                <thead>
                    <tr>
                        <th>Author</th>
                        <th>Actions available</th>
                    </tr>
                </thead>
                <tbody>
                    {authors.map(a => (
                        <tr key={a._id}>
                            <td>
                                <Link to={`/authors/${a._id}`}>{a.name}</Link>
                            </td>
                            <td>
                                <button className='btn btn-warning' onClick={() => navigate(`/authors/${a._id}/edit/`)}>Edit</button>
                                <button className='btn btn-danger' onClick={() => deleteAuthor(a._id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default List;