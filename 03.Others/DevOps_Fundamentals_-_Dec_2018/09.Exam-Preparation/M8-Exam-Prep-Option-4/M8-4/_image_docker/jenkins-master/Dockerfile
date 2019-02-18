FROM jenkins/jenkins:latest

COPY home /usr/share/jenkins/ref/
RUN /usr/local/bin/install-plugins.sh $(cat /usr/share/jenkins/ref/plugins.txt)

USER root

RUN apt-get update -y && apt-get install -yq jq

USER jenkins
