using System;
using System.Security.Cryptography;
using System.Text;

[XLua.LuaCallCSharp]
public class AESHelper {

    public static byte[] /*output*/ EncryptBytes(byte[] input, byte[] aesKey, byte[] aesIV) {
        Aes aes = new AesCryptoServiceProvider();
        aes.Padding = PaddingMode.PKCS7;
        aes.Mode = CipherMode.ECB;
        var enc = aes.CreateEncryptor(aesKey, aesIV);
        return enc.TransformFinalBlock(input, 0, input.Length);
    }

    public static byte[] DecryptBytes(byte[] encryptedOutput, byte[] aesKey, byte[] aesIV) {
        Aes aes = new AesCryptoServiceProvider();
        aes.Padding = PaddingMode.PKCS7;
        aes.Mode = CipherMode.ECB;
        var dec = aes.CreateDecryptor(aesKey, aesIV);
        return dec.TransformFinalBlock(encryptedOutput, 0, encryptedOutput.Length);
    }

    public static string EncryptHexStrings(string input, byte[] aesKey, byte[] aesIV) {
        byte[] bytes = HexStringToByteArray(input);
        byte[] encBytes = EncryptBytes(bytes, aesKey, aesIV);
        return ByteArrayToHexString(encBytes);
    }

    public static string DecryptHexStrings(string encryptedOutput, byte[] aesKey, byte[] aesIV) {
        byte[] bytes = HexStringToByteArray(encryptedOutput);
        byte[] decBytes = DecryptBytes(bytes, aesKey, aesIV);
        return ByteArrayToHexString(decBytes);
    }

    public static string EncryptHexStrings(string input, string aesKey, string aesIV) {
        byte[] key = HexStringToByteArray(aesKey);
        byte[] iv = HexStringToByteArray(aesIV);
        return EncryptHexStrings(input, key, iv);
    }

    public static string DecryptHexStrings(string encryptedOutput, string aesKey, string aesIV) {
        byte[] key = HexStringToByteArray(aesKey);
        byte[] iv = HexStringToByteArray(aesIV);
        return DecryptHexStrings(encryptedOutput, key, iv);
    }

    public static byte[] HexStringToByteArray(string s) {
        byte[] ret = new byte[s.Length / 2];
        for (int i = 0; i < s.Length; i += 2) {
            ret[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
        }
        return ret;
    }

    public static string ByteArrayToHexString(byte[] bytes) {
        var sb = new StringBuilder();
        foreach (byte b in bytes)
            sb.AppendFormat("{0:X2}", b);
        return sb.ToString().ToLower();
    }

    static byte[] iv = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static byte[] Encrypt(string key, byte[] data) {
        try {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            return EncryptBytes(data, keyBytes, iv);
        } catch (Exception e) {
            UnityEngine.Debug.LogError(e);
            return null;
        }
    }

    public static byte[] Decrpyt(string key, byte[] data) {
        try {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            return DecryptBytes(data, keyBytes, iv);
        } catch (Exception e) {
            UnityEngine.Debug.LogError(e);
            return null;
        }
    }

    public static byte[] EncryptString(string key, string str) {
        var data = Encoding.UTF8.GetBytes(str);
        return Encrypt(key, data);
    }

    public static byte[] DecrpytString(string key, string str) {
        var data = Encoding.UTF8.GetBytes(str);
        return Decrpyt(key, data);
    }

    public static byte[] Base64Decode(string i) {
        return Convert.FromBase64String(i);
    }

    public static string Base64Encode(byte[] i) {
        //return Convert.ToBase64String(i);
        return JavaBase64(i);
    }

    #region 转换为单字节  java base64
    /// <summary>
    /// 转换为单字节  java base64
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string JavaBase64(byte[] by) {
        sbyte[] sby = new sbyte[by.Length];
        for (int i = 0; i < by.Length; i++) {
            if (by[i] > 127)
                sby[i] = (sbyte)(by[i] - 256);
            else
                sby[i] = (sbyte)by[i];
        }
        byte[] newby = (byte[])(object)sby;
        return Convert.ToBase64String(newby);
    }
    #endregion
}
