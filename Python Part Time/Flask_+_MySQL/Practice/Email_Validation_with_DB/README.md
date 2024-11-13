# Assignment: Email Validation with DB
**Learning Objectives:**

- Build appropriate control structures (if statements) to validate user input before adding it to the database.
- Implement pattern validation using regex.
- Add flash messages to your application, with considerations for user experience.
- Successfully redirect the user after going to a POST route.
- Be able to explain the benefits and drawbacks of front-end validations vs. back-end validations.

### Let's add validations to the Users assignment!
Assignment: Add validations to your User assignment on create only. Include email pattern validation.

![Validations](validations.png)

Example click-though:

![Email](email.gif)

## Requirements:
- Add the following to your Users assignment: a validator method to your user class that takes in input data as a dictionary, adds flash messages and returns true or false.
- Validate that there are no fields left blank
- Validate that the email is in the correct format
- Be sure to add messages to flash if there are any errors.
- Handle the following logic in your controller: If invalid, send the user back to the create page and show the error messages in the page. If valid, carry on creating the new user and redirect to the dashboard.
- NINJA Bonus: Also validate that the email being added is unique
- NINJA Bonus: Make it so the data the user input isn't lost when they have an error, so they do not have to start from scratch any time they make a mistake! HINT: How do you persist data temporarily from route to route?


