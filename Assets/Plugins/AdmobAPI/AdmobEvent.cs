namespace admob
{
    // The position of the ad on the screen.
    public class AdmobEvent
    {
        public static readonly string onAdLoaded = "onAdLoaded";
        public static readonly string onAdFailedToLoad = "onAdFailedToLoad";
        public static readonly string onAdOpened = "onAdOpened";
        public static readonly string adViewWillDismissScreen = "adViewWillDismissScreen";
        public static readonly string onAdClosed = "onAdClosed";
        public static readonly string onAdLeftApplication = "onAdLeftApplication";

        public static readonly string onAdClicked = "onAdClicked";
        public static readonly string onAdImpression = "onAdImpression";
        
        public static readonly string onVideoUnmute = "onVideoUnmute";
        public static readonly string onVideoMute = "onVideoMute";
        public static readonly string onVideoEnd = "onVideoEnd";
        public static readonly string onVideoPause = "onVideoPause";
        public static readonly string onVideoPlay = "onVideoPlay";
        
        public static readonly string onVideoStart = "onVideoStart";
        public static readonly string onNativeAdLoaded = "onNativeAdLoaded";

        public static readonly string onRewardedVideoStarted = "onRewardedVideoStarted";
        public static readonly string onRewardedVideoCompleted = "onRewardedVideoCompleted";
        public static readonly string onRewarded = "onRewarded";
        public static readonly string onRewardedAdFailToPresent = "didFailToPresent";
    }
}
