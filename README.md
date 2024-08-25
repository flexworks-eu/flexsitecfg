# Flexworks Site Config Builder for openresty/nginx

# Introduction

Having multiple versions/stacks of the same [website](https://flexworks.eu), they need to know about the config and so does the reverse proxy, which connects you to any of these backends.  Not wanting to duplicate config, storing it in a single json file as the single source of truth seems pretty convincing.  An app will be built to manage this config and we needed something to translate this json into an nginx importable config.  That's where this project comes in.



## execute

```shell
./FlexSiteConfig --config config.json --output nginx.upstream.conf
```


```shell
dotnet run -- --config config.json --output nginx.upstream.conf
```
* mind the intentional **--**, it's there for a reason


## example

### input

```json
{
    "backend_id1": {
        "description": "zig backend",
        "backend_servers": [
            {
                "servername": "192.168.1.1",
                "port": 8080
            },
            {
                "servername": "192.168.1.2",
                "port": 8081
            }
        ]
    }
}
```

### output

```conf
# zig backend
upstream backend_id1 {
    server 192.168.1.1:8080;
    server 192.168.1.2:8081;
}

upstream backend_servers {
    server 192.168.1.1:8080 max_fails=3 fail_timeout=30s;
    server 192.168.1.2:8081 max_fails=3 fail_timeout=30s;
}

```


## build
```shell
 dotnet publish -c Release -r osx-arm64 --self-contained true /p:PublishSingleFile=true /p:EnableCompressionInSingleFile=true
```

(can't use /p:PublishTrimmed=true without explicitly managing the json types in code)


