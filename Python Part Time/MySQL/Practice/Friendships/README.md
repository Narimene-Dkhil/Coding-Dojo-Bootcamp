# Assignment: Friendships
**Learning Objectives:**

- Students will design ERDs using self joins.

Imagine that you're a developer working at a social media startup, and you've been asked to create an ERD containing different users, and keeping track of their "friends" on the platform.



**Your Task:** Create an ERD to represent the database for an application that tracks users and their friends.

Each user should have an id, first_name, last_name, created_at and updated_at. Create a self join relationship (many to many to same table), where a user can have a friend (another user from the same table). Use the MySQL Workbench for creating this diagram.

## Requirements:

- Create a new model (ERD)
- Name the schema friendships_schema
- Create a table called users and add the following fields: id, first_name, last_name, created_at and updated_at
- Create a many to many relationship to the users table and rename it friendships
- Add the following fields into the friendship table: id, created_at and updated_at
- Rename the relationship fields to user_id and friend_id
- Save your ERD as a .mwb file and submit it to the platform