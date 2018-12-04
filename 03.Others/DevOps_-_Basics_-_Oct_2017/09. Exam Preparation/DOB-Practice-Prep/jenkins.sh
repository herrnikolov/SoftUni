#!/bin/bash

echo "* Add hosts ..."

echo "192.168.82.100 ansible.sulab.local ansible" >> /etc/hosts
echo "192.168.82.101 jenkins.sulab.local jenkins" >> /etc/hosts
echo "192.168.82.102 nagios.sulab.local nagios" >> /etc/hosts
echo "192.168.82.103 docker.sulab.local docker" >> /etc/hosts

echo "* Firewall - open port 8080 ..."

sudo firewall-cmd --add-port=8080/tcp --permanent
sudo firewall-cmd --reload
