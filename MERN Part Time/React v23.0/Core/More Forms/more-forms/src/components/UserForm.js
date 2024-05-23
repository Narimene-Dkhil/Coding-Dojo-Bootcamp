import React, { useState, useEffect } from 'react';

const UserForm = ({ user, setUser }) => {
    const [errors, setErrors] = useState({});
    const [hasBeenSubmitted, setHasBeenSubmitted] = useState(false);

    const createUser = (e) => {
        e.preventDefault();
        setHasBeenSubmitted(true);
    };

    useEffect(() => {
        // Validation
        let newErrors = {};
        if (user.firstName.length < 2) {
            newErrors.firstName = "First Name must be at least 2 characters.";
        }
        if (user.lastName.length < 2) {
            newErrors.lastName = "Last Name must be at least 2 characters.";
        }
        if (user.email.length < 5) {
            newErrors.email = "Email must be at least 5 characters.";
        }
        if (user.password !== user.confirmPassword) {
            newErrors.password = 'Passwords must match.';
            newErrors.confirmPassword = 'Passwords must match.';
        } else if (user.password.length < 8) {
            newErrors.password = 'Password must be at least 8 characters.';
        }
        setErrors(newErrors);
    }, [user]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUser({ ...user, [name]: value });
    };

    return (
        <form onSubmit={createUser}>
            {
                hasBeenSubmitted ?
                    <h3>Thank you for submitting the form!</h3> :
                    <h3>Welcome, please submit the form.</h3>
            }
            <div>
                <label>First Name: </label>
                <input
                    type="text"
                    name="firstName"
                    value={user.firstName}
                    onChange={handleChange}
                />
                {errors.firstName && <p style={{ color: 'red' }}>{errors.firstName}</p>}
            </div>
            <div>
                <label>Last Name: </label>
                <input
                    type="text"
                    name="lastName"
                    value={user.lastName}
                    onChange={handleChange}
                />
                {errors.lastName && <p style={{ color: 'red' }}>{errors.lastName}</p>}
            </div>
            <div>
                <label>Email: </label>
                <input
                    type="email"
                    name="email"
                    value={user.email}
                    onChange={handleChange}
                />
                {errors.email && <p style={{ color: 'red' }}>{errors.email}</p>}
            </div>
            <div>
                <label>Password: </label>
                <input
                    type="password"
                    name="password"
                    value={user.password}
                    onChange={handleChange}
                />
                {errors.password && <p style={{ color: 'red' }}>{errors.password}</p>}
            </div>
            <div>
                <label>Confirm Password: </label>
                <input
                    type="password"
                    name="confirmPassword"
                    value={user.confirmPassword}
                    onChange={handleChange}
                />
                {errors.confirmPassword && <p style={{ color: 'red' }}>{errors.confirmPassword}</p>}
            </div>
            <input type="submit" value="Submit Form" />
        </form>
    );
};

export default UserForm;
