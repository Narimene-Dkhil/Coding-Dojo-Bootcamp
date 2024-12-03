from ..models.user import User
from flask import render_template,session,redirect,request,flash
from flask_app.models.user import User
# from flask_app.models.ride import Ride 
from flask_bcrypt import Bcrypt
from flask_app import app

#post 2 routes 
#2 form => 2post
# render template 1 route in common 
#3 routes
bcrypt= Bcrypt(app)

@app.route('/')
def index():
    return render_template("index.html")

#----register-----

@app.route('/register', methods=["POST"])
def register():
    if User.validate_register(request.form):
        hashed_password = bcrypt.generate_password_hash(request.form['password'])
        user_data ={
            'first_name': request.form['first_name'],
            'last_name': request.form['last_name'],
            'email': request.form['email'],
            'password': hashed_password
        }
        session['user_id'] = User.register(user_data)
        #save=> return id 
        # print("-"*10, user_id, "-"*10)
        return redirect('/rides/dashboard')
    else:
        print("Data is not valid")
        return redirect("/")

#login : call get by email to make validation that does exist
#redirect to that route
@app.route('/login', methods=['POST'])
def login():
    #check email existence
    user_exist=User.get_by_email({'email':request.form['email']})
    if user_exist:
        if not bcrypt.check_password_hash(user_exist.password, request.form['password']):
            flash('Wrong Inputs',"login")
            return redirect('/')
        else:
            session['user_id']=user_exist.id
            return redirect('/rides/dashboard')
    else:
        flash("user does not exist register first","login")
        return redirect('/')
    

@app.route('/logout')
def logout():
    session.clear()
    return redirect('/')

@app.route('/rides/dashboard')
def test():
    return render_template("dashboard.html")