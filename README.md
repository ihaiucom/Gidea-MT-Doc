# ihaiu.UnityGameEngine
Unity游戏框架
=======




## 目录结构
### UnityGame                              ---- 框架顶层目录
    |__ Assets                             ---- Unity项目资源目录
        |__ EncryptMonoDll                  ---- Dll加密（采用il2cpp则无需使用）
        |__ XLua                            ---- xLua插件
        |__ Plugins                         ---- SDK插件
        |__ StreamingAssets                 ---- Unity存放携带打包资源目录
        |__ Game                 			---- 游戏主要资源存放目录
        |__ GameArt                 		---- 游戏美术资源存放目录(不会动态加载的资源)
        |__ GameFrame                 		---- 游戏框架库                          
    |__ Doc                                 ---- 框架相关文档
    |__ Tools                               ---- 框架相关外部工具（非Unity代码）


### Assets/GameFrame                    	---- 游戏框架库 
    |__ mLog                            	---- 日志
    |__ mAsset                             	---- 资源管理
    |__ mConfig                            	---- 配置
    |__ mProtobuff                          ---- Protobuf
    |__ mNetworkSocket                      ---- 网络Socket
    |__ mNetworkHttp                        ---- 网络Http
    |__ mLoader                            	---- 加载
    |__ mMenu                            	---- 模块管理
    |__ mMoudle                            	---- 模块基类
    |__ mSetting                            ---- 设置
    |__ mUnityComponent                     ---- Unity扩展组件
    |__ mUtil                          		---- 工具类




### Assets/Game                    		---- 游戏主要资源存放目录 
    |__ Scenes                            	---- 入口场景
    |__ Resources                           ---- 动态加载资源目录	(不会打包AssetBundle)
    |__ MResources                          ---- 动态加载资源目录	(将会打包AssetBundle)
    |__ Config                            	---- 配置               (将会打包AssetBundle)
    |__ Lua                            		---- 游戏Lua代码  			(将会打包AssetBundle)
    |__ Scripts                            	---- 游戏C#代码
    |__ Editor                             	---- 编辑器代码




### Assets/Game/Scripts                  ---- 游戏C#代码
    |__ Games                            	---- 游戏门面类目录
    |__ GameGlobal                          ---- 游戏全局类目录
    |__ ConfigReader                        ---- 配置数据结构和读取器
    |__ Settings                          	---- 游戏设置
    |__ User                          		---- 玩家
    |__ War                          		---- 战斗
    |__ Module_XXX                        	---- 如果用C#写UI模块，文件夹名就这样如 Module_Login



### Assets/Game/MResources               ---- 动态加载资源目录 	(将会打包AssetBundle)
    |__ Fonts                            	---- 字体
    |__ Shaders                            	---- Shader
    |__ Materials                           ---- 材质
    |__ Sounds                            	---- 音频文件
    |__ SceneMap                            ---- 关卡地图场景
    |__ ImageSprites                        ---- Sprite类型图片
    |__ ImageTextures                       ---- 贴图类型图片
    |__ PrefabFx                            ---- 预设-特效
    |__ PrefabUI                            ---- 预设-UI
    |__ PrefabUnit                          ---- 预设-单位
    |__ PrefabWar                           ---- 预设-战斗相关的






### Assets/GameArt               		---- 游戏美术资源存放目录(不会动态加载的资源)
    |__ CommonMaterial                      ---- 公共-材质库
    |__ CommonSprite                      	---- 公共-Sprite类型图片
    |__ CommonTexture                      	---- 公共-Texture类型图片
    |__ FxTexture                      		---- 特效-贴图库
    |__ FxMaterial                          ---- 特效-材质
    |__ FxPrefabMap                         ---- 特效-预设零件-地图
    |__ FxPrefabUI                          ---- 特效-预设零件-UI
    |__ FxPrefabUnity                       ---- 特效-预设零件-单位
    |__ MapPrefab                           ---- 地图-预设零件库
    |__ MapModel                         	---- 地图-模型库
    |__ MapMaterial                         ---- 地图-材质
    |__ UIPrefab                         	---- UI-预设组件库
    |__ UISprite                         	---- UI-Sprite类型图片
    |__ UITexture                         	---- UI-Texture类型图片
    |__ Unit                         		---- 单位






---------------------


## 美术要关心的目录

* Assets/GameArt               		---- 游戏美术资源存放目录, 生成过程中的材料		(不会动态加载的资源)

* Assets/Game/MResources             ---- 动态加载资源目录, 成品 					(将会打包AssetBundle)





## 策划要关系的目录

*  Assets/Game/Config  					---- 配置目录

*  Assets/Game/MResources/ImageSprites	---- 图标目录

*  Assets/Game/MResources/Sounds			---- 声音目录

*  Assets/Game/MResources/PrefabFx		---- 特效目录

*  Assets/Game/MResources/PrefabUnit		---- 单位目录

*  Assets/Game/MResources/SceneMap		---- 关卡地图场景目录

