import React from 'react';

const UserView = ({ user }) => {
    return (
        <div>
            <h3>Your Form Data</h3>
            <p>First Name: {user.firstName}</p>
            <p>Last Name: {user.lastName}</p>
            <p>Email: {user.email}</p>
            <p>Password: {user.password}</p>
            <p>Confirm Password: {user.confirmPassword}</p>
        </div>
    );
};

export default UserView;
