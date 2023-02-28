using System.IO;
//using System.Diagnostics;
using System;
using UnityEngine;
using System.Collections.Generic;
#if UNITY_ANDROID && !UNITY_EDITOR

using System.Collections;
using System.Runtime.InteropServices;
#endif

namespace bamboosdk
{
    [Serializable]
    public class OrderInfo
    {
        public string itemId;
        public string itemName;
        public string itemDesc;
        public string cpOrderId;
        public string callbackUrl;
        public string currency;
        public int coin;
        public int money;
        public int num;
        public string extra;
        public int isTest;
    }

    [Serializable]
    public class RoleInfo
    {
        public string serverId;
        public string serverName;
        public string roleId;
        public string roleName;
        public string roleLevel;
        public string vipLevel;
        public string roleBalance;
        public string roleGender;
        public string rolePower;
        public string roleCreateTime;


        public string partyId;
        public string partyName;
        public string professionId;
        public string profession;
        public string partyRoleId;
        public string partyRoleName;
        public string friendlist;
        public string appServerId;
    }

    // 错误信息
    public class ErrorMsg
    {
        public string tp;
        public string errMsg;
    }


    public class PageResult
    {
        public string tp;
    }

    public class NotchResult
    {
        public bool hasNotch;
        public int top;
        public int bottom;
        public int left;
        public int right;
    }

    // 用户信息，登录回调中使用
    public class UserInfo : ErrorMsg
    {
        public string uid;
        public string userName;
        public string token;
        public string age;
        public string extra;
        public string open_id;
        public string channel_user_id;
        public int is_guest;
    }

    // 支付信息，支付回调中使用
    public class PayResult
    {
        public string orderId;
        public string cpOrderId;
        public string extra;
        public string message;
    }

    public class BBPresetProperties
    {
        public string bundle_id;
        public string source_channel;
        public string ad_position;
        public string os;
        public string system_language;
        public int screen_width;
        public int screen_height;
        public string device_brand;
        public string cpu_name;
        public string device_model;
        public int total_memory;
        public int total_space;
        public string carrier;
        public string manufacture;
        public string network_type;
        public string os_version;
        public string app_version;
        public string distinct_id;
        public string ba_distinct_id;
        public string device_id;
        public int device_level;
        public float refresh_rate;
        public string country;
        public string timezone;
        public string channel_device_id;
        public string op_id;
        public string op_game_id;
        public string sdk_ver;
        public string timezone_str;
        public string channel_sdk_ver;
        public int is_simulator;
    }

    public class LogMessage
    {
        public string level;
        public string message;
    }



    public class BamBooSdkNative
    {
        private static BamBooSdkNative _instance;

        private Queue<LogMessage> logQueue;
        private int QUEUE_SIZE = 30;

        public static BamBooSdkNative getInstance()
        {
            if (null == _instance)
            {
                _instance = new BamBooSdkNative();
                _instance.logQueue = new Queue<LogMessage>();
            }
            return _instance;
        }

        public void setListener(BamBooSdkListener listener)
        {
#if UNITY_IOS && !UNITY_EDITOR
			string gameObjectName = listener.gameObject.name;
            BamBooSdkIOS.nativeSetListener(gameObjectName);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.setListener(listener);
#endif
        }

        public void init()
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.init();
#elif UNITY_ANDROID && !UNITY_EDITOR
            BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
            androidSupport.init();
#endif
        }

        public void exit()
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.exit();
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.exit();
#endif
        }

        public void enableFloatBall(bool enable)
        {
#if UNITY_IOS && !UNITY_EDITOR
			BamBooSdkIOS.enableFloatBall(enable);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.enableFloatBall(enable);
#endif
        }

        public void accountInherit()
        {
#if UNITY_IOS && !UNITY_EDITOR
			BamBooSdkIOS.login();
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.accountInherit();
#endif
        }

        public void login(int loginType)
        {
#if UNITY_IOS && !UNITY_EDITOR
			BamBooSdkIOS.loginWithType(loginType);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.login(loginType);
#endif
        }
        public void logout()
        {
#if UNITY_IOS && !UNITY_EDITOR
			BamBooSdkIOS.logout();
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.logout();
#endif
        }

        public void pay(OrderInfo orderInfo, RoleInfo roleInfo)
        {
#if UNITY_IOS && !UNITY_EDITOR
			BamBooSdkIOS.pay(orderInfo, roleInfo);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.pay(orderInfo, roleInfo);
#endif
        }

        public string getUid()//uid
        {
#if UNITY_IOS && !UNITY_EDITOR
			return BamBooSdkIOS.getUid();
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			return androidSupport.getUid();
#else
            return "";
#endif

        }


        public int getProcessMemory()
        {
#if UNITY_IOS && !UNITY_EDITOR
				return BamBooSdkIOS.memoryUsage();
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			return androidSupport.getProcessMemory();
#else
            return 0;
#endif

        }

        public void restartGame()
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.restartGame();
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.restartGame();
#endif
        }

        public void createRole(RoleInfo roleInfo)
        {
            updateRoleInfoWith(roleInfo, 1);
        }

        public void enterGame(RoleInfo roleInfo)
        {
            updateRoleInfoWith(roleInfo, 2);
        }

        public void updateRole(RoleInfo roleInfo)
        {
            updateRoleInfoWith(roleInfo, 3);
        }


        public void exitGame()
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.exitGame();
#elif   UNITY_ANDROID && !UNITY_EDITOR
            BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
            androidSupport.exitGame();
#endif

        }




        public void updateRoleInfoWith(RoleInfo roleInfo, int tp)
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.updateRoleInfoWith(roleInfo, tp);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.updateRoleInfo(roleInfo, tp);
#endif
        }

        public void openPage(int tp, string url)
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.openPage(tp, url);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.openPage(tp,url);
#endif
        }

        public void userCenter()
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.userCenter();
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.userCenter();
#endif
        }

        public void openAppStore()
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.openAppStore("");
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.openAppStore();
#endif
        }


        public void customServer()
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.customSever();
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.customServer();
#endif
        }

        public void querySkuDetail(string str)
        {
#if UNITY_IOS && !UNITY_EDITOR
          BamBooSdkIOS.querySkuDetail(str);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.querySkuDetail(str);
#endif
        }


        public string getBBPresetProperties()
        {
#if UNITY_IOS && !UNITY_EDITOR
            return BamBooSdkIOS.getPresetProperties();
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			return androidSupport.getBBPresetProperties();
#else
            return "";
#endif

        }

        public void setBBSuperProperties(string properties)
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.setPresetProperties(properties);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.setBBSuperProperties(properties);
#else
#endif

        }

        public void taEvent(string eventName, string properties)
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.trackAndProperties(eventName, properties);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.taEvent(eventName,properties);
#else
#endif

        }

        public void taUserSet(string properties)
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.userSet(properties);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.taUserSet(properties);
#else
#endif

        }

        public void taUserSetOnce(string properties)
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.taUserSetOnce(properties);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.taUserSetOnce(properties);
#else
#endif

        }

        public void taUserAdd(string properties)
        {
#if UNITY_IOS && !UNITY_EDITOR
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.taUserAdd(properties);
#else
#endif

        }

        public void guestUpgrade()
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.guestUpgrade();
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.guestUpgrade();
#endif
        }

        public void setLanguage(string lang)
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.setUpLanguage(lang);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.setLanguage(lang);
#endif
        }


        public void getDeviceNotch()
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.deviceNotch();
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.getDeviceNotch();
#endif
        }

        public void getExtend(string modName)
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.getExtend(modName);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.getExtend(modName);
#endif
        }

        public void getStorage(string key)
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.getStorage(key);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.getStorage(key);
#endif
        }

        public void setStorage(string key, string value)
        {
#if UNITY_IOS && !UNITY_EDITOR
            BamBooSdkIOS.setStorage(key, value);
#elif UNITY_ANDROID && !UNITY_EDITOR
			BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
			androidSupport.setStorage(key,value);
#endif
        }

        public void logReport(string level, string message)
        {
            if (level == "info")
            {
                LogMessage tmp = new LogMessage();
                tmp.level = level;
                tmp.message = message;
                logQueue.Enqueue(tmp);
                if (logQueue.Count > QUEUE_SIZE)
                {
                    logQueue.Dequeue();
                }
            }
            else
            {
                BamBooSdkJson.JSONArray jsonArr = new BamBooSdkJson.JSONArray();
                BamBooSdkJson.JSONClass node;
                foreach (LogMessage q in logQueue)
                {
                    node = new BamBooSdkJson.JSONClass();
                    node.Add("log_level", q.level);
                    node.Add("log_message", q.message);
                    jsonArr.Add(node);
                }
                logQueue.Clear();
                node = new BamBooSdkJson.JSONClass();
                node.Add("log_level", level);
                node.Add("log_message", message);
                jsonArr.Add(node);
                string json = jsonArr.ToString();
#if UNITY_IOS && !UNITY_EDITOR
                BamBooSdkIOS.logReport(level, message);
#elif UNITY_ANDROID && !UNITY_EDITOR
                BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
                androidSupport.logMulti(json);
#endif
            }
        }

        public void shared(SharedContent sharedContent)
        {
#if UNITY_IOS && !UNITY_EDITOR
#elif UNITY_ANDROID && !UNITY_EDITOR
            BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
            switch (sharedContent.getSharedType()){
                case SharedContent.SHARED_APP:
                    androidSupport.sharedApp(sharedContent);
                    break;
                case SharedContent.SHARED_LINK:
                    androidSupport.sharedLink(sharedContent);
                    break;
                case SharedContent.SHARED_PICTURE_PATH:
                    androidSupport.sharedPictureLocal(sharedContent);
                    break;
                case SharedContent.SHARED_PICTURE_URL:
                    androidSupport.sharedPictureUrl(sharedContent);
                    break;
                case SharedContent.SHARED_VIDEO:
                    androidSupport.sharedVideo(sharedContent);
                    break;
            }
#endif
        }

        public void tapCrash()
        {
#if UNITY_IOS && !UNITY_EDITOR
        BamBooSdkIOS.tapCrash();
#elif UNITY_ANDROID && !UNITY_EDITOR
            
#endif
        }

        public void registerUserNotification()
        {
#if UNITY_IOS && !UNITY_EDITOR
        BamBooSdkIOS.registerUserNotification();
#elif UNITY_ANDROID && !UNITY_EDITOR
#endif
        }
        public void showNotification(int notifyId, int delayed, string iconPath, string title, string message)
        {
#if UNITY_IOS && !UNITY_EDITOR
        BamBooSdkIOS.showNotification(title, message, notifyId, delayed);
#elif UNITY_ANDROID && !UNITY_EDITOR
        BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
        androidSupport.showNotification(notifyId, delayed, iconPath, title, message);
#endif
        }

        public void cancelNotification(int[] notifyIds)
        {
#if UNITY_IOS && !UNITY_EDITOR
        BamBooSdkIOS.cancelNotification(notifyIds);
#elif UNITY_ANDROID && !UNITY_EDITOR
        BamBooUnitySupportAndroid androidSupport = BamBooUnitySupportAndroid.getInstance();
        androidSupport.cancelNotifycation(notifyIds);
#endif
        }

        public void clearIconBadge()
        {
#if UNITY_IOS && !UNITY_EDITOR
        BamBooSdkIOS.clearIconBadge();
#elif UNITY_ANDROID && !UNITY_EDITOR
#endif
        }

        public void acceptAgreement(bool isShowAgreement) {
#if UNITY_IOS && !UNITY_EDITOR
        BamBooSdkIOS.acceptAgreement(isShowAgreement);
#elif UNITY_ANDROID && !UNITY_EDITOR
            BamBooUnitySupportAndroid.getInstance().acceptAgreement(isShowAgreement);
#endif
        }

    }

#if UNITY_ANDROID && !UNITY_EDITOR

    public class BamBooUnitySupportAndroid
    {

        AndroidJavaObject ao;

        private static BamBooUnitySupportAndroid instance;

        private BamBooUnitySupportAndroid()
        {

            AndroidJavaClass ac = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            ao = ac.GetStatic<AndroidJavaObject>("currentActivity");
        }

        public static BamBooUnitySupportAndroid getInstance()
        {
            if (instance == null)
            {
                instance = new BamBooUnitySupportAndroid();
            }

            return instance;
        }

        public void setListener(BamBooSdkListener listener)
        {
            if (listener == null)
            {
                Debug.LogError("set BamBooSdkListener error, listener is null");
                return;
            }
            var propertyInfo = listener.GetType().GetProperty("gameObject");
            if (propertyInfo == null)
            {
                return;
            }
            string gameObjectName = listener.gameObject.name;
            if (ao == null)
            {
                Debug.LogError("setListener error, current activity is null");
            }
            else
            {
                Debug.Log("setUnityGameObjectName " + gameObjectName);
                ao.Call("setUnityGameObjectName", gameObjectName);
            }
        }

        public void init()
        {
            ao.Call("requestInit");
        }

        public void exit()
        {
            ao.Call("requestExit");
        }

        public void enableFloatBall(bool enable)
        {
            ao.Call("enableFloatBall", enable);
        }

        public void accountInherit()
        {
            ao.Call("requestAccountInherit");
        }

        public void login(int loginType)
        {
            ao.Call("requestLogin", loginType);
        }

        public void logout()
        {
            ao.Call("requestLogout");
        }

        public void pay(OrderInfo orderInfo, RoleInfo roleInfo)
        {
            if (orderInfo == null)
            {
                Debug.LogError("call pay error, orderInfo is null");
                return;
            }

            ao.Call("requestPay",
                orderInfo.itemId, orderInfo.itemName,
                orderInfo.itemDesc, orderInfo.cpOrderId,
                orderInfo.callbackUrl, orderInfo.currency,
                orderInfo.coin + "", orderInfo.money + "",
                orderInfo.num + "", orderInfo.extra,
                orderInfo.isTest + "",
                roleInfo.serverId, roleInfo.serverName,
                roleInfo.roleId, roleInfo.roleName,
                roleInfo.roleLevel, roleInfo.vipLevel,
                roleInfo.roleBalance, roleInfo.partyName);
        }

        public string getUid()
        {
            return ao.Call<string>("getUid");
        }


        public int getProcessMemory()
        {
            return ao.Call<int>("getProcessMemory");
        }

        public void updateRoleInfo(RoleInfo roleInfo, int tp)
        {
            if (roleInfo.Equals(null))
            {
                Debug.LogError("updateRoleInfo is error, roleInfo is null");
                return;
            }

            string serverId = String.IsNullOrEmpty(roleInfo.serverId) ? "" : roleInfo.serverId;
            string serverName = String.IsNullOrEmpty(roleInfo.serverName) ? "" : roleInfo.serverName;

            string roleId = String.IsNullOrEmpty(roleInfo.roleId) ? "" : roleInfo.roleId;
            string roleName = String.IsNullOrEmpty(roleInfo.roleName) ? "" : roleInfo.roleName;
            string roleLevel = String.IsNullOrEmpty(roleInfo.roleLevel) ? "" : roleInfo.roleLevel;
            string vipLevel = String.IsNullOrEmpty(roleInfo.vipLevel) ? "" : roleInfo.vipLevel;
            string roleBalance = String.IsNullOrEmpty(roleInfo.roleBalance) ? "" : roleInfo.roleBalance;
            string roleGender = String.IsNullOrEmpty(roleInfo.roleGender) ? "" : roleInfo.roleGender;
            string rolePower = String.IsNullOrEmpty(roleInfo.rolePower) ? "" : roleInfo.rolePower;
            string roleCreateTime = String.IsNullOrEmpty(roleInfo.roleCreateTime) ? "" : roleInfo.roleCreateTime;

            string partyId = String.IsNullOrEmpty(roleInfo.partyId) ? "" : roleInfo.partyId;
            string partyName = String.IsNullOrEmpty(roleInfo.partyName) ? "" : roleInfo.partyName;
            string professionId = String.IsNullOrEmpty(roleInfo.professionId) ? "" : roleInfo.professionId;
            string profession = String.IsNullOrEmpty(roleInfo.profession) ? "" : roleInfo.profession;
            string partyRoleId = String.IsNullOrEmpty(roleInfo.partyRoleId) ? "" : roleInfo.partyRoleId;
            string partyRoleName = String.IsNullOrEmpty(roleInfo.partyRoleName) ? "" : roleInfo.partyRoleName;
            string friendlist = String.IsNullOrEmpty(roleInfo.friendlist) ? "" : roleInfo.friendlist;
            string appServerId = String.IsNullOrEmpty(roleInfo.appServerId) ? "" : roleInfo.appServerId;


            ao.Call("requestUpdateRole",
                serverId,
                serverName,
                roleId,
                roleName,
                roleLevel,
                vipLevel,
                roleBalance,
                roleGender,
                rolePower,
                partyId,
                partyName,
                professionId,
                profession,
                partyRoleId,
                partyRoleName,
                friendlist,
                appServerId,
                roleCreateTime,
                tp + "");
            Debug.LogWarning("updateRoleInfo executed");
        }


        public void openPage(int tp, string url)
        {
            ao.Call("openPage", tp, url);
        }

        public void restartGame()
        {
            ao.Call("requestRestartActivity");
        }

        public void guestUpgrade()
        {
            ao.Call("requestGuestUpgrade");
        }

        public void userCenter()
        {
            ao.Call("userCenter");
        }

        public void customServer()
        {
            ao.Call("customServer");
        }

        public void exitGame()
        {
            ao.Call("exitGame");
        }

        public void querySkuDetail(string properties)
        {
            ao.Call("querySkuDetail", properties);
        }

        public string getBBPresetProperties()
        {
            return ao.Call<string>("getBBPresetProperties");
        }

        public void setBBSuperProperties(string properties)
        {
            ao.Call("setBBSuperProperties", properties);
        }

        public void taEvent(string eventName, string properties)
        {
            ao.Call("taEvent", eventName, properties);
        }

        public void taUserSet(string properties)
        {
            ao.Call("taUserSet", properties);
        }

        public void taUserSetOnce(string properties)
        {
            ao.Call("taUserSetOnce", properties);
        }

        public void taUserAdd(string properties)
        {
            ao.Call("taUserAdd", properties);
        }

        public void openAppStore()
        {
            ao.Call("openAppStore");
        }

        public void setLanguage(string lang)
        {
            ao.Call("requestSetLanguage", lang);
        }

        public void getDeviceNotch()
        {
            ao.Call("requestNotch");
        }

        public void logMulti(string json)
        {
            ao.Call("logMulti", json);
        }

        public void getExtend(string modName)
        {
            ao.Call("requestExtend", modName);
        }

        public void getStorage(string key)
        {
            ao.Call("requestStorage", key);
        }


        public void setStorage(string key, string value)
        {
            ao.Call("requestSetStorage", key, value);
        }

        public void sharedApp(SharedContent sharedContent)
        {
            ao.Call("sharedApp");
        }

        public void sharedLink(SharedContent sharedContent)
        {
            ao.Call("sharedLink", sharedContent.getText(), sharedContent.getLinkContent().getUrl());
        }

        public void sharedPictureLocal(SharedContent sharedContent)
        {
            if (sharedContent == null || sharedContent.getPictureLocalList() == null)
            {
                Debug.LogError("sharedPictureLocal:参数错误");
                return;
            }
            List<PictureLocalContent> PictureLocalList = sharedContent.getPictureLocalList();
            string[] path = new string[PictureLocalList.Count];
            for (int i = 0; i < PictureLocalList.Count; i++)
            {
                path[i] = PictureLocalList[i].getPath();
            }
            string url = PictureLocalList[0].getPath();
            ao.Call("sharedPictureLocal", sharedContent.getText(), url);
        }

        public void sharedPictureUrl(SharedContent sharedContent)
        {
            List<PictureUrlContent> PictureUrlList = sharedContent.getPictureUrlList();
            string[] urls = new string[PictureUrlList.Count];
            for (int i = 0; i < PictureUrlList.Count; i++)
            {
                urls[i] = PictureUrlList[i].getUrl();
            }

            string url = PictureUrlList[0].getUrl();
            ao.Call("sharedPictureUrl", sharedContent.getText(), url);
        }

        public void sharedVideo(SharedContent sharedContent)
        {
            ao.Call("sharedVideo", sharedContent.getVideoContent().getDescription(), sharedContent.getText(), sharedContent.getVideoContent().getVideoPath());
        }


        private AndroidJavaObject javaArrayFromCS(string[] values)
        {
            AndroidJavaClass arrayClass = new AndroidJavaClass("java.lang.reflect.Array");
            AndroidJavaObject arrayObject = arrayClass.CallStatic<AndroidJavaObject>("newInstance", new AndroidJavaClass("java.lang.String"), values.Length);
            for (int i = 0; i < values.Length; ++i)
            {
                arrayClass.CallStatic("set", arrayObject, i, new AndroidJavaObject("java.lang.String", values[i]));
            }

            return arrayObject;

        }
        public void showNotification(int notifyId, int delayed, string iconPath, string title, string message)
        {
            ao.Call("showNotification", notifyId, delayed, iconPath, title, message);
        }

        public void cancelNotifycation(int[] values)
        {
            ao.Call("cancelNotification", values);
        }

        public void acceptAgreement(bool isShowAgreement)
        {
            ao.Call("acceptAgreement", isShowAgreement);
        }

    }
#endif
}

