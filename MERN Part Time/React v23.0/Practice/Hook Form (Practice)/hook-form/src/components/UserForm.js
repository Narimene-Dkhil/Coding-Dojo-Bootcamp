import React from 'react';

const UserForm = ({ user, setUser }) => {

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUser({...user, [name]: value,});
    };

    return (
        <form>
            <div>
                <label>First Name: </label>
                <input
                    type="text"
                    name="firstName"
                    value={user.firstName}
                    onChange={handleChange}
                />
            </div>
            <div>
                <label>Last Name: </label>
                <input
                    type="text"
                    name="lastName"
                    value={user.lastName}
                    onChange={handleChange}
                />
            </div>
            <div>
                <label>Email: </label>
                <input
                    type="email"
                    name="email"
                    value={user.email}
                    onChange={handleChange}
                />
            </div>
            <div>
                <label>Password: </label>
                <input
                    type="password"
                    name="password"
                    value={user.password}
                    onChange={handleChange}
                />
            </div>
            <div>
                <label>Confirm Password: </label>
                <input
                    type="password"
                    name="confirmPassword"
                    value={user.confirmPassword}
                    onChange={handleChange}
                />
            </div>
        </form>
    );
};

export default UserForm;
