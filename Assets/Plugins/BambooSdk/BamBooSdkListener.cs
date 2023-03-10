using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace bamboosdk
{

    public abstract class BamBooSdkListener : MonoBehaviour
    {
        //callback
		public abstract void onInitSuccess();

		public abstract void onInitFailed(ErrorMsg message);

        public abstract void onLoginSuccess(UserInfo userInfo);

        public abstract void onLoginFailed(ErrorMsg errMsg);

		public abstract void onSwitchAccountSuccess(UserInfo userInfo);

        public abstract void onLogoutSuccess();

        public abstract void onLogoutFailed();

        public abstract void onOpenPageSuccess();

         public abstract void onOpenPageComplete(PageResult pageResult);

        public abstract void onOpenPageFailed(ErrorMsg errMsg);

        public abstract void onGuestUpgradeSuccess();

        public abstract void onGuestUpgradeFailed(ErrorMsg errMsg);

        public abstract void onBackDownSuccess();

        public abstract void onSucceed(string infos);
        public abstract void onFailed(string message);


        public abstract void onPaySuccess(PayResult payResult);

        public abstract void onPayFailed(PayResult payResult);

        public abstract void onPayCancel(PayResult payResult);

        public abstract void onNotch(NotchResult notchResult);

        public abstract void onExtendSuccess(string modName,string jsonRes);

        public abstract void onExtendFailed(string modName,ErrorMsg errMsg);


        public abstract void onStorageSuccess(string value);

        public abstract void onStorageFailed(ErrorMsg errMsg);

        public abstract void onSkuQueryDetailSuccess(string value);

        public abstract void onSkuQueryDetailFailed(ErrorMsg errMsg);

        public abstract void onExitSuccess();

        public abstract void onExitFailed();

        public abstract void onSharedSuccess();

        public abstract void onSharedCancel();

        public abstract void onSharedFail(int code, string msg);

        public abstract void onReferrer(string referrer);

        public abstract void  onLocalNotificationClickSuccess(string notifyId);
        //callback end


        public void onInitSuccess(string msg)
		{
			onInitSuccess();
		}

		public void onInitFailed(string msg)
		{
		    ErrorMsg errMsg = new ErrorMsg();
			errMsg.errMsg = msg;
			
			onInitFailed(errMsg);
		}

        public void onLoginSuccess(string msg)
        {
            var data = BamBooSdkJson.JSONNode.Parse(msg);
            UserInfo userInfo = new UserInfo();
            userInfo.uid = data["uid"].Value;
            userInfo.open_id = data["open_id"].Value;
            userInfo.channel_user_id = data["channel_user_id"].Value;
            userInfo.token = data["token"].Value;
            userInfo.userName = data["userName"].Value;
            userInfo.is_guest = data["is_guest"].AsInt;
            userInfo.errMsg = data["msg"].Value;


            onLoginSuccess(userInfo);
        }

		public void onSwitchAccountSuccess(string msg)
		{
			var data = BamBooSdkJson.JSONNode.Parse(msg);
			UserInfo userInfo = new UserInfo();
			userInfo.uid = data["uid"].Value;
            userInfo.open_id = data["open_id"].Value;
            userInfo.channel_user_id = data["channel_user_id"].Value;
            userInfo.token = data["token"].Value;
			userInfo.token = data["token"].Value;
			userInfo.userName = data["userName"].Value;
			userInfo.errMsg = data["msg"].Value;

			onSwitchAccountSuccess(userInfo);
		}

        public void onLoginFailed(string msg)
        {
            ErrorMsg errMsg = new ErrorMsg();
			errMsg.errMsg = msg;
			
			onLoginFailed(errMsg);
        }

        public void onLogoutSuccess(string msg)
        {
            onLogoutSuccess();
        }

        public void onLogoutFailed(string msg)
        {
            onLogoutFailed();
        }

        
        public void onPaySuccess(string msg)
        {
            var data = BamBooSdkJson.JSONNode.Parse(msg);
            PayResult result = new PayResult();
            result.cpOrderId = data["cpOrderId"].Value;
            result.orderId = data["orderId"].Value;
            result.extra = data["extra"].Value;
            result.message = data["message"].Value;

            onPaySuccess(result);
        }

        public void onPayFailed(string msg)
        {
            var data = BamBooSdkJson.JSONNode.Parse(msg);
            PayResult result = new PayResult();
            result.cpOrderId = data["cpOrderId"].Value;
            result.orderId = data["orderId"].Value;
            result.extra = data["extra"].Value;
            result.message = data["message"].Value;
            onPayFailed(result);
        }

        public void onPayCancel(string msg)
        {
            var data = BamBooSdkJson.JSONNode.Parse(msg);
            PayResult result = new PayResult();
            result.cpOrderId = data["cpOrderId"].Value;
            result.orderId = data["orderId"].Value;
            result.extra = data["extra"].Value;
            result.message = data["message"].Value;

            onPayCancel(result);
        }

        public void onExitSuccess(string msg)
        {
            onExitSuccess();
        }

        public void onExitFailed(string msg)
        {
            onExitFailed();
        }

        public void onGuestUpgradeSuccess(string msg)
        {
            onGuestUpgradeSuccess();
        }

        public void onGuestUpgradeFailed(string msg)
        {
            ErrorMsg errMsg = new ErrorMsg();
			errMsg.errMsg = msg;
			onGuestUpgradeFailed(errMsg);
        }


        public void onOpenPageSuccess(string msg)
        {
            onOpenPageSuccess();
        }


        public void onOpenPageComplete(string msg)
        {
            var data = BamBooSdkJson.JSONNode.Parse(msg);
            PageResult result = new PageResult();
            result.tp = data["tp"].Value;
            onOpenPageComplete(result);
        }

        public void onOpenPageFailed(string msg)
        {
            ErrorMsg errMsg = new ErrorMsg();
			errMsg.errMsg = msg;
			onOpenPageFailed(errMsg);
        }

         public void onBackDownSuccess(string msg)
        {
            onBackDownSuccess();
        }

        public void onNotchSuccess(string msg)
        {
             var data = BamBooSdkJson.JSONNode.Parse(msg);
            NotchResult result = new NotchResult();
            result.hasNotch = data["has_notch"].AsBool;
            result.top = data["top"].AsInt;
            result.bottom = data["bottom"].AsInt;
            result.left = data["left"].AsInt;
            result.right = data["right"].AsInt;
            onNotch(result);
        }

        public void onNotchFailed(string msg)
        {
            NotchResult result = new NotchResult();
            result.hasNotch = false;
            result.top = 0;
            result.bottom = 0;
            result.left = 0;	
            result.right = 0;
			onNotch(result);
        }

        public void onExtendNativeSuccess(string msg)
        {
            var data = BamBooSdkJson.JSONNode.Parse(msg);
            var modName = data["mod_name"].Value;
            var json = data["msg"].Value;
            onExtendSuccess(modName,json);
        }

        public void onExtendNativeFailed(string msg)
        {
            var data = BamBooSdkJson.JSONNode.Parse(msg);
            var modName = data["mod_name"].Value;
            var errorStr = data["msg"].Value;
            ErrorMsg errMsg = new ErrorMsg();
			errMsg.errMsg = errorStr;
			onExtendFailed(modName,errMsg);
        }

        public void onStorageNativeSuccess(string value)
        {
            onStorageSuccess(value);
        }

        public void onStorageNativeFailed(string msg)
        {
             ErrorMsg errMsg = new ErrorMsg();
			errMsg.errMsg = msg;
			onStorageFailed(errMsg);
        }

        public void onSuccess(string infos)
        {
            onSucceed(infos);
        }

        public void onFail(string msg)
        {
            onFailed(msg);
        }

        public void onSharedSuccess(string empty) {
            onSharedSuccess();
        }

        public void onSharedCancel(string empty) {
            onSharedCancel();
        }

        public void onSharedNativeFail(string json) {
            Debug.Log(json);
            var data = BamBooSdkJson.JSONNode.Parse(json);
            var code = data["code"].AsInt;
            var errorStr = data["msg"].Value;
            onSharedFail(code, errorStr);
        }

        public void onSkuQuerySuccess(string list) {
              onSkuQueryDetailSuccess(list);
        }

        public void onSkuQueryFailed(string msg) {
            ErrorMsg errMsg = new ErrorMsg();
			errMsg.errMsg = msg;
			onSkuQueryDetailFailed(errMsg);
        }
    }
}
