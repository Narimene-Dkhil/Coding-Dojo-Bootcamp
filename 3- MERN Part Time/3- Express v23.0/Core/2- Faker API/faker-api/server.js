const express = require("express");
const app = express();
const port = 8000;

// we can create a function to return a random / fake "Product"
const { faker } = require('@faker-js/faker');

const createUser = () => {
    const newFakeUser = {
        _id: faker.string.uuid(),
        firstName: faker.person.firstName(),
        lastName: faker.person.lastName(),
        email: faker.internet.email(),
        password: faker.internet.password(),
        phoneNumber: faker.phone.number()
    };
    return newFakeUser;
};

const createCompany = () => {
    const newFakeCompany = {
        _id: faker.string.uuid(),
        name: faker.company.name(),
        address: {
            street: faker.location.streetAddress(),
            city: faker.location.city(),
            state: faker.location.state(),
            zipCode: faker.location.zipCode(),
            country: faker.location.country()
        }
    };
    return newFakeCompany;
};

const newCompany = createCompany();
console.log(newCompany);

const newUser = createUser();
console.log(newUser);

app.get("/api/users/new", (req, res) => {
    res.json(newUser);
}); 

app.get("/api/companies/new", (req, res) => {
    res.json(newCompany);
});

app.get("/api/user/company", (req, res) => {
    res.json([newUser, newCompany]);
});


// Route to provide information about available endpoints
// app.get('/api', (req, res) => {
//     res.json({
//         message: "Welcome to the Faker API!",
//         endpoints: {
//             newUser: "/api/users/new",
//             newCompany: "/api/companies/new",
//             newUserAndCompany: "/api/user/company"
//         }
//     });
// });


// this needs to be below the other code blocks
app.listen(port, () => console.log(`Listening on port: ${port}`));

//Testing the API routes:

//http://localhost:8000/api/users/new
//http://localhost:8000/api/companies/new
//http://localhost:8000/api/user/company