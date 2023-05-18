local Config = Config or {}
-- 调试模式：真机出包时关闭
Config.Debug = CS.UnityEngine.Application.isEditor and true or false

return Config