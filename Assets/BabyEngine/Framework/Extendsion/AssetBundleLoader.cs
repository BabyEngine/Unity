using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BabyEngine {
    public class AssetBundleLoader {
        static Dictionary<string, AssetBundle> assetBundles = new Dictionary<string, AssetBundle>();

        public static AssetBundle LoadFromFile(string name) {
            if (assetBundles.ContainsKey(name)) {
                return assetBundles[name];
            }
            var ab = AssetBundle.LoadFromFile(name);
            if (ab != null) {
                assetBundles[name] = ab;
                return ab;
            }
            return null;
        }

        public static AssetBundle LoadFromMemory(string name, byte[] data) {
            if (assetBundles.ContainsKey(name)) {
                return assetBundles[name];
            }
            var ab = AssetBundle.LoadFromMemory(data);
            if (ab != null) {
                assetBundles[name] = ab;
                return ab;
            }
            return null;
        }
    }
}
