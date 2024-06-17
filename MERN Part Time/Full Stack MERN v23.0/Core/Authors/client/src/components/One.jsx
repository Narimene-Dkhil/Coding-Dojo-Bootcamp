import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, Link } from 'react-router-dom';

function One() {
    const { id } = useParams();
    const [author, setAuthor] = useState({});
    const [error, setError] = useState("");

    useEffect(() => {
        axios.get("http://localhost:8000/api/authors/" + id)
            .then(res => {
                if(res.data) {
                    setAuthor(res.data);
                } else {
                    setError("We're sorry, but we could not find the author you are looking for. Would you like to add this author to our database?");
                }
            })
            .catch(err => {
                setError("We're sorry, but we could not find the author you are looking for. Would you like to add this author to our database?");
            })
    }, [id])

    if(error) {
        return (
            <div className="container mt-5">
                <h1>Error</h1>
                <p>{error}</p>
                <Link to="/authors/new">Add this author</Link>
            </div>
        );
    }

    return (
        <div className="container mt-5">
            <h1>Favorite author</h1>
            <Link to={`/authors`}>Home</Link>
            <div className="card">
                <div className="card-body">
                    {author.name ? (
                        <h3>{author.name}</h3>
                    ) : (
                        <p>Loading...</p>
                    )}
                </div>
            </div>
        </div>
    );
}

export default One;
