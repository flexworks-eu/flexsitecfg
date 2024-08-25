PHONY: build run

build-linux:
	dotnet publish -c Release -r linux-arm64 --self-contained true /p:PublishSingleFile=true /p:EnableCompressionInSingleFile=true

build-mac:
	dotnet publish -c Release -r osx-arm64 --self-contained true /p:PublishSingleFile=true /p:EnableCompressionInSingleFile=true

run:
	dotnet run -- --config config.json --output nginx.upstream.conf