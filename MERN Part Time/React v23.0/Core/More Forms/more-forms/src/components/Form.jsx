import React, { useState } from 'react'

const Form = () => {
    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [hasBeenSubmitted, setHasBeenSubmitted] = useState(false);

    const [firstNameError, setFirstNameError] = useState("");
    const [lastNameError, setLastNameError] = useState("");
    const [emailError, setEmailError] = useState("");
    const [passwordError, setPasswordError] = useState("");


    const handleSubmit = (e) => {
        e.preventDefault()
        if (firstNameError || lastNameError || emailError || passwordError) {
            console.log("Form contains errors, cannot submit");
            return;
        }
        const newUser = { firstName, lastName, email, password, confirmPassword }
        console.log("Welcome", newUser)
        //console.log(firstName, lastName, email, password, confirmPassword)
        setFirstName("");
        setLastName("");
        setEmail("");
        setPassword("");
        setConfirmPassword("");
        setHasBeenSubmitted(true);

    };

    // validations
    const handleFirstName = (e) => {
        setFirstName(e.target.value);
        if (e.target.value.length < 1) {
            setFirstNameError("First Name is required");
        }
        else if (e.target.value.length < 2) {
            setFirstNameError("First Name must be at least 2 characters");
        }
        else {
            setFirstNameError("");
        }
    }
    const handleLastName = (e) => {
        setLastName(e.target.value);
        if (e.target.value.length < 1) {
            setLastNameError("Last Name is required");
        }
        else if (e.target.value.length < 2) {
            setLastNameError("Last Name must be at least 2 characters");
        }
        else {
            setLastNameError("");
        }
    }
    const handleEmail = (e) => {
        setEmail(e.target.value);
        if (e.target.value.length < 1) {
            setEmailError("Email is required");
        }
        else if (e.target.value.length < 5) {
            setEmailError("Email must be at least 5 characters");
        }
        else {
            setEmailError("");
        }
    }
    const handlePassword = (e) => {
        setPassword(e.target.value);
        if (e.target.value.length < 1) {
            setPasswordError("Password is required");
        }
        else if (e.target.value.length < 8) {
            setPasswordError("Password must be at least 8 characters");
        }
        else {
            setPasswordError("");
        };
    };


    return (
        <div>
            <form onSubmit={handleSubmit}>
                {
                    hasBeenSubmitted ?
                        <h3>Thank you for submitting the form!</h3> :
                        <h3>Welcome, please submit the form.</h3>
                }
                <div>
                    {
                        firstNameError ?
                            <p className='validation'>{firstNameError}</p> :
                            ""
                    }
                    <label>First Name</label>
                    <input type="text" value={firstName} onChange={handleFirstName} />
                </div>
                <div>
                    {
                        lastNameError ?
                            <p className='validation'>{lastNameError}</p> :
                            ""
                    }
                    <label>Last Name</label>
                    <input type="text" value={lastName} onChange={handleLastName} />
                </div>
                <div>
                {
                        emailError ?
                        <p className='validation'>{emailError}</p> :
                        ""
                    }
                    <label>Email</label>
                    <input type="text" value={email} onChange={handleEmail} />
                </div>
                <div>
                {
                        passwordError ?
                        <p className='validation'>{passwordError}</p> :
                        ""
                    }
                    {
                        confirmPassword !== password ?
                        <p className='validation'>Passwords must match.</p> :
                        ""
                    }
                    <label>Password</label>
                    <input type="password" value={password} onChange={handlePassword} />
                </div>
                <div>
                    <label>Confirm Password</label>
                    <input type="password" value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} />
                </div>
                <input type="submit" value="Create User" />
            </form>
            <h4>Your Form Data:</h4>
            <div>
                <p><b>First Name:</b> {firstName}</p>
                <p><b>Last Name:</b> {lastName}</p>
                <p><b>Email:</b> {email}</p>
                <p><b>Password:</b> {password}</p>
                <p><b>Confirm Password:</b> {confirmPassword}</p>
            </div>
        </div>
    );
};

export default Form