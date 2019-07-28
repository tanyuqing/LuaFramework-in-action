local transform;
local gameObject;

require("Controller/Hall/RankItem")

RankingPanel = {};
local this = RankingPanel;

--启动事件--
function RankingPanel.Awake(obj)
    gameObject = obj;
    transform = obj.transform;

    this.InitPanel();
    logWarn("=========Awake lua--->>"..gameObject.name);

    --UpdateBeat:Add(Update, self);
    --FixedUpdateBeat:Add(FixedUpdate, self);
    --LateUpdateBeat:Add(LateUpdate, self);
end


--排行榜项数据
local rankItemData = {
    {id = 1, name = "张三1", score = 700},
    {id = 2, name = "张三2", score = 500},
    {id = 3, name = "张三3", score = 300},
    {id = 4, name = "张三4", score = 200}
}

--初始化面板--
function RankingPanel.InitPanel()

    local rankList = transform:FindChild("RankList");
    for i = 1, rankList.childCount do

        local go = rankList:GetChild(i - 1).gameObject;
        log(go.name);

        local item = LuaComponent.Add(go, RankItem);
        item.name = rankItemData[i].name;
        item.index = i;
        item.obj = go;

        item.id = rankItemData[i].id;
        item.score = rankItemData[i].score;
    end

    RankingCtrl.OnCreate(gameObject);
end

--单击事件--
function RankingPanel.OnDestroy()
    logWarn("OnDestroy---->>>");
end

