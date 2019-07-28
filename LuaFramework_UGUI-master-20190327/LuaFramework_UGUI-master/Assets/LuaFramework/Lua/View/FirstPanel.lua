local transform;
local gameObject;

FirstPanel = {};
local this = FirstPanel;

--启动事件--
function FirstPanel.Awake(obj)
    gameObject = obj;
    transform = obj.transform;

    this.InitPanel();
    logWarn("Awake lua--->>"..gameObject.name);
end

--初始化面板--
function FirstPanel.InitPanel()
    --查找关闭按钮
    this.btnClose = transform:FindChild("CloseButton").gameObject;
end

--单击事件--
function FirstPanel.OnDestroy()
    logWarn("OnDestroy---->>>");
end

