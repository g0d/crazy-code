# Test app (easy Deployment System - Test App)
# Coded by George Delaportas (g0d)

from flask import Flask

myApp = Flask(__name__)

@myApp.route("/")

def helloBud():
    return "Hello buddy!"

if __name__ == "__main__":
    myApp.run()
