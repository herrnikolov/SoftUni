#!/bin/bash

echo "* Add hosts ..."
echo "192.168.81.100 dob-web.sulab.local dob-web" >> /etc/hosts
echo "192.168.81.101 dob-db.sulab.local dob-db" >> /etc/hosts

echo "* Install Software ..."
sudo yum update
sudo yum install -y mariadb mariadb-server

echo "* Start HTTP ..."
sudo systemctl enable mariadb
sudo systemctl start mariadb

echo "* Firewall - open port 3306 ..."
sudo firewall-cmd --add-port=3306/tcp --permanent
sudo firewall-cmd --reload


echo "* Create and load the database ..."
mysql -u root < /vagrant/db_setup.sql
