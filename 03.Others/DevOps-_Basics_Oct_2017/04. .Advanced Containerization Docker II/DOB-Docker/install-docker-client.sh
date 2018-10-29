#!/bin/bash

curl -L https://download.docker.com/linux/static/edge/x86_64/docker-17.10.0-ce.tgz > /tmp/docker-17.10.0-ce.tgz && \
     tar xzvf /tmp/docker-17.10.0-ce.tgz && \
     sudo mv docker/docker /usr/local/bin/docker && \
     rm -rf docker/ && \
     rm /tmp/docker-17.10.0-ce.tgz
