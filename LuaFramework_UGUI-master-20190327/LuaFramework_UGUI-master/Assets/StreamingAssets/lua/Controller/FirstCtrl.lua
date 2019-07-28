
FirstCtrl = {};
local this = FirstCtrl;

local behaviour;
local transform;
local gameObject;

--构建函数--
function FirstCtrl.New()
    logWarn("FirstCtrl.New--->>");
    return this;
end

function FirstCtrl.Awake()
    logWarn("FirstCtrl.Awake--->>");
    panelMgr:CreatePanel('First', this.OnCreate);
end

--启动事件--
function FirstCtrl.OnCreate(obj)
    gameObject = obj;
    transform = obj.transform;

    behaviour = gameObject:GetComponent('LuaBehaviour');
    behaviour:AddClick(FirstPanel.btnClose, function ()
        log("你点击了关闭");
    end);

    --加载prefabs.unity3d资源包
    resMgr:LoadPrefab("prefabs.unity3d", {"ImgOrc"}, function (prefabs)
        log(prefabs.Length); --输出 1
        log(prefabs[0].name) --输出 ImgOrc

        --加载兽人头像到FirstPanel下
        local go = newObject(prefabs[0]); --实例化
        go.transform:SetParent(transform); --设置FirstPanel为父对象
        go.transform.localPosition = Vector3.zero; --设置初始位置
        go.transform.localScale = Vector3.one; --设置缩放

    end);
end

--单击事件--
function FirstCtrl.OnClick(go)
    destroy(gameObject);
end

--关闭事件--
function FirstCtrl.Close()
    panelMgr:ClosePanel(CtrlNames.Message);
end