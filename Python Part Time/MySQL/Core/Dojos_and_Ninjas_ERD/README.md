# Assignment: Dojos and Ninjas
**Learning Objectives:**

- Students will design an ERD using one-to-many relationships.

**Welcome to another Core assignment!** Some students like to explore the assignments before they're finished reading through the lessons, and that's okay! It can be good for your brain to have a preview of what your future challenges might be. However, before you begin this assignment, it's important that you've first:

- Completed the preceding lesson modules
- Taken the knowledge checks to confirm your understanding
- Viewed lecture material related to the assignment topics
- Completed and submitted your practice assignments

## Now, the Assignment:
Imagine that you're a developer working at Coding Dojo, and you need to create an ERD to represent the database of students and the Dojo location at which they're enrolled.



**Your Task:** Create an ERD to represent the database for an application that tracks dojos, as well as the ninjas that belong to each dojo location.

Each dojo should have an id, name, created_at and updated_at; each ninja should have an id, first_name, last_name, age, created_at, updated_at and belong to a specific dojo. Use the MySQL Workbench for creating this diagram.

## Requirements:

- Create a new model (ERD)
- Name the schema dojos_and_ninjas_schema
- Create a table called dojos
- Add the following fields to the dojos table: id, name, created_at and updated_at
- Create a table called ninjas
- Add the following fields to the ninjas table: id, first_name, last_name, age, created_at, updated_at and create an one to many relationship to the dojos table
- Change the name of the relationship field to the singular pronoun. ie dojo_id
- Save your ERD as a .mwb file and submit it to the platform
