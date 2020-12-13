using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BabyEngine {
    public class AssetBundleLoader {
        static Dictionary<string, AssetBundle> assetBundles = new Dictionary<string, AssetBundle>();
        public static void Reset( bool b ) {
            foreach (var kv in assetBundles) {
                kv.Value.Unload(b);
            }
            assetBundles.Clear();
        }
        public static AssetBundle LoadFromFile(string name, bool isForceRaw = false) {
            if (assetBundles.ContainsKey(name)) {
                return assetBundles[name];
            }
            AssetBundle ab;
            if (string.IsNullOrEmpty(GameConf.EncryptPassword) || isForceRaw) {
                ab = AssetBundle.LoadFromFile(name);
            } else {
                var bytes = File.ReadAllBytes(name);
                var b2 = Decode(bytes);
                Debug.Log(name + " md5: " + Utility.FileMD5(name));
                File.WriteAllBytes(name + ".unity", b2);
                ab = AssetBundle.LoadFromMemory(b2);
            }
            if (ab != null) {
                assetBundles[name] = ab;
                return ab;
            }
            return null;
        }
        public static string GetMD5(byte[] data) {
            using (var md5 = MD5.Create()) {
                var hash = md5.ComputeHash(data);
                string md5Hash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                return md5Hash;
            }
        }
        public static AssetBundle LoadFromMemory(string name, byte[] data, bool isForceRaw = false) {
            if (assetBundles.ContainsKey(name)) {
                return assetBundles[name];
            }
            if(data == null) {
                return null;
            }

            //var m1 = GetMD5(data);
            AssetBundle ab;
            if (string.IsNullOrEmpty(GameConf.EncryptPassword) || isForceRaw) {
                ab = AssetBundle.LoadFromMemory(data);
            } else {
                var b2 = Decode(data);
                //var m2 = GetMD5(b2);
                ab = AssetBundle.LoadFromMemory(b2);
            }
            if (ab != null) {
                assetBundles[name] = ab;
                return ab;
            }
            return null;
        }

        public static byte[] Decode( byte[] bytes ) {
            if (string.IsNullOrEmpty(GameConf.EncryptPassword)) { return bytes; }
            return AESHelper.Decrpyt(GameConf.EncryptPassword, bytes);
        }

        public static byte[] Encode( byte[] bytes ) {
            if (string.IsNullOrEmpty(GameConf.EncryptPassword)) { return bytes; }
            return AESHelper.Encrypt(GameConf.EncryptPassword, bytes);
        }

    }
}
