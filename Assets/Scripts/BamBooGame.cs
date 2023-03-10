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
	//下拉列表中的商品ID
	private List<string> productIdList = new List<string>();

	private Dictionary<uint, long> _debugMsgDict;
	// Start is called before the first frame update
	void Start()
	{
		inputObj = GameObject.Find("Canvas/input");
		outputObj = GameObject.Find("PanelOutput");
		setDropdownProductId();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnDestroy()
	{
		Debug.Log("exit");
		int []intArr = new int[] {1, 2};
		//Debug.LogError("" + intArr[5]);
	}

	public void tapInit()
	{
		showOutput("tapInit");
		BamBooSdk.getInstance().setListener(this);
		BamBooSdk.getInstance().init();

		Toggle floatBallToggle = GameObject.Find("ToggleFloatBool").GetComponent<Toggle>();
		BamBooSdk.getInstance().enableFloatBall(floatBallToggle.enabled);
	}

	public void acceptAgreement()
	{
		Debug.LogError("acceptAgreement");
		Toggle agreementToggle = GameObject.Find("ToggleAcceptAgreement").GetComponent<Toggle>();
		BamBooSdk.getInstance().acceptAgreement(agreementToggle.enabled);
	}

	public void langedChanged(int index)
	{
		Debug.LogError("langedChanged " + index);
		string[] languageArr = { "cn", "tw", "en", "thai", "indo"};
		BamBooSdk.getInstance().setLanguage(languageArr[index]);
	}

	public void getExtendChanged(int index)
	{
		Debug.LogError("getExtendChanged " + index);
		string[] extendArr = { "cpu_temperature"};
		BamBooSdk.getInstance().getExtend(extendArr[index]);
	}

	public void tapLogin()
	{
		showOutput("taplogin");
		BamBooSdk.getInstance().login();
	}

	public void tapLogout()
	{
		showOutput("tapLogout");
		BamBooSdk.getInstance().logout();
	}


	public void tapExit()
	{
		showOutput("tapExit");
		BamBooSdk.getInstance().exit();
	}


	public void tapUserCenter()
	{
		showOutput("tapUserCenter");
		BamBooSdk.getInstance().userCenter();
	}

	public void tapGuestUpdate()
	{
		showOutput("tapGuestUpdate");
		BamBooSdk.getInstance().guestUpgrade();
	}


	public void tapCreateRole()
	{
		showOutput("tapCreateRole");
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
		showOutput("tapEnterGame");
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
		showOutput("tapUpdateRole");
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
		showOutput("开始支付");
		//获取商品Id
		Dropdown dropdown = GameObject.Find("DropdownProductId").GetComponent<Dropdown>();
		Debug.LogError(" dropdown.value " + dropdown.value);
		string productId = productIdList[dropdown.value];

		//获取商品价格
		InputField inputFieldMoney = GameObject.Find("InputFieldOrderMoney").GetComponent<InputField>();
		if (inputFieldMoney.text == null || inputFieldMoney.text == "")
		{
			inputFieldMoney.text = "1";
		}
		int money = int.Parse(inputFieldMoney.text);


		var num = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;

		OrderInfo orderInfo = new OrderInfo();
		orderInfo.cpOrderId = num.ToString();
		orderInfo.itemId = productId;
		orderInfo.itemName = "TestProductName";
		orderInfo.itemDesc = "TestProductDescribe";
		orderInfo.extra = "TestExtra";
		orderInfo.coin = 1;
		orderInfo.money = money;
		orderInfo.num = 1;
		orderInfo.isTest = 1;

		RoleInfo roleInfo = new RoleInfo();
		roleInfo.roleId = this.uid;
		roleInfo.roleBalance = "0";
		roleInfo.roleLevel = "1";
		roleInfo.roleName = "TestRoleName";
		roleInfo.partyName = "TestPartyName";
		roleInfo.serverId = "1";
		roleInfo.serverName = "TestServiceName";
		roleInfo.vipLevel = "1";
		BamBooSdk.getInstance().pay(orderInfo, roleInfo);
	}



	public void tapBBPresetProperties()
	{
		showOutput("tapBBPresetProperties");
		BBPresetProperties p = BamBooSdk.getInstance().getBBPresetProperties();
		showOutputTitle("getBBPresetProperties", p);
	}

	public void tapSetBBSuperProperties()
	{
		showOutput("tapSetBBSuperProperties");
		BamBooSdk.getInstance().setBBSuperProperties("{\"server_id\":\"1001\"}");
	}

	public void tapEvent()
	{
		showOutput("tapEvent");
		BamBooSdk.getInstance().taEvent("ad_event", "{\"id\":1}");
	}

	public void tapUserSet()
	{
		showOutput("tapUserSet");
		BamBooSdk.getInstance().taUserSet("{\"id\":1}");
	}


	public void tapNotch()
	{
		showOutput("tapNotch");
		BamBooSdk.getInstance().getDeviceNotch();
	}

	public void tapOpenPage()
	{
		showOutput("tapOpenPage");
		BamBooSdk.getInstance().openPage(1, "https://www.qq.com");
	}

	public void tapMemory()
	{
		showOutput("tapMemory");
		int memory = BamBooSdk.getInstance().getProcessMemory();
		showOutput("msg: " + memory);
	}

	public void tapRestartGame()
	{
		showOutput("tapRestartGame");
		BamBooSdk.getInstance().restartGame();
	}

	public void openAppStore()
	{
		showOutput("openAppStore");
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
		showOutput("tapLogReport");
		BamBooSdk.getInstance().logReport("info", "hiadmin");
		BamBooSdk.getInstance().logReport("error", "error msg");
	}


	public void tapGetExtend()
	{
		showOutput("tapGetExtend");
		BamBooSdk.getInstance().getExtend("cpu_temperature");
	}

	public void tapQuerySku()
	{
		showOutput("tapQuerySku");
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
		showOutput("\n登录成功 \n" + Dumper.DumpAsString(userInfo) + "\n");
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
		showOutput("\n切换账号成功 \n" + Dumper.DumpAsString(userInfo) + "\n");
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
		showOutput("OpenPage成功 \n" + Dumper.DumpAsString(pageResult) + "\n");
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
		showOutput("ExtendSuccess  Name：" + modName + "\n" + json + "\n");
	}

	public override void onExtendFailed(string modName, ErrorMsg msg)
	{
		showOutputTitle("onExtendFailed", modName + ":" + msg.errMsg);
	}

	public override void onPaySuccess(PayResult payResult)
	{
		showOutput("\n支付成功 \n" + Dumper.DumpAsString(payResult) + "\n");
	}

	public override void onPayFailed(PayResult payResult)
	{
		showOutput("\n支付失败 \n" + Dumper.DumpAsString(payResult) + "\n");
	}

	public override void onPayCancel(PayResult payResult)
	{
		showOutput("\n支付取消 \n" + Dumper.DumpAsString(payResult) + "\n");
	}

	public override void onNotch(NotchResult result)
	{
		showOutput("\n屏幕安全边界: \n" + Dumper.DumpAsString(result) + "\n");
	}


	public override void onSucceed(string infos)
	{
		showOutput("onSucceed: \n" + Dumper.DumpAsString(infos) + "\n");
	}

	public override void onFailed(string message)
	{
		showOutput("onFailed: \n" + Dumper.DumpAsString(message) + "\n");
	}

	public override void onSkuQueryDetailSuccess(string message)
	{
		showOutput("\n商品信息查询成功: \n" + Dumper.DumpAsString(message) + "\n");
	}

	public override void onSkuQueryDetailFailed( ErrorMsg msg)
	{
		showOutput("商品信息查询失败: \n" + Dumper.DumpAsString(msg) + "\n");
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
		showOutput("收到归因数据: \n" + msg + "\n");
	}

	public override void onNotificationToken(string fcmToken)
	{
		showOutput("NotificationToken: " + fcmToken + "\n");
	}

	public override void onLocalNotificationClickSuccess(string notifyData)
	{
		showOutput("收到点击通知数据: \n" + notifyData + "\n");
	}

	public override void acceptAgreement(bool isAccept)
	{
		showOutput("acceptAgreement:" + isAccept);

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

	void showOutputTitle(string title, object t)
	{
		showOutput(title + ":" + Dumper.DumpAsString(t));
	}

	void showOutput(string message)
	{
		Text outputObj = GameObject.Find("TextOutput").GetComponent<Text>();
		outputObj.text += message += "\r\n";
		Debug.Log(message);
	}


	void showLog(string title, string message)
	{
		Debug.Log("title: " + title + ", message: " + message);
	}


	public void toggleFloatBallChange(bool change)
	{
		Debug.LogError("toggleFloatBallChange " + change);
		BamBooSdk.getInstance().enableFloatBall(change);
	}

	//根据包名设置不同的商品
	private void setDropdownProductId()
	{
		
		string packageName = Application.identifier;
		//DK项目
		if ("com.bamboogame.leaf".Equals(packageName))
		{
			productIdList.Add("com.xinxiang.dk.normal.6");
			productIdList.Add("com.xinxiang.dk.normal.648");
			productIdList.Add("com.xinxiang.dk.normal.30");
			productIdList.Add("com.xinxiang.dk.normal.128");

		}
		else if ("com.XJWL.SSmetaverse".Equals(packageName))
		{
			//炫稷项目
			productIdList.Add("com.xjwl.ssmetaverse.9");
			productIdList.Add("com.xjwl.ssmetaverse.7");
			productIdList.Add("com.manhuang.tk.2");
			productIdList.Add("com.xjwl.ssmetaverse.10");

		}
		else if ("com.bamboogame.xzthm".Equals(packageName)) {
			//仙宗港澳台
			productIdList.Add("com.bamboogamexzthm.gp.60");
			productIdList.Add("com.bamboogamexzthm.gp.1280");
			productIdList.Add("com.bamboogamexzthm.gp.2560");
			productIdList.Add("com.bamboogamexzthm.gp.680");
		}
		else if ("com.bamboogame.xzsea".Equals(packageName)) {
			//仙宗新马
			productIdList.Add("com.bamboogamexzsm.gp.1020");
			productIdList.Add("com.bamboogamexzsm.gp.4560");
			productIdList.Add("com.bamboogamexzsm.gp.5880");
			productIdList.Add("com.bamboogamexzsm.gp.monthlycard");
		}
		Dropdown dropdown = GameObject.Find("DropdownProductId").GetComponent<Dropdown>();
		Dropdown.OptionData tempData;
		for (int i = 0; i < productIdList.Count; i++)
		{
			tempData = new Dropdown.OptionData();
			tempData.text = productIdList[i];
			dropdown.options.Add(tempData);
		}
	}
}
