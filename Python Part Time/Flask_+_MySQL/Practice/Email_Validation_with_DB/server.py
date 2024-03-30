from flask_app import app
app.secret_key = 'your_secret_key_here'

from flask_app.controllers import users 

if __name__ == "__main__":
    app.run(debug=True)