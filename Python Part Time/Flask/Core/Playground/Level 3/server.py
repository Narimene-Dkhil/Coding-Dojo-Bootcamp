from flask import Flask, render_template
app = Flask (__name__)

# Level 3 
@app.route("/play/<int:x>/<string:color>")
def play_x_color(x, color):
    return render_template('index.html', x=x, color=color)

if __name__=="__main__": 
    app.run(debug=True) 
    

