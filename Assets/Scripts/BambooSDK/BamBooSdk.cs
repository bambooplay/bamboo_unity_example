using System;

namespace bamboosdk
{
	public class BamBooSdk
	{
		private static BamBooSdk _instance;
		
		public static BamBooSdk getInstance() {
			if( null == _instance ) {
				_instance = new BamBooSdk();
            }
			return _instance;
		}

		public void setListener(BamBooSdkListener listener)
		{
			BamBooSdkNative.getInstance ().setListener (listener);
        }

		public void reInit()
		{
			BamBooSdkNative.getInstance().init();
		}

		public void init()
        {
			BamBooSdkNative.getInstance().init();
		}

		public void exit()
        {
			BamBooSdkNative.getInstance ().exit();
        }

		public void enableFloatBall(bool enable)
        {
			BamBooSdkNative.getInstance ().enableFloatBall(enable);
        }

		public void accountInherit() {
			BamBooSdkNative.getInstance().accountInherit();
		}

		public void login ()
		{
			loginWithType(-1);
        }

		public void loginWithType(int loginType)
		{
			BamBooSdkNative.getInstance().login(loginType);
		}

		public void logout ()
		{
			BamBooSdkNative.getInstance ().logout();
        }

		public void pay (OrderInfo orderInfo, RoleInfo roleInfo)
		{
			BamBooSdkNative.getInstance ().pay(orderInfo, roleInfo);
        }

		public int getProcessMemory()
		{
			return BamBooSdkNative.getInstance().getProcessMemory();            
		}

		public string getUid()//渠道uid
		{
			return BamBooSdkNative.getInstance ().getUid();            
		}

		public void createRole(RoleInfo roleInfo){
			BamBooSdkNative.getInstance ().createRole (roleInfo);//创建角色
		}

		public void enterGame(RoleInfo roleInfo){
			BamBooSdkNative.getInstance ().enterGame (roleInfo);//开始游戏
		}

		public void updateRole(RoleInfo roleInfo){
			BamBooSdkNative.getInstance ().updateRole (roleInfo);//角色升级
		}

		public void openPage(int tp,string url)
        {
            BamBooSdkNative.getInstance().openPage(tp,url);
        }

        public void exitGame()
        {
            BamBooSdkNative.getInstance().exitGame();
        }

		public void userCenter() {
            BamBooSdkNative.getInstance().userCenter();
        }

		public void customServer() {
            BamBooSdkNative.getInstance().customServer();
        }

		public void restartGame() {
            BamBooSdkNative.getInstance().restartGame();
        }

		public void getDeviceNotch() {
            BamBooSdkNative.getInstance().getDeviceNotch();
        }

		public BBPresetProperties getBBPresetProperties() {
			string str = BamBooSdkNative.getInstance().getBBPresetProperties();
			var data = BamBooSdkJson.JSONNode.Parse(str);
			
			BBPresetProperties properties = new BBPresetProperties();
			properties.bundle_id = data["bundle_id"].Value;
			properties.os = data["os"].Value;
			properties.source_channel = data["source_channel"].Value;
			properties.ad_position = data["ad_position"].Value;
			properties.system_language = data["system_language"].Value;
			properties.screen_width = Int32.Parse(data["screen_width"].Value);
			properties.screen_height = Int32.Parse(data["screen_height"].Value);
			properties.device_model = data["device_model"].Value;
			properties.carrier = data["carrier"].Value;
			properties.manufacture = data["manufacture"].Value;
			properties.cpu_name = data["cpu_name"].Value;
			properties.device_brand = data["device_brand"].Value;
			properties.total_space =  Int32.Parse(data["total_space"].Value);
			properties.total_memory =  Int32.Parse(data["total_memory"].Value);
			properties.network_type = data["network_type"].Value;
			properties.os_version = data["os_version"].Value;
			properties.app_version = data["app_version"].Value;
			properties.distinct_id = data["distinct_id"].Value;
			properties.ba_distinct_id = data["ba_distinct_id"].Value;
			properties.device_id = data["device_id"].Value;
			properties.device_level = Int32.Parse(data["device_level"].Value);
			properties.refresh_rate = float.Parse(data["refresh_rate"].Value);
			properties.country = data["country"].Value;
			properties.timezone = data["timezone"].Value;
			properties.channel_device_id = data["channel_device_id"].Value;
			properties.op_id = data["op_id"].Value;
			properties.op_game_id = data["op_game_id"].Value;
			properties.sdk_ver = data["sdk_ver"].Value;
			properties.timezone_str = data["timezone_str"].Value;
			properties.channel_sdk_ver = data["channel_sdk_ver"].Value;
			properties.is_simulator =  Int32.Parse(data["is_simulator"].Value);

           return properties;
		}

		public void setBBSuperProperties(string properties) {
			BamBooSdkNative.getInstance().setBBSuperProperties(properties);
		}

		public void taEvent(string eventName,string properties) {
			BamBooSdkNative.getInstance().taEvent(eventName,properties);
		}

		public void taUserSet(string properties) {
			BamBooSdkNative.getInstance().taUserSet(properties);
		}

		public void taUserSetOnce(string properties) {
			BamBooSdkNative.getInstance().taUserSetOnce(properties);
		}

		public void taUserAdd(string properties) {
			BamBooSdkNative.getInstance().taUserAdd(properties);
		}
		
		public void openAppStore() {
			BamBooSdkNative.getInstance().openAppStore();
		}

		public void guestUpgrade() {
			BamBooSdkNative.getInstance().guestUpgrade();
		}

		public void querySkuDetail(string str) {
			BamBooSdkNative.getInstance().querySkuDetail(str);
		}

		public void setLanguage(string language) {
			BamBooSdkNative.getInstance().setLanguage(language);
		}

		public void logReport(string level,string msg) {
			BamBooSdkNative.getInstance().logReport(level,msg);
		}

		public void getExtend(string modName) {
			BamBooSdkNative.getInstance().getExtend(modName);
		}

		public void getStorage() {
			string key = "dk";
			BamBooSdkNative.getInstance().getStorage(key);
		}

		public void setStorage(string value) {
			string key = "dk";
			BamBooSdkNative.getInstance().setStorage(key,value);
		}

		public void shared(SharedContent sharedContent) {
			BamBooSdkNative.getInstance().shared(sharedContent);
		}

		public void acceptAgreement(bool isShowAgreement) {
			BamBooSdkNative.getInstance().acceptAgreement(isShowAgreement);
		}

		public void registerUserNotification() {
			BamBooSdkNative.getInstance().registerUserNotification();
		}
		public void showNotification(int notifyId, int delayed, string iconPath, string title, string message)
		{
			BamBooSdkNative.getInstance().showNotification(notifyId, delayed, iconPath, title, message);
		}

		public void cancelNotification(int[] notifyIds)
		{
			BamBooSdkNative.getInstance().cancelNotification(notifyIds);
		}
	}
}
