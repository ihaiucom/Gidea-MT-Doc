# 模块设计
主要是UI模块的设计
=======




## Module基类
* AbstractModule    ---- 模块对外接口
* AbstractView      ---- 模块视图



## Menu基类
* MenuCtl    			---- 负责模块加载、打开、关闭、销毁，关闭其他面板、层级、布局
* MenuCtlForPanel   	---- 继承自MenuCtl, 默认加载面板的
* MenuCtlForScene   	---- 继承自MenuCtl, 默认加载场景的
* MenuId				---- 模块ID 枚举
* MenuType				---- 模块类型 (面板、场景)
* MenuLayout			---- 模块布局类型 (全屏、位置居中)
* MenuCloseOtherType 	---- 关闭其他面板方式 


## 模块管理
* ModuleManager 		---- 模块管理器, 负责管理模块列表、获取指定模块
* MenuManager   		---- 菜单管理器，负责打开关闭0