from flask import redirect, render_template, request, session, flash
from flask_app import app
from flask_app.models.wish import Wish
from flask_app.models.user import User
from flask_bcrypt import Bcrypt
bcrypt = Bcrypt(app)

@app.route('/wishes/new')
def new_wish():
    logged_user = User.get_by_id({'id': session['user_id']})
    return render_template('new_wish.html', user = logged_user)

@app.route('/wishes/create', methods=['POST'])
def create_wish():
    if 'user_id' not in session:
        flash('Please log in to view this page', 'register')
        return redirect('/login')
    
    if not Wish.validate_create(request.form):
        return redirect(f'/wishes/new')
    data = {
        'name': request.form['name'],
        'description': request.form['description'],
        'granted': 1 if 'granted' in request.form else 0,
        'user_id': session['user_id']
    }
    Wish.create(data)
    return redirect('/wishes')

@app.route('/wishes/edit/<int:id>')
def edit_wishes(id):
    data = {'id': id}
    wish = Wish.get_by_id(data)
    user = wish.user
    return render_template("edit_wish.html" , wish=wish , user=user)

@app.route('/wishes/update/<int:id>', methods=['POST'])
def update_wish(id):
    if not Wish.validate_update(request.form):
        return redirect(f'/wishes/edit/{id}')
    
    data = {
        'id': id,
        'name': request.form.get('name'),
        'description': request.form.get('description'),
        'granted': 1 if 'granted' in request.form else 0
    }

    Wish.update(data)
    return redirect('/wishes') 

@app.route("/wishes/delete/<int:id>")
def delete(id):
    data = {'id': id}
    wish = Wish.get_by_id(data)
    if wish.user.id == session.get('user_id'):
        Wish.delete(data)
    return redirect('/wishes')


