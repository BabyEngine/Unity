using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool {
    
    const int defaultAmount = 3;
    #region Pool
    public class Pool {
        Stack<GameObject> inactive;
        GameObject prefab;
        int nextId = 1;
        public Pool(GameObject prefab, int initAmount) {
            this.prefab = prefab;
            inactive = new Stack<GameObject>(initAmount);
        }
        public GameObject Spawn(Vector3 position, Quaternion rotation) {
            GameObject go = null;
            if ( inactive.Count == 0 ) {
                go = Object.Instantiate(prefab) as GameObject;
                go.name = prefab.name + "(" + (nextId++) + ")";
                var pm = go.AddComponent<PoolMember>();
                pm.pool = this;
            } else {
                go = inactive.Pop();
            }
            go.SetActive(true);
            go.transform.position = position;
            go.transform.rotation = rotation;
            return go;
        }

        public GameObject Spawn() {
            return Spawn(Vector3.zero, Quaternion.identity);
        }
        public void Despawn(GameObject go) {
            go.SetActive(false);
            inactive.Push(go);
        }
    }
    #endregion
    #region PoolMember
    public class PoolMember : MonoBehaviour {
        internal Pool pool = null;
    }
    #endregion
    static Dictionary<GameObject, Pool> pools = new Dictionary<GameObject, Pool>();
    private static void Init(GameObject prefab = null, int amount = defaultAmount) {
        if (prefab!=null && pools.ContainsKey(prefab) == false) {
            pools[prefab] = new Pool(prefab, amount);
        }
    }
    public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation) {
        Init(prefab);
        return pools[prefab].Spawn(position, rotation);
    }

    public static GameObject Spawn(GameObject prefab) {
        return Spawn(prefab, Vector3.zero, Quaternion.identity);
    }

    public static void Despawn(GameObject go) {
        PoolMember pm = go.GetComponent<PoolMember>();
        if (pm == null) {
            Debug.LogWarning($"Object '{go.name}' wan't spawned from a pool. Destroying it!!!");
            Object.Destroy(go);
        } else {
            pm.pool.Despawn(go);
        }

    }
}
