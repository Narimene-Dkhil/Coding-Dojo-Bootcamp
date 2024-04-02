from flask_app.config.mysqlconnection import connectToMySQL, DB
from flask import flash


class Cookie:
    def __init__(self, data):
        self.id = data["id"]
        self.customer_name = data["customer_name"]
        self.cookie_type = data["cookie_type"]
        self.num_boxes = data["num_boxes"]
        self.created_at = data["created_at"]
        self.updated_at = data["updated_at"]
        
    @classmethod
    def get_all(cls):
        query = "SELECT * FROM cookie_orders;"
        results = connectToMySQL(DB).query_db(query)
        
        all_cookies = []
        for cookie in results:
            all_cookies.append(cls(cookie))
        return all_cookies 
    
    @classmethod
    def save(cls, data):
        query = "INSERT INTO cookie_orders (customer_name, cookie_type, num_boxes) VALUES ( %(customer_name)s, %(cookie_type)s, %(num_boxes)s);"
        result = connectToMySQL(DB).query_db(query, data)
        return result 
    
    @classmethod
    def update(cls, data):
        query = "UPDATE cookie_orders SET customer_name=%(customer_name)s, cookie_type=%(cookie_type)s, num_boxes=%(num_boxes)s WHERE id=%(id)s;"
        return connectToMySQL(DB).query_db(query,data)
    
    @classmethod
    def get_one(cls,data):
        query = "SELECT * FROM cookie_orders where id=%(id)s"
        result = connectToMySQL(DB).query_db(query,data)
        return cls(result[0])
    
    @staticmethod
    def validate_order(order):
        is_valid = True 
        if len(order['customer_name']) < 2:
            flash("Name must be at least 2 characters.")
            is_valid = False
        if len(order['cookie_type']) < 2:
            flash("Cookie Type must be at least 2 characters.")
            is_valid = False
        if order['num_boxes'] == '':
            flash("Number of Boxes must be provided.")
            is_valid = False
        elif int(order['num_boxes']) < 1:
            flash("Number of Boxes must be 1 or greater.")
            is_valid = False
        return is_valid 
    
    