import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate, Link } from 'react-router-dom';

function Add() {

    const navigate = useNavigate()

    const [name, setName] = useState("")
    const [minutes, setMinutes] = useState(2)
    const [directions, setDirections] = useState("")
    const [ingredientOne, setIngredientOne] = useState("")
    const [ingredientTwo, setIngredientTwo] = useState("")
    const [ingredientThree, setIngredientThree] = useState("")

    const [errors, setErrors] = useState([])

    const onSubmitHandler = (e) => {
        e.preventDefault()
        axios.post('http://localhost:8000/api/meals/new', { name, minutes, directions, ingredientOne, ingredientTwo, ingredientThree })
            .then(res => navigate("/meals"))
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
            <div className='text-end'>
                <Link to={`/meals`}>back to home</Link>
            </div>
            <div>
                <h3>Add the next culinary masterpiece!</h3>
            </div>

            <form onSubmit={(e) => onSubmitHandler(e)}>

                <div className="mb-3">
                    {errors.map((err, index) => (
                        <p key={index} className='text-danger'>{err}</p>
                    ))}
                </div>

                <div className="row">
                    <div className="col-md-6">
                        <div className="mb-3">
                            <label htmlFor="name" className="form-label">Dish Name</label>
                            <input type="text" className="form-control" id="name" value={name} onChange={(e) => setName(e.target.value)} />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="minutes" className="form-label">Total Minutes</label>
                            <input type="number" className="form-control" id="minutes" value={minutes} onChange={(e) => setMinutes(e.target.value)} />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="directions" className="form-label">Directions</label>
                            <input type="text" className="form-control" id="directions" value={directions} onChange={(e) => setDirections(e.target.value)} />
                        </div>
                    </div>
                    <div className="col-md-6">
                        <h4>Ingredient(s) - Optional</h4>
                        <div className="mb-3">
                            <label htmlFor="ingredientOne" className="form-label">Ingredient One</label>
                            <input type="text" className="form-control" id="ingredientOne" value={ingredientOne} onChange={(e) => setIngredientOne(e.target.value)} />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="ingredientTwo" className="form-label">Ingredient Two</label>
                            <input type="text" className="form-control" id="ingredientTwo" value={ingredientTwo} onChange={(e) => setIngredientTwo(e.target.value)} />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="ingredientThree" className="form-label">Ingredient Three</label>
                            <input type="text" className="form-control" id="ingredientThree" value={ingredientThree} onChange={(e) => setIngredientThree(e.target.value)} />
                        </div>
                    </div>
                </div>
                <div className="mb-3">
                    <button className="btn btn-primary">CREATE</button>
                </div>
            </form>
        </div>
    );
}

export default Add;