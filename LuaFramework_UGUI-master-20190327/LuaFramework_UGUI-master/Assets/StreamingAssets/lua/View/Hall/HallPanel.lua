local transform;
local gameObject;

HallPanel = {};
local this = HallPanel;

--启动事件--
function HallPanel.Awake(obj)
    gameObject = obj;
    transform = obj.transform;

    this.InitPanel();
    logWarn("Awake lua--->>"..gameObject.name);
end

--初始化面板--
function HallPanel.InitPanel()
    logWarn("我是HallPanel，我被加载了.");

    --排行榜按钮
    HallPanel.rankingBtn = transform:FindChild("BtnRanking").gameObject;

    --排行榜面板
    HallPanel.rankingPanel = transform.parent:Find("RankingPanel");

    --商店按钮
    HallPanel.shopBtn = transform:FindChild("BtnShop").gameObject;

    --调用Ctrl中panel创建完成时的方法
    HallCtrl.OnCreate(gameObject);
end

function HallPanel.OnDestroy()
    logWarn("OnDestroy---->>>");
end

