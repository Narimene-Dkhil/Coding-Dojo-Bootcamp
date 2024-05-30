import React, { useEffect, useState } from 'react'
import axios from "axios";
import { useParams, useNavigate, Link } from "react-router-dom"

const People = () => {
    const [people, setPeople] = useState({});
    const navigate = useNavigate();
    const { index } = useParams();
    const [homeworldName, setHomeworldName] = useState("")
    const [homeworldId, setHomeworldId] = useState(0)


    useEffect(() => {
        axios.get(`https://swapi.dev/api/people/${index}`)
            .then(response => {
                // console.log(response.data)
                setPeople(response.data)
                setHomeworldId(Number(String(response.data.homeworld).replace(/[^0-9]/g, '')))
                axios.get(response.data.homeworld)
                    .then(response => {
                        setHomeworldName(response.data.name)
                    })
                    .catch(err => {
                        console.log(err);
                        navigate("/error");
                    });
            })
            .catch(err => {
                console.log(err);
                navigate("/error");
            });
    }, [index, navigate]);



    return (
        <div>
            <h2>{people.name}</h2>
            <p>Gender: {people.gender}</p>
            <p>Height: {people.height}</p>
            <p>Mass: {people.mass}</p>
            <p>Skin Color: {people.skin_color}</p>
            <p>Hair Color: {people.hair_color}</p>
            <p>Homeworld: <Link to={`/planets/${homeworldId}`}>{homeworldName}</Link></p>
        </div>
    )
}

export default People