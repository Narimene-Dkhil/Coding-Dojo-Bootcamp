from flask import redirect, render_template, request 
from flask_app import app 
from flask_app.models.user import User

@app.route("/")
def index():
    return redirect("/users")

@app.route("/users")
def users():
    return render_template("read.html", users=User.get_all())

@app.route("/user/new")
def add_new():
    return render_template ("create.html")

@app.route("/user/create",methods=["POST"])
def create():
    if User.is_valid_user(request.form):
        User.save(request.form)
        return redirect("/")
    else:
        return redirect('/user/new')

@app.route("/user/edit/<int:id>")
def edit(id):
    data = { "id": id }
    user = User.get_one(data)
    return render_template("edit_user.html", user=user)

@app.route("/user/show/<int:id>")
def show(id):
    data ={ 
        "id":id
    }
    return render_template("show_user.html",user=User.get_one(data))

@app.route("/user/update", methods=["POST"])
def update():
    data = {
        "id": request.form["id"],
        "first_name": request.form["first_name"],
        "last_name": request.form["last_name"],
        "email": request.form["email"]
    }
    User.update(data)
    return redirect("/users")

@app.route("/user/destroy/<int:id>")
def destroy(id):
    data ={
        "id": id
    }
    User.destroy(data)
    return redirect("/users")