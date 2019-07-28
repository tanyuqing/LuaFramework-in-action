
RankingCtrl = {};
local this = RankingCtrl;

local behaviour;
local transform;
local gameObject;

--构建函数--
function RankingCtrl.New()
    logWarn("RankingCtrl.New--->>");
    return this;
end

function RankingCtrl.Awake()
    logWarn("RankingCtrl.Awake--->>");
end

--启动事件--
function RankingCtrl.OnCreate(obj)
    gameObject = obj;
    transform = obj.transform;

    behaviour = gameObject:GetComponent('LuaBehaviour');
end

--单击事件--
function RankingCtrl.OnClick(go)
    destroy(gameObject);
end

--关闭事件--
function RankingCtrl.Close()
    panelMgr:ClosePanel(CtrlNames.Ranking);
end