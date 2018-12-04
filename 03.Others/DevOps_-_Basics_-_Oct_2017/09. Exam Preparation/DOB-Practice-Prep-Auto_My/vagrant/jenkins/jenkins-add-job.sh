#!/bin/bash

# 
# Import Jenkins Job
# 

java -jar /opt/jenkins-cli.jar -s http://localhost:8080/ -remoting login --username admin --password admin create-job Docker-GitHub-Final < Docker-GitHub-Final.xml

