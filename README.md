# Flexworks Site Config Builder for openresty/nginx

# Introduction

Having multiple versions/stacks of the same [website](https://flexworks.eu), they need to know about the config and so does the reverse proxy, which connects you to any of these backends.  Not wanting to duplicate config, storing it in a single json file as the single source of truth seems pretty convincing.  An app will be built to manage this config and we needed something to translate this json into an nginx importable config.  That's where this project comes in.


## execute

```shell
./flexsitecfg --config config.json --output nginx.upstream.conf
```


```shell
dotnet run -- --config config.json --output nginx.upstream.conf
```
* mind the intentional **--**, it's there for a reason

## build
```shell
 dotnet publish -c Release -r osx-arm64 --self-contained true /p:PublishSingleFile=true /p:EnableCompressionInSingleFile=true
```

(can't use /p:PublishTrimmed=true without explicitly managing the json types in code)


