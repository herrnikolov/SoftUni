#! /bin/bash

for i in 1 2 3; do
  docker-machine create -d virtualbox docker-$i;
done

eval $(docker-machine env docker-1)

docker swarm init --advertise-addr $(docker-machine ip docker-1)

TOKEN=$(docker swarm join-token -q worker)
for i in 2 3; do 
  eval $(docker-machine env docker-$i); 
  docker swarm join --token $TOKEN --advertise-addr $(docker-machine ip docker-$i) $(docker-machine ip docker-1):2377;
done
  
eval $(docker-machine env docker-1)

docker node ls
