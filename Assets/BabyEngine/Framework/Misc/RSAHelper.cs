using System.Security.Cryptography;
using System.Text;
using System;

/// <summary>
/// RSA 加解密类
/// </summary>
[XLua.LuaCallCSharp]
public class RSAHelper {

    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="value">加密字串</param>
    /// <param name="pemPublicKey">加密公钥</param>
    /// <returns></returns>
    public static string Encrypt(string value, string pemPublicKey) {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
            rsa.ImportParameters(ConvertFromPemPublicKey(pemPublicKey));
            var encryptedBytes = rsa.Encrypt(Encoding.UTF8.GetBytes(value), false);
            return Base64Encode(encryptedBytes);
        }
    }
    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="encryptedData">解密内容</param>
    /// <param name="pemPrivateKey">解密私钥</param>
    /// <returns></returns>
    public static string Decrypt(string encryptedData, string pemPrivateKey) {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()) {
            rsa.ImportParameters(ConvertFromPemPrivateKey(pemPrivateKey));
            var data = rsa.Decrypt(Base64Decode(encryptedData), false);
            return Encoding.UTF8.GetString(data, 0, data.Length);
        }
    }

    // http://blog.csdn.net/liguo9860/article/details/40922919
    //
    static RSAParameters ConvertFromPemPublicKey(string pemFileConent) {
        pemFileConent = pemFileConent.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Replace("\n", "").Replace("\r", "");
        byte[] keyData = Base64Decode(pemFileConent);
        bool keySize1024 = (keyData.Length == 162);
        bool keySize2048 = (keyData.Length == 294);
        //if (!(keySize1024 || keySize2048)) {
        //    throw new ArgumentException("pem file content is incorrect, Only support the key size is 1024 or 2048");
        //}
        byte[] pemModulus = (keySize1024 ? new byte[128] : new byte[256]);
        var pemPublicExponent = new byte[3];
        Array.Copy(keyData, (keySize1024 ? 29 : 33), pemModulus, 0, (keySize1024 ? 128 : 256));
        Array.Copy(keyData, (keySize1024 ? 159 : 291), pemPublicExponent, 0, 3);
        var para = new RSAParameters { Modulus = pemModulus, Exponent = pemPublicExponent };
        return para;
    }

    // http://blog.csdn.net/liguo9860/article/details/40922919
    //
    public static RSAParameters ConvertFromPemPrivateKey(string pemFileConent) {
        if (string.IsNullOrEmpty(pemFileConent)) {
            throw new ArgumentNullException("pemFileConent", "This arg cann't be empty.");
        }

        pemFileConent = pemFileConent.Replace("-----BEGIN RSA PRIVATE KEY-----", "").Replace("-----END RSA PRIVATE KEY-----", "").Replace("\n", "").Replace("\r", "");
        byte[] keyData = Base64Decode(pemFileConent);
        bool keySize1024 = (keyData.Length == 609 || keyData.Length == 610);
        bool keySize2048 = (keyData.Length == 1190 || keyData.Length == 1192);

        //if (!(keySize1024 || keySize2048)) {
        //    throw new ArgumentException($"pem file content is incorrect, Only support the key size is 1024 or 2048 [{}]");
        //}

        int index = (keySize1024 ? 11 : 12);
        byte[] pemModulus = (keySize1024 ? new byte[128] : new byte[256]);
        Array.Copy(keyData, index, pemModulus, 0, pemModulus.Length);

        index += pemModulus.Length;
        index += 2;
        var pemPublicExponent = new byte[3];
        Array.Copy(keyData, index, pemPublicExponent, 0, 3);

        index += 3;
        index += 4;
        if (keyData[index] == 0) {
            index++;
        }
        byte[] pemPrivateExponent = (keySize1024 ? new byte[128] : new byte[256]);
        Array.Copy(keyData, index, pemPrivateExponent, 0, pemPrivateExponent.Length);

        index += pemPrivateExponent.Length;
        index += (keySize1024 ? ((int)keyData[index + 1] == 64 ? 2 : 3) : ((int)keyData[index + 2] == 128 ? 3 : 4));
        byte[] pemPrime1 = (keySize1024 ? new byte[64] : new byte[128]);
        Array.Copy(keyData, index, pemPrime1, 0, pemPrime1.Length);

        index += pemPrime1.Length;
        index += (keySize1024 ? ((int)keyData[index + 1] == 64 ? 2 : 3) : ((int)keyData[index + 2] == 128 ? 3 : 4));
        byte[] pemPrime2 = (keySize1024 ? new byte[64] : new byte[128]);
        Array.Copy(keyData, index, pemPrime2, 0, pemPrime2.Length);

        index += pemPrime2.Length;
        index += (keySize1024 ? ((int)keyData[index + 1] == 64 ? 2 : 3) : ((int)keyData[index + 2] == 128 ? 3 : 4));
        byte[] pemExponent1 = (keySize1024 ? new byte[64] : new byte[128]);
        Array.Copy(keyData, index, pemExponent1, 0, pemExponent1.Length);

        index += pemExponent1.Length;
        index += (keySize1024 ? ((int)keyData[index + 1] == 64 ? 2 : 3) : ((int)keyData[index + 2] == 128 ? 3 : 4));
        byte[] pemExponent2 = (keySize1024 ? new byte[64] : new byte[128]);
        Array.Copy(keyData, index, pemExponent2, 0, pemExponent2.Length);

        index += pemExponent2.Length;
        index += (keySize1024 ? ((int)keyData[index + 1] == 64 ? 2 : 3) : ((int)keyData[index + 2] == 128 ? 3 : 4));
        byte[] pemCoefficient = (keySize1024 ? new byte[64] : new byte[128]);
        Array.Copy(keyData, index, pemCoefficient, 0, pemCoefficient.Length);

        var para = new RSAParameters {
            Modulus = pemModulus,
            Exponent = pemPublicExponent,
            D = pemPrivateExponent,
            P = pemPrime1,
            Q = pemPrime2,
            DP = pemExponent1,
            DQ = pemExponent2,
            InverseQ = pemCoefficient
        };
        return para;
    }

    private static byte[] Base64Decode(string i) {
        return Convert.FromBase64String(i);
    }

    private static string Base64Encode(byte[] i) {
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
        //byte[] by = Encoding.UTF8.GetBytes(str);
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