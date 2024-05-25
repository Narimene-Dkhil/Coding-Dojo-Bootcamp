import React, { useReducer } from 'react';
import '../styles.css';

// Initial state
const initialState = {
    firstName: {
        value: '',
        error: null
    },
    lastName: {
        value: '',
        error: null
    },
    email: {
        value: '',
        error: null
    }
};

// Reducer function
function formReducer(state, action) {
    switch (action.type) {
        case 'SET_FIELD_VALUE':
            return {
                ...state,
                [action.field]: {
                    ...state[action.field],
                    value: action.value,
                    error: validateField(action.field, action.value)
                }
            };
        default:
            return state;
    }
}

// Validation function
function validateField(field, value) {
    switch (field) {
        case 'firstName':
            return value.length < 2 ? 'First name must be at least 2 characters' : null;
        case 'lastName':
            return value.length < 2 ? 'Last name must be at least 2 characters' : null;
        case 'email':
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            return !emailRegex.test(value) ? 'Invalid email address' : null;
        default:
            return null;
    }
}

// Form component
function Form() {
    const [state, dispatch] = useReducer(formReducer, initialState);

    const handleChange = (e) => {
        const { name, value } = e.target;
        dispatch({ type: 'SET_FIELD_VALUE', field: name, value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        // You can add additional form submission logic here
        console.log('Form submitted with:', state);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>
                    First Name:
                    <input
                        type="text"
                        name="firstName"
                        value={state.firstName.value}
                        onChange={handleChange}
                    />
                </label>
                {state.firstName.error && (
                    <p className="error">{state.firstName.error}</p>
                )}
            </div>
            <div>
                <label>
                    Last Name:
                    <input
                        type="text"
                        name="lastName"
                        value={state.lastName.value}
                        onChange={handleChange}
                    />
                </label>
                {state.lastName.error && (
                    <p className="error">{state.lastName.error}</p>
                )}
            </div>
            <div>
                <label>
                    Email:
                    <input
                        type="email"
                        name="email"
                        value={state.email.value}
                        onChange={handleChange}
                    />
                </label>
                {state.email.error && (
                    <p className="error">{state.email.error}</p>
                )}
            </div>
            <button type="submit">Submit</button>
        </form>
    );
}

export default Form;
