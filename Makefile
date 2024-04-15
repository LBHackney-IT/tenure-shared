PROJECT_NAME := hackney-shared-tenure-test

# The dangling image removal doesn't behave as expected on Windows Powershell.
# It is recommended to run Makefile commands using `git bash` if you're using Windows.
# If you decide to stick with Powershell regardless, everything except dangling image removal will still work,
# however, you'll need to remove those <none> <none> images by listing out their hashes manually.
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
