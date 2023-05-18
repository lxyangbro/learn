require "Config.Global"

GameMain = {}

function GameMain:Start()
    print("Game Start...")
    local go = UGameObject("GO")
    go:AddComponent(typeof(UCanvas))
end

return GameMain