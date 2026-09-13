BaseManager.cs为一个不继承Mono的单例模式基类，PoolMgr.cs继承了它，所以其并不需要挂载到场景上。
DelayRemove.cs是一个延迟销毁的脚本，请将其挂载到需要存入到缓存池的预制体中。
预制体文件请存放在Asset/Resources中*************************
BaseManager.cs is a singleton base class that doesn’t inherit from Mono, and PoolMgr.cs inherits from it, so it doesn’t need to be attached to the scene. 
DelayRemove.cs is a delayed destroy script, please attach it to the prefabs that need to be stored in the object pool. 
Please save the prefab files in Assets/Resources.
