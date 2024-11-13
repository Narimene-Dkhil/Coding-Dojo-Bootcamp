from ..config.mysqlconnection import connectToMySQL,DB
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
from flask import flash
class User:
    #constructor
    def __init__(self,data) :
        self.id= data['id']
        self.first_name=data['first_name']
        self.last_name=data['last_name']
        self.email = data['email']
        self.password=data['password']
        self.created_at=data['created_at']
        self.updated_at=data['updated_at']
    #register=> save
    @classmethod
    def register(cls, data):
        
        query ="INSERT INTO users ( first_name, last_name, email,password) VALUES ( %(first_name)s, %(last_name)s, %(email)s,%(password)s);"
        return connectToMySQL(DB).query_db(query,data)
    #login=> get by email
    @classmethod
    def get_by_email(cls, data):
        query = "SELECT * FROM users WHERE email = %(email)s;"
        results = connectToMySQL(DB).query_db(query,data)
        if len(results)<1:
            return False
        return cls(results[0])
    #validation : register
    @staticmethod
    def validate_register(user):
        is_valid=True
        if len(user["first_name"])<2:
            is_valid=False
            #{"Register":, "Login"}
            #messages ["register"]=> category
            flash("Fisrt_name mus be at least 2 chars","Register")
        if len(user['last_name'])<2:
            flash("Last name must be at least 2 characters,required*","Register")
            is_valid=False
        #format 
        if not EMAIL_REGEX.match(user['email']):
            flash("Invalid Email, check your syntax","Register")
            is_valid=False
        elif User.get_by_email({'email':user['email']}):
            flash("Email exist,try to login","register")
            is_valid=False
        if len(user['password'])<1:
            is_valid = False
            flash("Password is required" ,"Register")
        if user['password']!=user['confirm_password']:
            flash("Passwords must match","Register")
            is_valid=False
        return is_valid
        #login => mwjoud fi list
    #validation: login : controller