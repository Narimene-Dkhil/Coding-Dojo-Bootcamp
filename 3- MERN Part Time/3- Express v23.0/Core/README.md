# Faker API
In this assignment, we will be using 2 Javascript libraries to create a simple API that generates User and Company objects depending on the requested route. The libraries we will be using are **Express** for the server and **Faker** for the random data generation. The goal is to start broadening our understanding of APIs.

For this assignment, you are tasked with creating User and Company objects

- User Object
    - password
    - email
    - phoneNumber
    - lastName
    - firstName
    - _id
- Company Object
    - _id
    - name
    - address
        - street
        - city
        - state
        - zipCode
        - country

## Faker
The faker library has a ton of methods we can use to populate specific fields with randomly generated data.

[You can find faker's installation instructions here, as well as some basic examples of the library in action](https://github.com/faker-js/faker).

Here is an example of how we can use faker

```
// The import line will look different than what is in Faker's documentation
// because we are working with an express application
const { faker } = require('@faker-js/faker');
// we can create a function to return a random / fake "Product"
const createProduct = () => {
    const newFake = {
        name: faker.commerce.productName(),
        price: "$" + faker.commerce.price(),
        department: faker.commerce.department()
    };
    return newFake;
};
    
const newFakeProduct = createProduct();
console.log(newFakeProduct);
/*
 * The output of the above console log will look like this
 * {
 *   name: 'Anime Figure',
 *   price: '$568.00
 *   department: 'Tools' 
 * }
 */
```

## Requirements:

- Create a new project folder "Faker_API" and with your terminal, navigate into your new folder
- Create a package.json file using the "npm init -y" command in your terminal
- install express and faker
- Create a server.js file
- In your server.js file, import express and bring in faker as shown in the example
- Create 2 functions: createUser, createCompany that return an object with the properties listed above
- Create an api route "/api/users/new" that returns a new user
- Create an api route "/api/companies/new" that returns a new company
- Create an api route "/api/user/company" that returns both a new user and a new company
- Run your server.js file using nodemon
- Using Postman, test your new GET routes