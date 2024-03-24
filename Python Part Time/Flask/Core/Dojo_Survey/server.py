from flask import Flask, render_template, session, redirect,request

app = Flask(__name__)
app.secret_key = "This is secret"

@app.route("/")
def index():
    return render_template("index.html")

@app.route("/process", methods=['POST'])
def process():
    print("Got post info")
    print(request.form)
    session["name"] = request.form["name"]
    session["dojo_location"] = request.form["dojo_location"]
    session["favorite_language"] = request.form["favorite_language"]
    session["comment"] = request.form["comment"]
    return redirect("/result")

@app.route("/result")
def result():
    return render_template("result.html", name_on_template=session["name"], 
                        location_on_template=session["dojo_location"], 
                        language_on_template=session["favorite_language"],
                        comment_on_template=session["comment"])


if __name__ == "__main__":
    app.run(debug=True)