.DEFAULT_GOAL := help

help:
	@echo "Please choose what you want to do: \n" \
	" make dup: start docker container \n" \
	" make ddw: stop docker container \n" \
	" make drs: restart docker container \n" \
	" make mysql: go into the mysql container \n" \

dup:
	export COMPOSE_FILE=docker-compose.yml; docker-compose --env-file=./docker/.env.docker up -d

ddw:
	export COMPOSE_FILE=docker-compose.yml; docker-compose down --volumes

drs:
	export COMPOSE_FILE=docker-compose.yml; docker-compose down --volumes && docker-compose up -d

mysql:
	docker exec -it database bash