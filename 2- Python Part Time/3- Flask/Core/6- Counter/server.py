from flask import Flask, render_template, session, redirect 
app = Flask(__name__)
app.secret_key = "your secret key" 

@app.route("/")
def index():
    if 'counter' not in session:
        session['counter'] = 1
    else:
        session['counter'] += 1
    return render_template("index.html", counter=session["counter"])

@app.route("/increment", methods=["POST"])
def increment():
    session["counter"] += 1
    return redirect("/")

@app.route("/destroy_session")
def destry_session():
    session.clear()
    return redirect("/")

if __name__ == "__main__":
    app.run(debug=True)


    
