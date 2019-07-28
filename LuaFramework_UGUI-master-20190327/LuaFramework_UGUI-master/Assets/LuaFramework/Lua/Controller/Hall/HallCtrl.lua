
HallCtrl = {};
local this = HallCtrl;

local behaviour;
local transform;
local gameObject;

--构建函数--
function HallCtrl.New()
    logWarn("HallCtrl.New--->>");
    return this;
end

function HallCtrl.Awake()
    logWarn("HallCtrl.Awake--->>");

    logWarn("我是HallCtrl，我被加载了.");
end


--启动事件--
function HallCtrl.OnCreate(obj)
    gameObject = obj;
    transform = obj.transform;

    UIEventEx.AddButtonClick(HallPanel.rankingBtn, function ()
        log("你点击了排行榜按钮");

        HallPanel.rankingPanel.gameObject:SetActive (true);
    end);

    UIEventEx.AddButtonClick(HallPanel.shopBtn, function ()
        log("你点击了商店按钮");

        --实例化商店面板
        local shopCtrl = CtrlManager.GetCtrl(CtrlNames.Shop);
        shopCtrl:Awake();
    end);
end

--单击事件--
function HallCtrl.OnClick(go)
    destroy(gameObject);
end

--关闭事件--
function HallCtrl.Close()
    panelMgr:ClosePanel(CtrlNames.Hall);
end