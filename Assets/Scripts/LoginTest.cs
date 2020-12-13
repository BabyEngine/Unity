using BabyEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoginTest : MonoBehaviour {
    public string baseURL = "http://localhost:8080";
    private void Start() {
        doLogin();
    }
    void doLogin() {
        var req = new LoginRequestInfo() { token = $"guest:{SystemInfo.deviceUniqueIdentifier}" };

        gameObject.HTTPPostJsonText($"{baseURL}/v1/action/login", req.ToJson(), (code, headers, body) => {
            Debug.Log($"{code} {body}");
            if (code == 200) {
                var resp = JsonUtility.FromJson<LoginResponseInfo>(body);
                if (resp != null) {
                    doSecuritySet(resp.token, resp.publicKey);
                    return;
                }
            }
            // some error
        });
    }

    void doSecuritySet(string token, string pubKey) {
        var nonce = Extendsion.RandomString(16, "0123456789");
        var req = new SecuritySetRequestInfo() { token = token, nonce = RSAHelper.Encrypt($"123456789", pubKey) };
        gameObject.HTTPPostJsonText($"{baseURL}/v1/action/security_set", req.ToJson(), (code, headers, body) => {
            Debug.Log($"{code} {body}");
            if (code == 200) {

            }
        });
    }
}

public class LoginRequestInfo {
    public string token;
}

public class LoginResponseInfo {
    public int code;
    public string publicKey;
    public string token;
}
public class SecuritySetRequestInfo {
    public string token;
    public string nonce;
}

public class SecuritySetResponseInfo {
    public int code;
    public string privateKey;
    public string publicKey;
}
