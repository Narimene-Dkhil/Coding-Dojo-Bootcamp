from flask_app.config.mysqlconnection import connectToMySQL, DB
from flask import flash, request, session
from flask_app.models.user import User

import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

from flask import flash

class Wish:
    def __init__(self, data):
        self.id = data["id"]
        self.name = data["name"]
        self.description = data["description"]
        self.granted = data["granted"]
        self.created_at = data["created_at"]
        self.updated_at = data["updated_at"]
        
        if 'user' in data:
            self.user = User(data['user'])
        else:
            self.user = None
        
    @classmethod 
    def create(cls , data):
        query = "INSERT INTO wishes (name, description, granted, user_id) VALUES(%(name)s,%(description)s,%(granted)s,%(user_id)s);"
        result = connectToMySQL(DB).query_db(query , data)
        return result 
    
    @classmethod
    def update(cls, data):
        query = "UPDATE wishes SET name = %(name)s, description= %(description)s, granted=%(granted)s WHERE id = %(id)s;"
        result = connectToMySQL(DB).query_db(query, data)
        return result
    
    @classmethod 
    def delete(cls, data):
        query = "DELETE FROM wishes WHERE id = %(id)s;"
        result = connectToMySQL(DB).query_db(query , data)
        return result
    
    @classmethod
    def get_by_id(cls , data):
        query = "SELECT * FROM wishes JOIN users ON wishes.user_id = users.id WHERE wishes.id = %(id)s;"
        result = connectToMySQL(DB).query_db(query , data)

        wish = None
        if result:
            wish = cls(result[0])
            user_data = {
                'id': result[0]['users.id'],
                'first_name': result[0]['first_name'],
                'last_name': result[0]['last_name'],
                'email': result[0]['email'],
                'password': result[0]['password'],
                'created_at': result[0]['users.created_at'],
                'updated_at': result[0]['users.updated_at']
            }
            wish.user = User(user_data)
        return wish 
    
    @classmethod
    def get_all(cls):
        query = "SELECT * FROM wishes JOIN users ON wishes.user_id = users.id ORDER BY wishes.created_at DESC;"
        results = connectToMySQL(DB).query_db(query)
        wishes = []
        if results:
            for row in results:
                wish = cls(row)
                user_data = {
                    'id': row['users.id'],
                    'first_name': row['first_name'],
                    'last_name': row['last_name'],
                    'email': row['email'],
                    'password': row['password'],
                    'created_at': row['users.created_at'],
                    'updated_at': row['users.updated_at']
                }
                wish.user = User(user_data)
                wishes.append(wish)
        return wishes 
    
    @staticmethod
    def validate_create(wish):
        is_valid = True
        query = "SELECT * FROM wishes WHERE id = %(id)s"
        results = connectToMySQL(DB).query_db(query,wish)
        if len(wish['name']) < 3:
            flash("Invalid name, must be at least 3 characters","create")
            is_valid = False
        if len(wish['description']) < 3:
            flash("Invalid description, must be at least 3 characters","create")
            is_valid = False
        return is_valid
    
    @staticmethod
    def validate_update(wish):
        is_valid = True
        query = "SELECT * FROM wishes WHERE id = %(id)s"
        results = connectToMySQL(DB).query_db(query,wish)
        if len(wish['name']) < 3:
            flash("Invalid name, must be at least 3 characters","create")
            is_valid = False
        if len(wish['description']) < 3:
            flash("Invalid description, must be at least 3 characters","create")
            is_valid = False
        return is_valid
    
    
    @classmethod
    def get_ungranted(cls, user_id):
        query = "SELECT * FROM wishes JOIN users ON wishes.user_id = users.id WHERE wishes.user_id = %(user_id)s AND wishes.granted = 0 ORDER BY wishes.created_at DESC;"
        data = {"user_id": user_id}
        results = connectToMySQL(DB).query_db(query, data)
        ungranted_wishes = []
        if results:
            for row in results:
                ungranted_wish = cls(row)
                ungranted_wishes.append(ungranted_wish)
        return ungranted_wishes

    @classmethod
    def get_granted(cls):
        query = """
        SELECT wishes.*, users.id AS user_id, users.first_name, users.last_name, users.email, users.password, users.created_at, users.updated_at
        FROM wishes 
        LEFT JOIN users ON wishes.user_id = users.id 
        WHERE granted = 1
        """
        results = connectToMySQL(DB).query_db(query)
        granted_wishes = []
        if results:
            for row in results:
                user_data = {
                    "id": row["user_id"], 
                    "first_name": row["first_name"],
                    "last_name": row["last_name"],
                    "email": row["email"],
                    "password": row["password"],
                    "created_at": row["created_at"],
                    "updated_at": row["updated_at"]
                }
                granted_wish = cls(row)
                granted_wish.user = User(user_data)
                granted_wishes.append(granted_wish)
        return granted_wishes
    
    @classmethod
    def grant(cls, wish):
        try:
            query = "UPDATE wishes SET granted = 1 WHERE id = %(id)s;"
            data = {'id': wish.id}
            connectToMySQL(DB).query_db(query, data)
            wish.granted = 1
        except Exception as e:
            print("Error granting wish", e)
            raise
        
        
