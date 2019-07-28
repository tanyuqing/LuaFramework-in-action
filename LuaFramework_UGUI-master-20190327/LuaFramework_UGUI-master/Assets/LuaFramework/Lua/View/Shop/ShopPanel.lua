local transform;
local gameObject;

ShopPanel = {};
local this = ShopPanel;

--启动事件--
function ShopPanel.Awake(obj)
    gameObject = obj;
    transform = obj.transform;

    this.InitPanel();
    logWarn("Awake lua--->>"..gameObject.name);
end

--初始化面板--
function ShopPanel.InitPanel()
    --查找关闭按钮
    ShopPanel.btnClose = transform:FindChild("BtnClose").gameObject;

    ShopPanel.shopTitle = transform:FindChild("Text"):GetComponent("Text");

    ShopPanel.shopTitle.text = "热更商店";
end

--单击事件--
function ShopPanel.OnDestroy()
    logWarn("OnDestroy---->>>");
end

