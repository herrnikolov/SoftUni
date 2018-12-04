#!/bin/bash

echo "* Add hosts ..."
echo "192.168.82.100 ansible.sulab.local ansible" >> /etc/hosts
echo "192.168.82.101 jenkins.sulab.local jenkins" >> /etc/hosts
echo "192.168.82.102 nagios.sulab.local nagios" >> /etc/hosts
echo "192.168.82.103 docker.sulab.local docker" >> /etc/hosts

echo "* SELinux in permisive mode ..."
setenforce 0

echo "* Install Nagios ..."
sudo yum install -y nagios nagios-plugins-all nagios-plugins-nrpe

echo "* Set password (Password1) for nagiosadmin ..."
sudo htpasswd -b /etc/nagios/passwd nagiosadmin Password1

echo "* Add some nice logos ..."
sudo mv /tmp/logos/*.png /usr/share/nagios/html/images/logos

echo "* Add Docker container check plugin ..."
sudo mv /tmp/check_docker_container.sh /usr/lib64/nagios/plugins/check_docker_container.sh

echo "* Turn on execute permission for chec_docker_container.sh ..."
sudo chmod +x /usr/lib64/nagios/plugins/check_docker_container.sh

echo "* Add/change Nagios configuration files ..."
sudo mv /tmp/cfg/localhost.cfg /etc/nagios/objects/localhost.cfg
sudo mv /tmp/cfg/* /etc/nagios/conf.d

echo "* Start and enable Nagios ..."
sudo systemctl enable nagios 
sudo systemctl start nagios

echo "* Start and enable Apache HTTP ..."
sudo systemctl enable httpd
sudo systemctl start httpd

echo "* Firewall - open port 80 ..."
sudo firewall-cmd --add-port=80/tcp --permanent
sudo firewall-cmd --reload
