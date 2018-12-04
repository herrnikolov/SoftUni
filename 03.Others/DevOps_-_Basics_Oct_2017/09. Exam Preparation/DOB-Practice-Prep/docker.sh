#!/bin/bash

echo "* Add hosts ..."
echo "192.168.82.100 ansible.sulab.local ansible" >> /etc/hosts
echo "192.168.82.101 jenkins.sulab.local jenkins" >> /etc/hosts
echo "192.168.82.102 nagios.sulab.local nagios" >> /etc/hosts
echo "192.168.82.103 docker.sulab.local docker" >> /etc/hosts

echo "* SELinux in permisive mode ..."
setenforce 0

echo "* Firewall - open port 80 ..."
sudo firewall-cmd --add-port=80/tcp --permanent
sudo firewall-cmd --reload

echo "* Firewall - open port 5666 ..."
sudo firewall-cmd --add-port=5666/tcp --permanent
sudo firewall-cmd --reload

echo "* Install jdk  ..."
sudo yum install -y java-1.8.0-openjdk
