#!/bin/bash

echo '* Update and install Ansible ...'
sudo apt-get update
sudo apt-get install -y ansible

echo '* Execute Ansible playbook ...'
ansible-playbook -v /vagrant/playbook.yml -i "localhost," --connection=local

