using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using bamboosdk;
using System;
using System.Threading;

public class BamBooGame : BamBooSdkListener
{
	private GameObject inputObj;
	private GameObject outputObj;
	private string uid = "";

	private Dictionary<uint, long> _debugMsgDict;
	// Start is called before the first frame update
	void Start()
	{
		inputObj = GameObject.Find("Canvas/input");
		outputObj = GameObject.Find("Canvas/output");
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnDestroy()
	{
		Debug.Log("exit");
		int []intArr = new int[] {1, 2};
		Debug.LogError("" + intArr[5]);
	}

	public void tapInit()
	{
		showInput("tapInit");
		BamBooSdk.getInstance().setListener(this);
		BamBooSdk.getInstance().init();
	}

	public void tapLogin()
	{
		showInput("taplogin");
		BamBooSdk.getInstance().login();
	}

	public void tapLogout()
	{
		showInput("tapLogout");
		BamBooSdk.getInstance().logout();
	}


	public void tapExit()
	{
		showInput("tapExit");
		BamBooSdk.getInstance().exit();
	}


	public void tapUserCenter()
	{
		showInput("tapUserCenter");
		BamBooSdk.getInstance().userCenter();
	}

	public void tapGuestUpdate()
	{
		showInput("tapGuestUpdate");
		BamBooSdk.getInstance().guestUpgrade();
	}


	public void tapCreateRole()
	{
		showInput("tapCreateRole");
		RoleInfo roleInfo = new RoleInfo();
		roleInfo.roleId = this.uid;
		roleInfo.roleBalance = "0";
		roleInfo.roleLevel = "1";
		roleInfo.roleName = "钱多多";
		roleInfo.partyName = "同济会";
		roleInfo.serverId = "1";
		roleInfo.serverName = "火星服务器";
		roleInfo.vipLevel = "1";
		BamBooSdk.getInstance().createRole(roleInfo);
	}

	public void tapEnterGame()
	{
		showInput("tapEnterGame");
		RoleInfo roleInfo = new RoleInfo();
		roleInfo.roleId = this.uid;
		roleInfo.roleBalance = "0";
		roleInfo.roleLevel = "1";
		roleInfo.roleName = "钱多多";
		roleInfo.partyName = "同济会";
		roleInfo.serverId = "1";
		roleInfo.serverName = "火星服务器";
		roleInfo.vipLevel = "1";
		BamBooSdk.getInstance().enterGame(roleInfo);
	}

	public void tapUpdateRole()
	{
		showInput("tapUpdateRole");
		RoleInfo roleInfo = new RoleInfo();
		roleInfo.roleId = this.uid;
		roleInfo.roleBalance = "0";
		roleInfo.roleLevel = "1";
		roleInfo.roleName = "钱多多";
		roleInfo.partyName = "同济会";
		roleInfo.serverId = "1";
		roleInfo.serverName = "火星服务器";
		roleInfo.vipLevel = "1";
		BamBooSdk.getInstance().updateRole(roleInfo);
	}


	public void tapPay()
	{
		showInput("tapPay");
		OrderInfo orderInfo = new OrderInfo();
		RoleInfo roleInfo = new RoleInfo();

		orderInfo.cpOrderId = getOrderId();
		orderInfo.itemId = "com.bamboogamexzsm.gp.1020";
		orderInfo.itemName = "勾玉";
		orderInfo.itemDesc = "10个勾玉";
		orderInfo.extra = "extparma";
		orderInfo.coin = 1;
		orderInfo.money = 99;
		orderInfo.num = 1;
		orderInfo.isTest = 1;
		roleInfo.roleId = this.uid;
		roleInfo.roleBalance = "0";
		roleInfo.roleLevel = "1";
		roleInfo.roleName = "钱多多";
		roleInfo.partyName = "同济会";
		roleInfo.serverId = "1";
		roleInfo.serverName = "火星服务器";
		roleInfo.vipLevel = "1";
		BamBooSdk.getInstance().pay(orderInfo, roleInfo);
	}



	public void tapBBPresetProperties()
	{
		showInput("tapBBPresetProperties");
		BBPresetProperties p = BamBooSdk.getInstance().getBBPresetProperties();
		showOutputTitle("getBBPresetProperties", p);
	}

	public void tapSetBBSuperProperties()
	{
		showInput("tapSetBBSuperProperties");
		BamBooSdk.getInstance().setBBSuperProperties("{\"server_id\":\"1001\"}");
	}

	public void tapEvent()
	{
		showInput("tapEvent");
		BamBooSdk.getInstance().taEvent("ad_event", "{\"id\":1}");
	}

	public void tapUserSet()
	{
		showInput("tapUserSet");
		BamBooSdk.getInstance().taUserSet("{\"id\":1}");
	}


	public void tapNotch()
	{
		showInput("tapNotch");
		BamBooSdk.getInstance().getDeviceNotch();
	}

	public void tapOpenPage()
	{
		showInput("tapOpenPage");
		BamBooSdk.getInstance().openPage(1, "https://www.qq.com");
	}

	public void tapMemory()
	{
		showInput("tapMemory");
		int memory = BamBooSdk.getInstance().getProcessMemory();
		showOutput("msg: " + memory);
	}

	public void tapRestartGame()
	{
		showInput("tapRestartGame");
		BamBooSdk.getInstance().restartGame();
	}

	public void openAppStore()
	{
		showInput("openAppStore");
		BamBooSdk.getInstance().openAppStore();
	}


	public void tapSetLanguage()
	{
		string lang = inputObj.GetComponent<InputField>().text;
		Debug.Log(lang);
		BamBooSdk.getInstance().setLanguage(lang);
	}


	public void tapLogReport()
	{
		showInput("tapLogReport");
		BamBooSdk.getInstance().logReport("info", "hiadmin");
		BamBooSdk.getInstance().logReport("error", "error msg");
	}


	public void tapGetExtend()
	{
		showInput("tapGetExtend");
		BamBooSdk.getInstance().getExtend("cpu_temperature");
	}

	public void tapQuerySku()
	{
		showInput("tapQuerySku");
		BamBooSdk.getInstance().querySkuDetail("com.bamboogamexzsm.gp.60,com.bamboogamexzsm.gp.5880");
	}

	public void tapCustomServer()
	{
		BamBooSdk.getInstance().customServer();
	}

	public void sharedApp()
	{
		SharedContent sharedContent = SharedContent.newBuilder().sharedApp().build();
		BamBooSdk.getInstance().shared(sharedContent);
	}

	public void sharedLink()
	{
		LinkContent linkContent = new LinkContent();
		linkContent.setUrl("https://www.zhuziplay.com/");

		SharedContent sharedContent = SharedContent.newBuilder()
		.setText("分享竹子的官网")
		.shareLink(linkContent)
		.build();

		BamBooSdk.getInstance().shared(sharedContent);
	}

	public void sharedPicuterLocal()
	{
		PictureLocalContent content = new PictureLocalContent();
		content.setPath("/sdcard/aa.png");

		SharedContent sharedContent = SharedContent.newBuilder()
		.setText("分享本地图片")
		.addPictureLocal(content)
		.build();

		BamBooSdk.getInstance().shared(sharedContent);
	}

	public void sharedPicuterUrl()
	{
		PictureUrlContent content = new PictureUrlContent();
		content.setUrl("https://static.zhuziplay.com/office/image/cjua12psi0aoiptstv.png");

		SharedContent sharedContent = SharedContent.newBuilder()
		.setText("分享网络图片")
		.addPictureUrl(content)
		.build();

		BamBooSdk.getInstance().shared(sharedContent);
	}

	public void sharedVideo()
	{
		VideoContent videoContent = new VideoContent();
		videoContent.setDescription("Video Description");
		videoContent.setVideoPath("sdcard/aa.mp4");

		SharedContent sharedContent = SharedContent.newBuilder()
		.setText("分享视频")
		.addVideo(videoContent)
		.build();

		BamBooSdk.getInstance().shared(sharedContent);
	}


    public void guestLogin() {
		BamBooSdk.getInstance().loginWithType(3);
	}

	public void FacebookLogin()
	{
		BamBooSdk.getInstance().loginWithType(2);
	}

	public void GoogleLogin()
	{
		BamBooSdk.getInstance().loginWithType(1);
	}

	public void EmailLogin()
	{
		BamBooSdk.getInstance().loginWithType(4);
	}

	public void tapAccountInherit()
	{
				showInput("tapAccountInherit");
		BamBooSdk.getInstance().accountInherit();
	}

	public void showNotification()
	{

		BamBooSdk.getInstance().showNotification(1212, 5, "/data/data/com.bamboogame.dk.mr.en/icon.png", "title", "Message");
	}

	public void cancelNotification()
	{
		BamBooSdk.getInstance().cancelNotification(new int[] { 1212 });
	}

	//callback
	public override void onInitSuccess()
	{
		showOutput("onInitSuccess ");
	}

	public override void onInitFailed(ErrorMsg msg)
	{
		showOutputTitle("onInitFailed ", msg);
	}

	public override void onLoginSuccess(UserInfo userInfo)
	{
		this.uid = userInfo.uid;
		showOutputTitle("onLoginSuccess", userInfo);
	}

	public override void onLoginFailed(ErrorMsg errMsg)
	{
		showOutputTitle("onLoginFailed", errMsg);
	}

	public override void onGuestUpgradeSuccess()
	{

		showOutput("onGuestUpgradeSuccess");
	}

	public override void onGuestUpgradeFailed(ErrorMsg errMsg)
	{
		showOutputTitle("onGuestUpgradeFailed", errMsg);
	}


	public override void onLogoutSuccess()
	{
		showOutput("onLogoutSuccess");
	}

	public override void onLogoutFailed()
	{
		showOutput("onLogoutFailed");
	}


	public override void onSwitchAccountSuccess(UserInfo userInfo)
	{
		//切换账号成功，清除原来的角色信息，使用获取到新的用户信息，回到进入游戏的界面，不需要再次调登录
		showOutputTitle("onSwitchAccountSuccess", userInfo);
	}


	public override void onExitSuccess()
	{
		showOutput("onExitSuccess");
		Application.Quit();
	}

	public override void onExitFailed()
	{
		showOutput("onExitFailed");
	}


	public override void onStorageSuccess(string data)
	{
		showOutputTitle("onStorageSuccess", data);
	}

	public override void onStorageFailed(ErrorMsg errMsg)
	{
		showOutputTitle("onStorageFailed", errMsg);
	}

	public override void onOpenPageSuccess()
	{
		showOutput("onOpenPageSuccess");
	}

	public override void onOpenPageComplete(PageResult pageResult)
	{
		showOutputTitle("onOpenPageComplete", pageResult);
	}

	public override void onOpenPageFailed(ErrorMsg errMsg)
	{
		showOutputTitle("onStorageFailed", errMsg);
	}


	public override void onBackDownSuccess()
	{
		showOutput("onBackDownSuccess");
		//do exit
	}

	public override void onExtendSuccess(string modName, string json)
	{
		showOutputTitle("onExtendSuccess", modName + ":" + json);
		// cpu_temperature","{\"cpu_temperature\":"+tmpVal+"}"
	}

	public override void onExtendFailed(string modName, ErrorMsg msg)
	{
		showOutputTitle("onExtendFailed", modName + ":" + msg.errMsg);
	}

	public override void onPaySuccess(PayResult payResult)
	{
		showOutputTitle("onPaySuccess", payResult);
	}

	public override void onPayFailed(PayResult payResult)
	{
		showOutputTitle("onPayFailed", payResult);
	}

	public override void onPayCancel(PayResult payResult)
	{
		showOutputTitle("onPayCancel", payResult);
	}

	public override void onNotch(NotchResult result)
	{
		showOutputTitle("onNotch", result);
	}


	public override void onSucceed(string infos)
	{
		showOutputTitle("onSucceed", infos);
	}

	public override void onFailed(string message)
	{
		showOutputTitle("onFailed", message);
	}

	public override void onSkuQueryDetailSuccess(string message)
	{
		showOutputTitle("onSkuQueryDetailSuccess", message);
	}

	public override void onSkuQueryDetailFailed( ErrorMsg msg)
	{
		showOutputTitle("onSkuQueryDetailFailed", msg.errMsg);
	}


	public override void onSharedSuccess()
	{
		showOutputTitle("onSharedSuccess", "");
	}

	public override void onSharedCancel()
	{
		showOutputTitle("onSharedCancel", "");
	}

	public override void onSharedFail(int code, string msg)
	{
		showOutputTitle("onSharedFail", msg);
	}

	public override void onReferrer( string msg)
	{
		showOutputTitle("onReferrer", msg);
	}


	private string getOrderId()
	{
		var num = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
		return num.ToString();
	}


	void OnApplicationPause(bool pauseStatus)
	{
		var t = pauseStatus ? 1 : 0;
		showLog("OnApplicationPause", "msg: " + t);
	}

	void OnApplicationFocus(bool pauseStatus)
	{
		var t = pauseStatus ? 1 : 0;
		showLog("OnApplicationFocus", "msg: " + t);
	}

	void OnApplicationQuit()
	{
		showLog("OnApplicationQuit", "msg: ");
	}

	void showInput(string message)
	{
		inputObj.GetComponent<InputField>().text = message;
		Debug.Log(message);
	}

	void showOutputTitle(string title, object t)
	{
		showOutput(title + ":" + Dumper.DumpAsString(t));
	}

	void showOutput(string message)
	{
		outputObj.GetComponent<InputField>().text = message;
		Debug.Log(message);
	}


	void showLog(string title, string message)
	{
		Debug.Log("title: " + title + ", message: " + message);
	}
}
