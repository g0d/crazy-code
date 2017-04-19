#!/bin/bash

###########################################
#		        Main Script	              #
#    Coded by George Delaportas (g0d) 	  #
#    	    Copyright (C) 2017		      #
###########################################



echo "Deploying..."

# Build new image
sudo docker build -t easy_deploy_img .

# Get list of running instances
list=$(sudo docker ps -aq)

# If any active, clean up before new run
if [ -n "$list" ]; then
    echo "Cleaning..."

    # Stoping any previous intances
    sudo docker stop $(sudo docker ps -aq)

    # Removing als previous instances from list
    sudo docker rm $(sudo docker ps -aq)
fi

echo "Setting up..."

# Start 3 test containers (based on new image) running in ports 81,82 and 83 (mapping 80 from image)
sudo docker run -d --name easy_deploy_test_1 -p 81:80 -i -t easy_deploy_img
sudo docker run -d --name easy_deploy_test_2 -p 82:80 -i -t easy_deploy_img
sudo docker run -d --name easy_deploy_test_3 -p 83:80 -i -t easy_deploy_img

echo "Start monitoring..."

# Log instances
instances=$(sudo docker ps -a | grep "easy_deploy_img")
running=$(echo "$instances" | wc -l)

echo "$instances" > easy/central_log.txt

# If instances are not running exit immediately wih an error
if [ -z "$running" ] || [ "$running" -lt 3 ]; then
    echo "Error: Instances didn't run correctly!"
    exit -1
fi

# Gather containers stats
stats=$(sudo docker stats --no-stream)

echo -e "\n$stats" >> easy/central_log.txt

echo "Log..."

# Run instances internal logging facility
sudo python easy/log.py

cat easy/instances_log.txt >> easy/central_log.txt

echo "Done!"
