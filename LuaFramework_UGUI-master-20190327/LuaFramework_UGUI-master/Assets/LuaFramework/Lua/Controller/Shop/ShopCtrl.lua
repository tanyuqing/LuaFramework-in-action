
ShopCtrl = {};
local this = ShopCtrl;

local behaviour;
local transform;
local gameObject;

--构建函数--
function ShopCtrl.New()
    logWarn("ShopCtrl.New--->>");
    return this;
end

function ShopCtrl.Awake()
    logWarn("ShopCtrl.Awake--->>");
    panelMgr:CreatePanel('Shop', this.OnCreate);
end

--启动事件--
function ShopCtrl.OnCreate(obj)
    gameObject = obj;
    transform = obj.transform;

    behaviour = gameObject:GetComponent('LuaBehaviour');

    UIEventEx.AddButtonClick(ShopPanel.btnClose, function ()
        log("你点击了关闭");
        destroy(gameObject);
    end);
end


--关闭事件--
function ShopCtrl.Close()
    panelMgr:ClosePanel(CtrlNames.Shop);
end