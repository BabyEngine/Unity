using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IManager : MonoBehaviour {
    public System.Func<string, IManager> getManagerHandler;
    public IManager GetManager(string name) {
        return getManagerHandler(name);
    }
}
