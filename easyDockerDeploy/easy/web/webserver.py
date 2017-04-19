# Test web server (easy Deployment System - Test web server)
# Coded by George Delaportas (g0d)

from webapp import myApp

import cherrypy

if __name__ == '__main__':

    # Set root dir
    cherrypy.tree.graft(myApp, "/")

    # Unsubscribe (by default)
    cherrypy.server.unsubscribe()

    # Initialize
    myServer = cherrypy._cpserver.Server()

    # Configure the server (HTTP)
    myServer.socket_host = "0.0.0.0"
    myServer.socket_port = 80
    myServer.thread_pool = 30

    # Subscribe
    myServer.subscribe()

    # Start the server
    cherrypy.engine.start()
    cherrypy.engine.block()
