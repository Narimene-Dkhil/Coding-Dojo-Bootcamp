from flask import redirect, render_template, request, session, flash
from flask_app import app
from flask_app.models.user import User
from flask_app.models.recipe import Recipe 
from flask_bcrypt import Bcrypt
bcrypt = Bcrypt(app)


@app.route('/')
def index():
    return render_template('index.html')

@app.route('/register', methods=['POST'])
def register():
    if not User.validate_register(request.form):
        return redirect('/')
    data = {
        "first_name": request.form['first_name'],
        "last_name": request.form['last_name'],
        "email": request.form['email'],
        "password": bcrypt.generate_password_hash(request.form['password'])
    }
    id = User.save(data)
    session['user_id'] = id 
    
    return redirect('/recipes')

@app.route('/login', methods=['POST'])
def login():
    user  = User.get_by_email(request.form)
    if not user:
        flash("Invalid email", "login")
        return redirect('/')
    
    if not bcrypt.check_password_hash(user.password, request.form['password']):
        flash("Invalid password", "login")
        return redirect('/')
    
    session['user_id'] = user.id
    return redirect('/recipes')


@app.route('/recipes')
def recipes():
    logged_user = None
    if 'user_id' in session:
        logged_user = User.get_by_id({'id': session['user_id']})
    recipes = Recipe.get_all()
    return render_template("recipes.html", user=logged_user, logged_user=logged_user, recipes=recipes)

@app.route('/logout')
def logout():
    session.clear()
    return redirect ('/')