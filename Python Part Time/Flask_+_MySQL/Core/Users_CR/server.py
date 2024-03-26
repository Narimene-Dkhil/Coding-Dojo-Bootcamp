from flask import Flask, redirect, render_template, request, session
from users import User

app = Flask(__name__)

@app.route("/")
def index():
    return redirect("/users")

@app.route("/users")
def users():
    return render_template("read.html", users=User.get_all())


@app.route("/user/new")
def add_new():
    return render_template ("create.html")

@app.route("/users/create", methods=["POST"])
def create():
    print(request.form)
    User.save(request.form) 
    return redirect("/users")
    


if __name__ == "__main__":
    app.run(debug=True)