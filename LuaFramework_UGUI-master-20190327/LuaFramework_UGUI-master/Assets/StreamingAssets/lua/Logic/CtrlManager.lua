require "Common/define"
require "Controller/PromptCtrl"
require "Controller/MessageCtrl"
require "Controller/FirstCtrl"
require "Controller/Login/LoginCtrl"
require "Controller/Hall/HallCtrl"
require "Controller/Hall/RankingCtrl"
require "Controller/Shop/ShopCtrl"

CtrlManager = {};
local this = CtrlManager;
local ctrlList = {};	--控制器列表--

function CtrlManager.Init()
	logWarn("CtrlManager.Init----->>>");
	ctrlList[CtrlNames.Prompt] = PromptCtrl.New();
	ctrlList[CtrlNames.Message] = MessageCtrl.New();
	ctrlList[CtrlNames.First] = FirstCtrl.New();
	ctrlList[CtrlNames.Login] = LoginCtrl.New();
	ctrlList[CtrlNames.Hall] = HallCtrl.New();
    ctrlList[CtrlNames.Ranking] = RankingCtrl.New();
    ctrlList[CtrlNames.Shop] = ShopCtrl.New();
	return this;
end

--添加控制器--
function CtrlManager.AddCtrl(ctrlName, ctrlObj)
	ctrlList[ctrlName] = ctrlObj;
end

--获取控制器--
function CtrlManager.GetCtrl(ctrlName)
	return ctrlList[ctrlName];
end

--移除控制器--
function CtrlManager.RemoveCtrl(ctrlName)
	ctrlList[ctrlName] = nil;
end

--关闭控制器--
function CtrlManager.Close()
	logWarn('CtrlManager.Close---->>>');
end