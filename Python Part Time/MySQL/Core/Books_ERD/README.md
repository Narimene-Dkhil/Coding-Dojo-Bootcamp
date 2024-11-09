# Assignment: Books
**Learning Objectives:**

- Students will design an ERD using many-to-many relationships.

Imagine that you're a developer for an online book retailer, and you need to create an ERD to represent the database for their web application. The application will contain books, users, and the favorite books that each user recommends.



**Your Task:** Create an ERD to represent the database for an application that tracks users, books, and user's favorite books.

Each book should have an id, title, and each user should be able to save their favorite books. Use the MySQL Workbench for creating this database.

## Requirements:

- Create a new model (ERD)
- Name the schema books_schema
- Create a table called users
- Add the fields to the users table including: id, name, created_at and updated_at
- Create a table called books
- Add fields to the books table including: id, title, num_of_pages, created_at, and updated_at
- Create a many to many relationship between users and books and rename the joining table to favorites
- Change the field names to the singular pronoun. ie. user_id and book_id
- Save your ERD as a .mwb file and submit it to the platform

