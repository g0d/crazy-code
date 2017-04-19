# Coded by George Delaportas (g0d/ViR4X)
# Copyright (C) 2017
# This is an easy deployment framework for Docker



# Use Ubuntu as base image
FROM ubuntu

# Mainter is known
MAINTAINER George Delaportas (g0d)

# Fetch latest release : Use $(lsb_release -sc) for latest, but Xenial has a broken Release file (Use static)
RUN echo "deb http://archive.ubuntu.com/ubuntu/ xenial main universe" >> /etc/apt/sources.list

# Update all sources
RUN apt-get update

# Install essential utilities
RUN apt-get install -y tar git curl nano wget dialog net-tools build-essential

# Install python and PIP
RUN apt-get install -y python python-dev python-distribute python-pip

# Upgrade PIP
RUN pip install --upgrade pip

# Add easy folder in the container image
ADD /easy /easy

# Call PIP to download and install requirements
RUN pip install -r /easy/reqs.txt

# Expose port 80
EXPOSE 80

# Set the default working directory
WORKDIR /easy/web

# Run web server
CMD python webserver.py



# ----- End of docker file -----
