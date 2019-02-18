#!/bin/bash
# Install Vagrant 2.0.2 and VirtualBox 5.2 on Ubuntu 17.10

sudo apt-get update && sudo apt-get upgrade -y

#Install Vagrant
wget https://releases.hashicorp.com/vagrant/2.2.2/vagrant_2.2.2_x86_64.deb
sudo dpkg -i vagrant_2.2.2_x86_64.deb

sudo apt-get update && sudo apt-get dist-upgrade -y && sudo apt-get autoremove -y 
sudo apt-get -y install gcc make linux-headers-$(uname -r) dkms

#Install VirtualBox
wget -q https://www.virtualbox.org/download/oracle_vbox_2016.asc -O- | sudo apt-key add -
wget -q https://www.virtualbox.org/download/oracle_vbox.asc -O- | sudo apt-key add -

sudo sh -c 'echo "deb http://download.virtualbox.org/virtualbox/debian $(lsb_release -sc) contrib" >> /etc/apt/sources.list'

sudo apt-get update
sudo apt-get -y install virtualbox-5.2 -y

#Get Extentions
curl -O https://download.virtualbox.org/virtualbox/5.2.22/Oracle_VM_VirtualBox_Extension_Pack-5.2.22-126460.vbox-extpack
sudo VBoxManage extpack install Oracle_VM_VirtualBox_Extension_Pack-5.2.22-126460.vbox-extpack

#Check Extentions
VBoxManage -v
VBoxManage list extpacks

# Install 7Zip
sudo apt-get -y install p7zip-full htop tree tmux

#Get Scripts Then Extract
wget https://github.com/herrnikolov/SoftUni_-_DevOps_Basics_-_Oct_2017/raw/master/12.%20Experimenting/DOB-Exam.7z
7z x DOB-Exam.7z

#Ref
#https://websiteforstudents.com/installing-virtualbox-5-2-ubuntu-17-04-17-10/

