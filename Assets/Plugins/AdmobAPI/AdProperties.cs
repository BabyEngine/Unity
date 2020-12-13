using UnityEngine;
using System.IO;
using System.Text;
using System.Collections.Generic;
namespace admob {
    [System.Serializable]
    public class AdProperties {
        public static readonly string maxAdContentRating_G = "G";
        public static readonly string maxAdContentRating_PG = "PG";
        public static readonly string maxAdContentRating_T = "T";
        public static readonly string maxAdContentRating_MA = "MA";
        Dictionary<string,object> dict = new Dictionary<string,object>();
        private string[] _keywords = null;

        /*
        private string _isForChildDirectedTreatment =null;
        private string _isUnderAgeOfConsent = null;
        private string _maxAdContentRating = null;//value can been null or one of G, PG, T, MA,

        private string _appVolume = null;
        private string _isAppMuted = null;

        private string _isTesting = null;
        private string _nonPersonalizedAdsOnly = null;
        
        public string[] _keywords= null;
        */
        public void isForChildDirectedTreatment(bool isForChildDirectedTreatmentValue)
        {
            
            dict.Add("isForChildDirectedTreatment", isForChildDirectedTreatmentValue?1:0);
        }
        public void isUnderAgeOfConsent(bool isUnderAgeOfConsentValue)
        {
            dict.Add("isUnderAgeOfConsent", isUnderAgeOfConsentValue ? 1 : 0);
        }
        public void maxAdContentRating(string maxAdContentRatingValue)
        {
            dict.Add("maxAdContentRating", maxAdContentRatingValue);
        }

        public void appVolume(int appVolume)
        {
            dict.Add("appVolume", appVolume);
        }

        public void isAppMuted(bool isAppMuted)
        {
            dict.Add("isAppMuted", isAppMuted);
        }

        public void isTesting(bool isTesting)
        {
            dict.Add("isTesting", isTesting);
        }
        public void nonPersonalizedAdsOnly(bool nonPersonalizedAdsOnly)
        {
            dict.Add("nonPersonalizedAdsOnly", nonPersonalizedAdsOnly);
        }

        public void keyworks(string[] keywords)
        {
            _keywords = keywords;
           // dict.Add("keywords", _keywords);
        }
        public string toString() {
            string json = "{";
            if (dict.ContainsKey("isForChildDirectedTreatment"))
            {
                json = json + "\"isForChildDirectedTreatment\":"+dict["isForChildDirectedTreatment"]+",";
            }
            if (dict.ContainsKey("isUnderAgeOfConsent"))
            {
                json = json + "\"isUnderAgeOfConsent\":" + dict["isUnderAgeOfConsent"] +",";
            }
            if (dict.ContainsKey("maxAdContentRating"))
            {
                json = json + "\"maxAdContentRating\":\"" + dict["maxAdContentRating"] + "\",";
            }


            if (dict.ContainsKey("appVolume"))
            {
                json = json + "\"appVolume\":" + dict["appVolume"] + ",";
            }
            if (dict.ContainsKey("isAppMuted"))
            {
                bool value =(bool) dict["isAppMuted"];
                json = json + "\"isAppMuted\":" + (value ? "true" : "false") + ",";
            }
            if (dict.ContainsKey("isTesting"))
            {
                bool value = (bool)dict["isTesting"];
                json = json + "\"isTesting\":" + (value ? "true" : "false") + ",";
            }


            if (dict.ContainsKey("nonPersonalizedAdsOnly"))
            {
                bool value = (bool)dict["nonPersonalizedAdsOnly"];
                json = json + "\"nonPersonalizedAdsOnly\":" + (value?"true":"false") + ",";
            }
            if (_keywords!=null)
            {
                string kresult = "";
                for (int i = 0; i < _keywords.Length; i++)
                {
                    kresult = kresult +"\""+ _keywords[i]+"\",";
                }
                kresult = kresult.TrimEnd(',');
                json = json + "\"keywords\":[" + kresult + "],";
            }
            if (json.EndsWith(","))
            {
                json=json.TrimEnd(',');
            }
            json = json + "}";
            //string result=JsonUtility.ToJson(dict);
          //  Debug.Log("init params -------------"+ json);
            return json;
        }
    }
}
