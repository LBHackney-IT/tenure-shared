PROJECT_NAME := hackney-shared-tenure-test

.PHONY: clean
clean:
	docker rmi ${PROJECT_NAME}
	-docker rmi $$(docker images --filter "dangling=true" -q --no-trunc)

.PHONY: test
test:
	-docker-compose run --rm ${PROJECT_NAME}
	-make clean

.PHONY: ensure-dotnet-format
ensure-dotnet-format:
	-dotnet tool install -g dotnet-format
	dotnet tool update -g dotnet-format

.PHONY: checkf
checkf:
	make ensure-dotnet-format
	dotnet-format --check

.PHONY: lint
lint:
	make ensure-dotnet-format
	dotnet format
