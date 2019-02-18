FROM centos

RUN yum install -y git java-1.8.0-openjdk-headless unzip

ADD https://download.docker.com/linux/static/stable/x86_64/docker-18.09.1.tgz /tmp/ 

RUN tar xzvf /tmp/docker-18.09.1.tgz -C /tmp/ docker/docker && mv /tmp/docker/docker /usr/local/bin/docker

RUN curl -fSL "https://releases.hashicorp.com/nomad/0.8.7/nomad_0.8.7_linux_amd64.zip" -o "/tmp/nomad.zip" && unzip /tmp/nomad.zip -d /tmp && chmod +x /tmp/nomad && mv /tmp/nomad /usr/bin/nomad
