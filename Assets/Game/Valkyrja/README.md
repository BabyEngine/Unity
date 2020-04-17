# 女武神

需要配合[服务端](https://github.com/BabyEngine/Backend)使用

### 服务端运行
```
1. 进入scripts目录
2. 启动游戏
GameApp-linux run games\Valkyrja\main.lua
```

### 客户端

服务端  games\Valkyrja\main.lua
```
NetService.startGameServer(":8087")
```

客户端 Assets/Game/Valkyrja/lua/conf/AppConf.lua
```
AppConf.ServerAddress = "127.0.0.1"
AppConf.ServerPort    = 8087
```
