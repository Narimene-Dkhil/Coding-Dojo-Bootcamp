from flask import redirect, render_template, request, session, flash, jsonify
from flask_app import app
from flask_app.models.user import User
from flask_app.models.wish import Wish
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
    
    return redirect('/wishes')

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
    return redirect('/wishes')


@app.route('/wishes')
def wishes():
    if 'user_id' not in session:
        return redirect('/logout')
    
    logged_user = User.get_by_id({'id': session['user_id']})
    
    ungranted_wishes = Wish.get_ungranted(logged_user.id)
    granted_wishes = Wish.get_granted()

    print('Ungranted wishes:', ungranted_wishes)
    print('Granted wishes:', granted_wishes)
    return render_template("wishes.html", logged_user=logged_user, ungranted_wishes=ungranted_wishes, granted_wishes=granted_wishes)


@app.route('/wishes/grant/<int:id>', methods=['POST'])
def grant_wish(id):
    wish = Wish.get_by_id({'id': id})
    if wish.user.id != session.get('user_id'):
        return jsonify({'success': False, 'message': 'Permission denied'})

    Wish.grant(wish)
    return jsonify({'success': True, 'wish': wish}) 


@app.route('/logout')
def logout():
    session.clear()
    return redirect ('/')