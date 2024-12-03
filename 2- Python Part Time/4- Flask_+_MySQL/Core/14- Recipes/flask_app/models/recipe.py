from flask_app.config.mysqlconnection import connectToMySQL, DB
from flask import flash, request, session
from flask_app.models.user import User

import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

from flask import flash

class Recipe:
    def __init__(self, data):
        self.id = data["id"]
        self.name = data["name"]
        self.description = data["description"]
        self.instruction = data["instruction"]
        self.under_cook = data["under_cook"]
        self.created_at = data["created_at"]
        self.updated_at = data["updated_at"]
        
        self.user = None
        
    @classmethod 
    def create(cls , data):
        query = "INSERT INTO recipes (name, description, instruction, under_cook, user_id) VALUES(%(name)s,%(description)s,%(instruction)s,%(under_cook)s,%(user_id)s);"
        result = connectToMySQL(DB).query_db(query , data)
        return result 

    
    @classmethod
    def update(cls, data):
        query = "UPDATE recipes SET name = %(name)s, description= %(description)s, instruction=%(instruction)s, under_cook=%(under_cook)s WHERE id = %(id)s;"
        result = connectToMySQL(DB).query_db(query, data)
        return result
    
    
    @classmethod 
    def delete(cls, data):
        query = "DELETE FROM recipes WHERE id = %(id)s;"
        result = connectToMySQL(DB).query_db(query , data)
        return result
    
    @classmethod
    def get_by_id(cls , data):
        query = "SELECT * FROM recipes JOIN users ON recipes.user_id = users.id WHERE recipes.id = %(id)s;"
        result = connectToMySQL(DB).query_db(query , data)

        recipe = None
        if result:
            recipe = cls(result[0])
            user_data = {
                'id': result[0]['users.id'],
                'first_name': result[0]['first_name'],
                'last_name': result[0]['last_name'],
                'email': result[0]['email'],
                'password': result[0]['password'],
                'created_at': result[0]['users.created_at'],
                'updated_at': result[0]['users.updated_at']
            }
            recipe.user = User(user_data)
        return recipe
    
    @classmethod
    def get_all(cls):
        query = "SELECT * FROM recipes JOIN users ON recipes.user_id = users.id"
        results = connectToMySQL(DB).query_db(query)
        recipes = []
        if results:
            for row in results:
                recipe = cls(row)
                user_data = {
                    'id': row['users.id'],
                    'first_name': row['first_name'],
                    'last_name': row['last_name'],
                    'email': row['email'],
                    'password': row['password'],
                    'created_at': row['users.created_at'],
                    'updated_at': row['users.updated_at']
                }
                recipe.user = User(user_data)
                recipes.append(recipe)
        return recipes
    
    
    @staticmethod
    def validate_create(recipe):
        is_valid = True
        query = "SELECT * FROM recipes WHERE id = %(id)s"
        results = connectToMySQL(DB).query_db(query,recipe)
        if len(recipe['name']) < 3:
            flash("Invalid name, must be at least 3 characters","create")
            is_valid = False
        if len(recipe['description']) < 3:
            flash("Invalid description, must be at least 3 characters","create")
            is_valid = False
        if len(recipe['instruction']) < 3:
            flash("Invalid instruction, must be at least 3 characters","create")
            is_valid = False
        return is_valid
    
    
    @staticmethod
    def validate_update(recipe):
        is_valid = True
        query = "SELECT * FROM recipes WHERE id = %(id)s"
        results = connectToMySQL(DB).query_db(query,recipe)
        if len(recipe['name']) < 3:
            flash("Invalid name, must be at least 3 characters","create")
            is_valid = False
        if len(recipe['description']) < 3:
            flash("Invalid description, must be at least 3 characters","create")
            is_valid = False
        if len(recipe['instruction']) < 3:
            flash("Invalid instruction, must be at least 3 characters","create")
            is_valid = False
        return is_valid