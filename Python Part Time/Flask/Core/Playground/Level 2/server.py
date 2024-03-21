from flask import Flask, render_template
app = Flask (__name__)

# Level 2 
@app.route("/play/<int:x>")
def play_x(x):
    return render_template('index.html', x=x)

if __name__=="__main__": 
    app.run(debug=True) 
    

