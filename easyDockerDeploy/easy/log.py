# Test logging app (easy Deployment System - Test Logging App)
# Coded by George Delaportas (g0d)

import docker

dockerClient = docker.from_env()

file_handler = open('easy/instances_log.txt', 'w')

for container in dockerClient.containers.list():
    file_handler.write('\n' + container.logs() + '\n')

file_handler.close()
