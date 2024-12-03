from ..config.mysqlconnection import connectToMySQL,DB
from ..models.user import User
from flask import flash

class Ride:
    def __init__(self,data) :
        self.id= data['id']
        self.destination=data['destination']
        self.pick_up_location=data['pick_up_location']
        self.ride_date = data['ride_date']
        self.details=data['details']
        self.created_at=data['created_at']
        self.updated_at=data['updated_at']
        self.rider_id=None
        self.driver_id=None
        self.driver=None
        self.rider=None
    #CRUD
    @classmethod
    def get_all(cls):
        query="SELECT*FROM rides"
        results=connectToMySQL(DB).query_db(query)
        rides=[]
        for row in results:
            rides.append(cls(row))
        return rides
    
    @classmethod
    def save(cls, data):
        query ="INSERT INTO rides ( destination, pick_up_location, ride_date,details,rider_id,driver_id) VALUES  (%(destination)s, %(pick_up_location)s,%(ride_date)s, %(details)s, 4,2) ;"
        return connectToMySQL(DB).query_db(query,data)
    
    @classmethod
    def get_by_id(cls,data):
        query="SELECT*FROM rides WHERE id=%(id)s;"
        results = connectToMySQL(DB).query_db(query,data)
        if len(results)<1:
            return False
        
        return cls(results[0])
    @classmethod
    def get_logged_user_rides(cls,data):
        query="""SELECT * FROM rides
                LEFT JOIN users ON rider_id WHERE users.id=rides.rider_id AND users.id=%(user_id)s AND rides.driver_id is NULL ;"""
        return connectToMySQL(DB).query_db(query,data)
    @classmethod
    def get_others_rides(cls,data):
        query="""SELECT * FROM rides
                LEFT JOIN users ON rider_id WHERE users.id=rides.rider_id AND users.id!=%(user_id)s AND rides.driver_id is NULL ;"""
        results= connectToMySQL(DB).query_db(query,data)
        #the prob is we can't get the rider name since we just have the user name therefore we will add it
        rides=[]
        for r in results:
            rider=User.get_by_id({"id":r['rider_id']})
            full_ride={
            "id":r['id'],
            "destination":r['destination'],
            "pick_up_location":r['pick_up_location'],
            "details":r['details'],
            "ride_date":r['ride_date'],
            "created_at":r['created_at'],
            "updated_at":r['updated_at'],
            "rider":rider,
            "driver": None
            }
            print(full_ride)
            rides.append(full_ride)
        return rides
    @classmethod
    def update(cls,data):
        query="UPDATE rides SET  pick_up_location = %(pick_up_location)s, details = %(details)s  WHERE id = %(id)s ;  " 
        return connectToMySQL(DB).query_db(query,data)
    @classmethod
    def get_booked_req(cls):
        query="""SELECT * FROM rides
                LEFT JOIN users ON rider_id WHERE users.id=rides.rider_id  AND rides.driver_id is NOT NULL ;"""
        results= connectToMySQL(DB).query_db(query)
        rides=[]
        for r in results:
            driver=User.get_by_id({"id":r['driver_id']})
            rider=User.get_by_id({"id":r['rider_id']})
            full_ride={
            "id":r['id'],
            "destination":r['destination'],
            "pick_up_location":r['pick_up_location'],
            "details":r['details'],
            "ride_date":r['ride_date'],
            "created_at":r['created_at'],
            "updated_at":r['updated_at'],
            "rider":rider,
            "driver":driver
        }
            print(full_ride)
            rides.append(full_ride)
        return rides

    @classmethod
    def delete(cls,data):
        query="DELETE FROM rides WHERE id=%(id)s;"
        return connectToMySQL(DB).query_db(query,data)
    @staticmethod
    def validate_ride(data):
        is_valid=True
        if len(data['destination'])<4:
            flash("Destination must be at least 3 characters, required*","ride")
            is_valid=False
        if len(data['pick_up_location'])<4:
            flash("Pick up location must be at least 3 characters, required*","ride")
            is_valid=False
        if len(data['details'])<11:
            flash("Details must be at least 10 characters, required*","ride")
            is_valid=False
        if data['ride_date'] is None:
            flash("Date mustn't be blank, required*","ride")
            is_valid=False
        return is_valid

