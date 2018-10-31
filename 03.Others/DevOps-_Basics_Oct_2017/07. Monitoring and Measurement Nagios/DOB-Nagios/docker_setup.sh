#!/bin/bash

#
# docker_setup.sh
#
# Docker setup script
#

# Remove all existing related software
sudo yum remove docker \
                  docker-common \
                  container-selinux \
                  docker-selinux \
                  docker-engine

# Add the required dependencies
sudo yum install -y yum-utils device-mapper-persistent-data lvm2

# Add the Docker repository
sudo yum-config-manager \
       --add-repo \
       https://download.docker.com/linux/centos/docker-ce.repo

# Prepare YUM
sudo yum makecache fast

# Install Docker
sudo yum install -y docker-ce

# Configure Docker
sudo mkdir -p /etc/docker
sudo cat > /tmp/daemon.json << EOF
{
  "storage-driver": "devicemapper"
}
EOF
sudo cp /tmp/daemon.json /etc/docker/

# Add the user to Docker group
sudo usermod -aG docker $USER

# Start and enable Docker
sudo systemctl start docker
sudo systemctl enable docker

# Print some information
sudo systemctl status docker
sudo docker version
sudo docker system info
