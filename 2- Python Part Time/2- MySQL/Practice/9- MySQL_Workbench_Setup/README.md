# To Do: MySQL Workbench Setup
**Learning Objectives:**

- Using MySQL Workbench, students will forward engineer an ERD to create a MySQL database.
- Students will use MySQLWorkbench to connect to their localhost.
- Students will write and execute SQL INSERT, SELECT, UPDATE and DELETE statements using the database created.

## Querying a Database for a CRUD Application

***CRUD*** stands for ***Create, Read, Update and Delete***. These are the four main ways we interact with a database. If you are dealing with a SQL database, this involves the commands INSERT, SELECT, UPDATE, and DELETE which you've already read about. For this assignment, you will use MySQL workbench to create an ERD model, then forward engineer it to create a database. Next, you will query the database using SQL commands. These are the commands you would use to create a CRUD application, or an application where you can manipulate data stored in a database.

First, create a new ERD model called `names`, that is, change it from the default `my_db`! Create a new diagram for a table also called `names` like below:

![Names](names.png)

Next you will forward engineer your model to create a database. Then go ahead and complete all the CRUD queries, by completing the assignment tasks. To submit, create a text file and copy and paste commands you used to query the database. Upload the text file below.

## Helpful Tips
- Once you've forward engineered your database, and navigated to your local instance, you may not see it in your list of schemas right away. If not, hit the refresh icon, and it should appear. 

![Schemas](schemas.png)

- Whenever you write a query in MySQL workbench, it will execute it on the selected database. The only indication of which database is selected is that it is in bold. In order to execute any queries, be sure you have double-clicked the name of the schema, or database, you want to use. In the example below the "names" database is selected. 

![Image](image.png)

- ***Remember***: It's always okay to look up the syntax for SQL statements whenever you forget. In fact, looking up syntax is very commonplace even for seasoned developers, especially those that don't tend to use SQL every day. The important part is to become familiar with how databases are structured and be able to query a database to fetch and alter the data *you want*.

## Requirements:
- Write the query to select all the names in the database. The columns should appear, even if there are no records in the database yet.
- Insert your own name into the database!
- Insert another name or, NINJA BONUS: insert more than one name in a single statement.
- Optional: Try creating, updating and deleting records using the statements you've learn about.