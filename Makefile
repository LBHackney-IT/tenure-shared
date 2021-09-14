.PHONY: setup
setup:
	docker-compose build

.PHONY: build
build:
	docker-compose build hackney-shared-tenure

.PHONY: serve
serve:
	docker-compose build hackney-shared-tenure && docker-compose up hackney-shared-tenure

.PHONY: shell
shell:
	docker-compose run hackney-shared-tenure bash

.PHONY: test
test:
	docker-compose up dynamodb-database & docker-compose build hackney-shared-tenure-test && docker-compose up hackney-shared-tenure-test

.PHONY: lint
lint:
	-dotnet tool install -g dotnet-format
	dotnet tool update -g dotnet-format
	dotnet format

.PHONY: restart-db
restart-db:
	docker stop $$(docker ps -q --filter ancestor=dynamodb-database -a)
	-docker rm $$(docker ps -q --filter ancestor=dynamodb-database -a)
	docker rmi dynamodb-database
	docker-compose up -d dynamodb-database
