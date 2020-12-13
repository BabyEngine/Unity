using UnityEngine;

using System.Runtime.InteropServices;
using AOT;
namespace admob
{
    public class Admob
    {
        public delegate void AdmobEventHandler(string eventName, string msg);

        public event AdmobEventHandler bannerEventHandler;
        public event AdmobEventHandler interstitialEventHandler;
        public event AdmobEventHandler rewardedVideoEventHandler;
        public event AdmobEventHandler nativeBannerEventHandler;
        private static Admob _instance;

        public static Admob Instance()
        {
            if (_instance == null)
            {
                _instance = new Admob();
                _instance.preInitAdmob();
            }
            return _instance;
        }
#if UNITY_IOS
        internal delegate void AdmobAdCallBack(string adtype, string eventName, string msg);
		public void removeAllBanner(){
			Debug.Log("calling removeAllBanner");
		}
        private void preInitAdmob()
        {

        }
        [DllImport("__Internal")]
        private static extern void _kminitSDK(string adproperties, AdmobAdCallBack callback);
        public void initSDK(AdProperties value)
		{
			if(value==null){
                value = new AdProperties();
			}
            string properties=value.toString();
            _kminitSDK(properties,onAdmobEventCallBack);
		}
     

        [DllImport("__Internal")]
        private static extern void _kmshowNativeBannerAbsolute(string nativeID, int width, int height, int x, int y,string instanceName);
        public void showNativeBannerAbsolute(string nativeID,AdSize size, int x, int y, string instanceName = "defaultNativeBanner")
        {
            _kmshowNativeBannerAbsolute(nativeID,size.Width, size.Height, x, y, instanceName);
        }

        [DllImport("__Internal")]
        private static extern void _kmshowNativeBannerRelative(string nativeID, int width, int height, int position, int marginY, string instanceName);
        public void showNativeBannerRelative(string nativeID,AdSize size, int position, int marginY=0,  string instanceName = "defaultNativeBanner")
        {
            _kmshowNativeBannerRelative(nativeID,size.Width, size.Height, position, marginY, instanceName);
        }

        [DllImport("__Internal")]
        private static extern void _kmremoveNativeBanner(string instanceName);
        public void removeNativeBanner(string instanceName = "defaultNativeBanner")
        {
            _kmremoveNativeBanner(instanceName);
        }
         [DllImport("__Internal")]
        private static extern void _kmreloadNativeBannerAds(string instanceName);
        public void reloadNativeBanner(string instanceName = "defaultNativeBanner")
        {
            _kmreloadNativeBannerAds(instanceName);
        }

        [DllImport("__Internal")]
        private static extern void _kmshowBannerAbsolute(string bannerid,int width, int height, int x, int y,string instanceName);
        public void showBannerAbsolute(string bannerid,AdSize size, int x, int y,string instanceName="defaultBanner")
        {
            _kmshowBannerAbsolute(bannerid,size.Width, size.Height, x, y,instanceName);
        }

        [DllImport("__Internal")]
        private static extern void _kmshowBannerRelative(string bannerid,int width, int height, int position, int marginY,string instanceName);
        public void showBannerRelative(string bannerid,AdSize size, int position, int marginY=0,string instanceName="defaultBanner")
        {
            _kmshowBannerRelative(bannerid,size.Width, size.Height, position, marginY,instanceName);
        }

        [DllImport("__Internal")]
        private static extern void _kmremoveBanner(string instanceName);
        public void removeBanner(string instanceName="defaultBanner")
        {
            _kmremoveBanner(instanceName);
        }

        [DllImport("__Internal")]
        private static extern void _kmloadInterstitial(string id);
        public void loadInterstitial(string interstitialID)
        {
            _kmloadInterstitial(interstitialID);
        }

        [DllImport("__Internal")]
        private static extern bool _kmisInterstitialReady();
        public bool isInterstitialReady()
        {
            return _kmisInterstitialReady();
        }

        [DllImport("__Internal")]
        private static extern void _kmshowInterstitial();
        public void showInterstitial()
        {
            _kmshowInterstitial();
        }

         [DllImport("__Internal")]
        private static extern void _kmloadRewardedVideo(string rewardedVideoID);
        public void loadRewardedVideo(string rewardedVideoID)
        {
            _kmloadRewardedVideo(rewardedVideoID);
        }

        [DllImport("__Internal")]
        private static extern bool _kmisRewardedVideoReady();
        public bool isRewardedVideoReady()
        {
            return _kmisRewardedVideoReady();
        }

        [DllImport("__Internal")]
        private static extern void _kmshowRewardedVideo();
        public void showRewardedVideo()
        {
            _kmshowRewardedVideo();
        }
       
        [MonoPInvokeCallback(typeof(AdmobAdCallBack))]
        public static void onAdmobEventCallBack(string adtype, string eventName, string msg)
        {
         //   Debug.Log("c# receive callback " + adtype + "  " + eventName + "  " + msg);
            if (adtype == "banner")
            {
                if (Admob.Instance().bannerEventHandler != null)
                Admob.Instance().bannerEventHandler(eventName, msg);
            }
            else if (adtype == "interstitial")
            {
                if (Admob.Instance().interstitialEventHandler != null)
                Admob.Instance().interstitialEventHandler(eventName, msg);
            }
            else if (adtype == "rewardedVideo")
            {
                if (Admob.Instance().rewardedVideoEventHandler != null)
                Admob.Instance().rewardedVideoEventHandler(eventName, msg);
            }
            else if (adtype == "nativeBanner")
            {
                if (Admob.Instance().nativeBannerEventHandler != null)
                    Admob.Instance().nativeBannerEventHandler(eventName, msg);
            }
        }

#elif UNITY_ANDROID
        private AndroidJavaObject jadmob=null;
		 private void preInitAdmob(){
            if (jadmob == null) {
                AndroidJavaClass admobUnityPluginClass = new AndroidJavaClass("com.admob.plugin.AdmobUnityPlugin");
                jadmob = admobUnityPluginClass.CallStatic<AndroidJavaObject>("getInstance");
                if(jadmob!= null)
                {
                    InnerAdmobListener innerlistener = new InnerAdmobListener();
                    innerlistener.admobInstance = this;
                    jadmob.Call("setListener", new object[] { new AdmobListenerProxy(innerlistener) });
                }
			}
		}
		public void removeAllBanner(){
            if(jadmob!=null)
			jadmob.Call("removeAllBanner");
		}
	     public void initSDK(AdProperties value)
		{
            if(value==null){
                value = new AdProperties();
			}
            if (jadmob != null)
                jadmob.Call ("initSDK", new object[]{value.toString()});
		}
        public void showBannerRelative(string admobBannerID,AdSize size, int position,int marginY=0,string instanceName="defaultBanner")
        {
            if (jadmob != null)
                jadmob.Call("showBannerRelative", new object[] {admobBannerID, size.Width,size.Height,position,marginY,instanceName});
		}
        public void showBannerAbsolute(string admobBannerID,AdSize size, int x, int y, string instanceName = "defaultBanner")
        {
            if (jadmob != null)
                jadmob.Call("showBannerAbsolute", new object[] {admobBannerID, size.Width, size.Height,x,y ,instanceName});
        }
        public void removeBanner(string instanceName = "defaultBanner")
        {
            if (jadmob != null)
                jadmob.Call("removeBanner",instanceName);
        }


        public void loadInterstitial(string interstitialID)
        {
            if (jadmob != null)
                jadmob.Call("loadInterstitial",interstitialID);
        }
        public bool isInterstitialReady()
        {
            if (jadmob == null) return false;
                bool isReady = jadmob.Call<bool>("isInterstitialReady");
            return isReady;
        }
        public void showInterstitial()
        {
            if (jadmob != null)
                jadmob.Call("showInterstitial");
        }


        public void loadRewardedVideo(string rewardedVideoID)
        {
            if (jadmob != null)
                jadmob.Call("loadRewardedVideo", new object[] { rewardedVideoID });
        }
        public bool isRewardedVideoReady()
        {
            if (jadmob == null) return false;
                bool isReady = jadmob.Call<bool>("isRewardedVideoReady");
            return isReady;
        }
        public void showRewardedVideo()
        {
            if (jadmob != null)
                jadmob.Call("showRewardedVideo");
        }
        /*
        public void setAdProperties(AdProperties value) { 
          jadmob.Call("setAdProperties",value.toString());
        }
        */
       
        public void showNativeBannerRelative(string nativeBannerID, AdSize size, int position, int marginY=0,string instanceName = "defaultNativeBanner")
        {
            if (jadmob != null)
                jadmob.Call("showNativeBannerRelative", new object[] { nativeBannerID,size.Width, size.Height, position, marginY, instanceName });
        }
        public void showNativeBannerAbsolute(string nativeBannerID,AdSize size, int x, int y, string instanceName = "defaultNativeBanner")
        {
            if (jadmob != null)
                jadmob.Call("showNativeBannerAbsolute", new object[] {nativeBannerID, size.Width, size.Height, x, y, instanceName });
        }
        public void removeNativeBanner(string instanceName = "defaultNativeBanner")
        {
            if (jadmob != null)
                jadmob.Call("removeNativeBanner", instanceName);
        }
        public void reloadNativeBanner(string instanceName = "defaultNativeBanner")
        {
            if (jadmob != null)
                jadmob.Call("reloadNativeBanner", instanceName);
        }
        class InnerAdmobListener : IAdmobListener
        {
            internal Admob admobInstance;
            public void onAdmobEvent(string adtype, string eventName, string paramString)
            {
                if (adtype == "banner")
                {
                    if (admobInstance.bannerEventHandler != null)
                    admobInstance.bannerEventHandler(eventName, paramString);
                }
                else if (adtype == "interstitial")
                {
                    if (admobInstance.interstitialEventHandler != null)
                    admobInstance.interstitialEventHandler(eventName, paramString);
                }
                else if (adtype == "rewardedVideo")
                {
                    if (admobInstance.rewardedVideoEventHandler != null)
                    admobInstance.rewardedVideoEventHandler(eventName, paramString);
                }
                else if (adtype == "nativeBanner")
                {
                    if(admobInstance.nativeBannerEventHandler!=null)
                    admobInstance.nativeBannerEventHandler(eventName, paramString);
                }
            }
        }

#else
        public void removeAllBanner()
        {
            Debug.Log("calling removeAllBanner");
        }
        private void preInitAdmob()
        {

        }

        public void initSDK(AdProperties adProperties)
        {
            Debug.Log("calling init sdk");
            Debug.Log("bannerEventHandler==null ? " + (bannerEventHandler == null));
            Debug.Log("interstitialEventHandler==null ? " + (interstitialEventHandler == null));
            Debug.Log("rewardedVideoEventHandler==null ? " + (rewardedVideoEventHandler == null));
            Debug.Log("nativeBannerEventHandler==null ? " + (nativeBannerEventHandler == null));
        }


        public void showBannerAbsolute(string bannerID,AdSize size, int x, int y, string instanceName = "defaultBanner")
        {
            Debug.Log("calling showBannerAbsolute");
        }


        public void showBannerRelative(string bannerID,AdSize size, int position, int marginY=0, string instanceName = "defaultBanner")
        {
            Debug.Log("calling showBannerRelative");
        }


        public void removeBanner(string instanceName = "defaultBanner")
        {
            Debug.Log("calling removeBanner");
        }


        public void loadInterstitial(string interstitialID)
        {
            Debug.Log("calling loadInterstitial");
        }


        public bool isInterstitialReady()
        {
            Debug.Log("calling isInterstitialReady");
            return false;
        }


        public void showInterstitial()
        {
            Debug.Log("calling showInterstitial");
        }

        public void loadRewardedVideo(string rewardedVideoID)
        {
            Debug.Log("calling loadRewardedVideo");
        }
        public bool isRewardedVideoReady()
        {
            Debug.Log("calling isRewardedVideoReady");
            return false;
        }
        public void showRewardedVideo()
        {
            Debug.Log("calling showRewardedVideo");
        }

        //public void setAdProperties(AdProperties value) { }
        public void showNativeBannerRelative(string nativeBannerID, AdSize size, int position, int marginY=0,string instanceName = "defaultNativeBanner")
        {
            Debug.Log("calling showNativeBannerRelative");
        }
        public void showNativeBannerAbsolute(string nativeBannerID, AdSize size, int x, int y,  string instanceName = "defaultNativeBanner")
        {
            Debug.Log("calling showNativeBannerAbsolute");
        }
        public void removeNativeBanner(string instanceName = "defaultNativeBanner")
        {
            Debug.Log("calling removeNativeBanner");
        }
        public void reloadNativeBanner(string instanceName="defaultNativeBanner"){
        }
#endif

    }
}
