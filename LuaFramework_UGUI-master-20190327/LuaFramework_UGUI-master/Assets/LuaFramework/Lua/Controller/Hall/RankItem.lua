
RankItem = {
    --里面可以放一些属性
    name = "RankItem",
    index = -1, --索引
    obj = nil --脚本关联的对象
}

function RankItem:Awake()
    --print("RankItem Awake name = "..self.name );
end

function RankItem:Start()

    -- 设置Id
    self.obj.transform:Find("TextOrder"):GetComponent("Text").text = self.id;
    -- 设置name
    self.obj.transform:Find("TextName"):GetComponent("Text").text = self.name;
    -- 设置score
    self.obj.transform:Find("TextScore"):GetComponent("Text").text = self.score;

    UIEventEx.AddButtonClick(self.obj, function ()
        log("你点击了RankItem " .. self.name);
    end);
end

--Item点击事件
function RankItem.OnItemClick (go, selfData)

end

function RankItem:Update()

end

--创建对象
function RankItem:New(obj)
    local o = {}
    setmetatable(o, self)
    self.__index = self
    return o
end
