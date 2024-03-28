from flask_app.config.mysqlconnection import connectToMySQL, DB

class Ninja:
    def __init__(self, data):
        self.id = data["id"]
        self.first_name = data["first_name"]
        self.last_name = data["last_name"]
        self.age = data["age"]
        self.dojo_id = data.get("dojo_id")
        self.created_at = data["created_at"]
        self.updated_at = data["updated_at"]
        
    @classmethod
    def save(cls, data):
        query = """INSERT INTO ninjas (first_name, last_name, age, dojo_id) 
        VALUES (%(first_name)s, %(last_name)s, %(age)s, %(dojo_id)s);"""
        return connectToMySQL(DB).query_db(query,data)
        
    @classmethod
    def get_one_by_id(cls, ninja_id):
        query = "SELECT * FROM ninjas WHERE id = %(ninja_id)s;"
        data = {
            "ninja_id": ninja_id
        }
        result_list = connectToMySQL(DB).query_db(query, data)
        ninja = cls(result_list[0])
        return ninja 
    
    @classmethod
    def delete(cls, ninja_id):
        query = "DELETE FROM ninjas WHERE id = %(ninja_id)s;"
        data = {
            "ninja_id": ninja_id
        }
        return connectToMySQL(DB).query_db(query, data)
    
    @classmethod
    def update(cls, data):
        query = "UPDATE ninjas SET first_name = %(first_name)s , last_name = %(last_name)s , age = %(age)s WHERE id = %(ninja_id)s"
        return connectToMySQL(DB).query_db(query, data)
        