from flask import Flask 
app = Flask(__name__)  

# 1 localhost:5000/ - have it say "Hello World!"
@app.route("/")
def hello_world():
    return "Hello World!"

# 2 localhost:5000/dojo - have it say "Dojo!"
@app.route("/dojo")
def dojo():
    return "Dojo!"

# 3 Create one url pattern and function that can handle the following examples:
# localhost:5000/say/flask - have it say "Hi Flask!"
# localhost:5000/say/michael - have it say "Hi Michael!"
# localhost:5000/say/john - have it say "Hi John!"
@app.route("/say/<string:name>")
def say(name):
    print(name)
    return f"Hi {name}!"

# 4 Create one url pattern and function that can handle the following examples (HINT: path variables are by default
# passed as strings. How might you handle a number?):
# localhost:5000/repeat/35/hello - have it say "hello" 35 times
# localhost:5000/repeat/80/bye - have it say "bye" 80 times
# localhost:5000/repeat/99/dogs - have it say "dogs" 99 times

@app.route("/repeat/<int:num>/<string:message>")
def repeat(num, message):
    return f"{message * num}"

@app.errorhandler(404)
def page_not_found(error):
    return "Sorry! No response. Try again.", 404 

if __name__=="__main__":
    app.run(debug=True)
    
    