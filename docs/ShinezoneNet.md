# ShinezoneNet
Shinezone网络模块

[TOC]


## NetworkMgr
* Socket的外层
* 创建Socket


| 方法名					| 描述																		|
| ---------------------	| ------------------------------------------------------------------------ 	|
| RegisterProtocol 		| 注册消息监听																	| 
| SendMsgToServer 		| 发送消息																	|
| Run 					| 每帧调用；每3帧调用一次Http Run；每200帧调用一次LXNetDLL Run;每帧调socket RunOnce	| 
| Opause  				| 挂起Socket,实际没处理														|
| OnResume 				| 恢复Socket; Socket创建连接后才有效，并会发送一次ping								| 
| OnExit  				| 释放Socket 																| 
| Reconnect  			| 重连，会重新创建Socket 														| 
| Disconnect  			| 断开连接，销毁Socket 														| 
| SetAuthInfo  			| 认证账号信息；需要账号ID、session 												| 
| SetPingInterval  		| 设置ping的间隔时间 															| 
| GetPingDeay  			| 获取ping的延迟时间 															| 
| init_msg_handler  	| 默认注册监听协议,默认服务器时间 													| 
| on_server_update_time	| 处理服务器时间消息 															| 
| on_send_msg  			| 发送协议时，如果没有注册RPC Request，就会打一条log 								| 
| on_process_msg  		| 接收协议时，如果没有注册改消息，就会打一条log 										| 



## SocketNet
#### * 状态

| 状态名词 					| 描述 				| 设置时机												| 
| ------------------------- | ----------------- | ----------------------------------------------------- |
| enum_state_nil 			| 没有创建socket	 	| 默认、Disconnect (断开连接) 								| 
| enum_state_create 		| 已经创建socket	 	| reset_connect (重新创建socket)  						| 
| enum_state_connecting 	| 正在连接中			| try_connect (尝试连接，连接没报错并且发送ping成功)  			| 
| enum_state_connected 		| 连接成功			| on_rand_factor (收到服务器随机因子) 						| 
| enum_state_authing 		| 正在认证 			| on_rand_factor（收到服务器随机因子消息， 发送认证）			| 
| enum_state_authsucceed 	| 认证成功 			| on_auth_result (收到服务器认证结果消息并且认证成功)		 	| 



#### * 创建session的地方
1. req_first_auth; 请求进行首次认证
``` csharp
string session = lxnet_manager.Md5Sum (_auth_obj.from_web_M + _auth_obj.now_server_S);
```


2. req_short_link_auth; 请求进行短链接认证
``` csharp
string session = lxnet_manager.Md5Sum(_auth_obj.now_server_S + _auth_obj.prev_server_S + _auth_obj.first_auth_string + _auth_obj.prev_auth_string);

```

### * 验证流程

```flow
st=>start: Start:>http://blog.ihaiu.com
SetAuthInfo=>operation: SetAuthInfo(accountId, session)设置账号信息
Connect=>operation: Connect(ip, prot)连接服务器,设置状态为Create
S2C_RandFactor=>condition: S2C 随机因子，并设置状态为Connected
C2S_FirstAuth=>operation: C2S 第一次验证
C2S_ReAuth=>operation: C2S 断线重连验证
S2C_AuthResult=>condition: S2C 验证结果
Disconnect=>operation: 断开连接
Run=>operation: 设置状态为AuthSuccessed
e=>end

st->SetAuthInfo->Connect->S2C_RandFactor
S2C_RandFactor(yes)->C2S_FirstAuth->S2C_AuthResult
S2C_RandFactor(no)->C2S_ReAuth->S2C_AuthResult
S2C_AuthResult(yes)->Run
S2C_AuthResult(no)->Disconnect->e

```

[验证流程](https://github.com/ihaiucom/ihaiu.UnityGameEngine/blob/zf_dev/Doc/images/shinenet_auth.svg)
![验证流程](./images/shinenet_auth.png)