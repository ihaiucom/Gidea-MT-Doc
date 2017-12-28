# UI模块教程
一般UI模块分为“视图”和"数据"。并且数据层的逻辑是不能直接引用视图层的。下面我们用"英雄模块"举例

* 视图层: 文件放置在 "Lua/gamemodule/Hero/"

* 模块主文件: 相当于这个模块对外开放的接口文件, 所有这类型的文件都放置在 Lua/gamemodule/modules/ 目录下, 英雄模块我们就在该目录下创建一个HeroModule.lua

<p data-anchor-id="l6nr"><div class="toc"><div class="toc">
<ul>
<li><a href="#ui模块教程">UI模块教程</a><ul>
<li><a href="#目录介绍">目录介绍</a></li>
<li><a href="#基本流程">基本流程</a><ul>
<li><a href="#一-配置模块id">一: 配置模块ID</a></li>
<li><a href="#二-xxxmodule门面类">二: XXXModule门面类</a></li>
<li><a href="#三-具体模块目录">三: 具体模块目录</a></li>
<li><a href="#四-创建视图">四: 创建视图</a></li>
<li><a href="#五-配置文件">五: 配置文件</a></li>
<li><a href="#六-协议文件">六: 协议文件</a></li>
<li><a href="#七-require相关的文件">七: require相关的文件</a></li>
</ul>
</li>
<li><a href="#api">API</a><ul>
<li><ul>
<li><a href="#资源">* 资源</a></li>
<li><a href="#配置">* 配置</a></li>
<li><a href="#模块">* 模块</a></li>
<li><a href="#打开关闭模块">* 打开/关闭模块</a></li>
<li><a href="#系统消息">* 系统消息</a></li>
<li><a href="#模块协议处理器">* 模块协议处理器</a></li>
<li><a href="#网络协议">* 网络协议</a></li>
</ul>
</li>
</ul>
</li>
</ul>
</li>
</ul>
</div>
</div>
</p>

## 目录介绍

| 目录														| 介绍																										|
| ------------------------------------------------------	| -------------------------------------------------------------------------------------------------------   |
| Lua/gamemodule/configreaders/ 							| 放置 配置结构文件 和 读取器文件。																			| 
| Lua/gamemodule/moduleprotos/ 								| 放置 协议处理文件。																						| 
| Lua/gamemodule/modules/ 									| 放置 模块门面文件,对外开放。 一般负责对数据层的逻辑，不能直接引用视图层的东西。 可以游戏启动的时候就调用	| 
| Lua/gamemodule/XXXXXXX/ 									| 放置 模块"业务逻辑"和"视图"的Class。																		| 



| Class            		| 文件															| 介绍																					|
| --------------------- | -----------------------------------------------------------	| -------------------------------------------------------------------------------------	|
| MenuId           		| Lua/gameframe/menu/MenuId.lua									| 配置模块ID。																			| 
| ConfigManager    		| Lua/gamemoduledata/configreaders/ConfigManager_List.lua 			| 配置管理器，负责游戏启动的时候调用配置读取器加载和解析。								| 
| ModuleProtoManager    | Lua/gamemoduledata/modulesprotos/ModuleProtoManager.lua 			| 配置所有模块协议的门面类																| 
| ModuleManager    		| Lua/gamemoduledata/modules/ModuleManager_List.lua 				| 配置所有模块的门面类, 方便其他模块调用												| 

## 基本流程


### 一: 配置模块ID

* 在MenuId.lua 下配置一个模块ID
* 在[SVN] gamemt_doc/config/Client/Menu.xlsx 下配置你的模块(MenuId, 模块名称, 窗口预设, 加载条等)
* 在Unity点击菜单 "Game/Tool/xlsx - csv" 生成CSV文件




### 二: XXXModule门面类

* 创建一个XXXModule.lua文件,文件放置在 Lua/gamemodule/modules/
* XXXModule 继承自 AbstractModule。并对其进行配置

> -- 菜单ID

> M.menuId 		= MenuId.XXX

>-- 视图Class

> M.ViewClass 	= XXXWindow



* 在 Lua/gamemoduledata/modules/ModuleManager_List.lua 添加你的 XXXModule




### 三: 具体模块目录
* 在Lua/gamemodule/modules/目录下创建文件夹 XXX

### 四: 创建视图
* 在Lua/gamemodule/modules/目录下创建 XXXWindow视图
* XXXWindow 继承自 AbstractView

### 五: 配置文件
* 在 Lua/gamemodule/configreaders/ 下创建配置结构体 XXXConfig
* 在 Lua/gamemodule/configreaders/ 下创建配置结构体读取器 XXXConfigReader
* 在 Lua/gamemodule/configreaders/ConfigManager_List 添加你的 XXXConfigReader


### 六: 协议处理器文件
* 在 Lua/gamemodule/modulesprotos/ 下创建 XXXProto
* 在 Lua/gamemodule/modulesprotos/ModuleProtoManager.lua 配置 XXXProto

### 七: require相关的文件
* 在 GameInclude.lua 中 require 你模块的文件


## API

#### * 资源

-- 获取实例预设实例对象。 已经 GameObject.Instantiate(prefab) 过了，可以直接用。会由对象池管理

> Game.asset.GetInstallPrefab(path) 


-- 获取资源（非预设类型的, 主要是Sprite,Texture等不用实例化的资源）

> Game.asset.GetAsset(path) 




#### * 配置

-- 获取配置的读取器

> Game.config.xxx 

-- 获取某个配置的读取器

> Game.config.xxx:GetConfig(id)



#### * 模块
-- 获取模块门面

> Game.modules:GetModule(menuId)


#### * 打开/关闭模块

-- 打开某个模块

> Game.menu:Open(menuId, ...) 

-- 关闭某个模块

> Game.menu:Close(menuId) 



#### * 系统消息

-- 浮动消息--传文本

> Game.sysmsg:ToastText(txt) 

-- 浮动消息--传Msg配置的消息ID

> Game.sysmsg:ToastMsg(msgId) 




-- 状态消息--传文本

> Game.sysmsg:StateShowText(txt) 

-- 状态消息--传Msg配置的消息ID

> Game.sysmsg:StateShowMsg(msgId) 

-- 关闭状态消息

> Game.sysmsg:StateHide(msgId) 


-- 对话框消息,一个按钮

> Game.sysmsg:AlrtText(txt, callbackFun, callbackTab, buttonTxt)
> Game.sysmsg:AlrtMsg(msgId, callbackFun, callbackTab, buttonTxt)


-- 对话框消息,两个按钮

> Game.sysmsg:ConfirmText(txt, callbackFun, callbackTab, yesTxt, noTxt )
> Game.sysmsg:ConfirmMsg(msgId, callbackFun, callbackTab, yesTxt, noTxt )



#### * 模块协议处理器

-- 获取模块处理器

> Game.moduleProto.xxx


#### * 网络协议

-- 监听协议 

> Game.proto:AddCallback(S_SyncRoleInfo_12001, self.OnXXX, self )


-- 发送协议

> local msg = hero_pb.C_SyncRoleInfo_12001()

> msg.id = 1

> Game.proto:SendMsg(msg)




