from flask import redirect, render_template, request
from flask_app import app
from flask_app.modules.cookie import Cookie

@app.route('/')
def index():
    return redirect('/cookies')
    
    
@app.route('/cookies')
def cookies():
    cookies = Cookie.get_all()
    return render_template('cookies.html', all_cookies=cookies)



@app.route('/cookies/new')
def new_cookie():
    return render_template('cookie_new.html')

@app.route('/cookies/create', methods=['POST'])
def create_cookie():
    if not Cookie.validate_order(request.form):
        return redirect('/cookies/new')
    print(request.form)
    Cookie.save(request.form)
    return redirect('/cookies')



@app.route('/cookies/edit/<int:id>')
def edit_cookie(id):
    data = {"id" : id}
    cookie = Cookie.get_one(data)
    return render_template('cookie_update.html', cookie=cookie)

@app.route('/cookies/update/<int:id>', methods=['POST'])
def update_cookie(id):
    data = {
        "id" : id,
        "customer_name" : request.form["customer_name"],
        "cookie_type" : request.form["cookie_type"],
        "num_boxes" : request.form["num_boxes"]
    }
    if not Cookie.validate_order(request.form):
        return redirect(f'/cookies/edit/{id}') 
    Cookie.update(data)
    print(data)
    return redirect('/cookies')