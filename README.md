# Flexworks Site Config Builder for openresty/nginx

## execute
```shell
dotnet run -- --config config.json --output nginx.upstream.conf
```

## build
```shell
 dotnet publish -c Release -r osx-arm64 --self-contained true /p:PublishSingleFile=true /p:EnableCompressionInSingleFile=true
```

(can't use /p:PublishTrimmed=true without explicitly managing the json types in code)
