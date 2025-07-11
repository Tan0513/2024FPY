using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] playerProjectilePools;

    static Dictionary<GameObject, Pool> dictionary;


    void Start()
    {
        dictionary = new Dictionary<GameObject, Pool>();

        Initialize(playerProjectilePools);
    }

    void Initialize(Pool[] pools)
    {
        foreach (var pool in pools)
        {
        #if UNITY_EDITOR
            if (dictionary.ContainsKey(pool.Prefab))
            {
                Debug.LogError("Same prefab in miltiple pools! Prefab" + pool.Prefab.name);

                continue;
            }
        #endif

            dictionary.Add(pool.Prefab, pool);

            Transform poolParent = new GameObject("Pool :" + pool.Prefab.name).transform;

            poolParent.parent = transform;
            pool.Initialize(poolParent);
        }
    }

    public static GameObject Release(GameObject prefab)
    {
        #if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab: " + prefab.name);

            return null;
        }
        #endif

        return dictionary[prefab].PreparedObject();
    }

    public static GameObject Release(GameObject prefab, Vector3 position)
    {
        #if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab: " + prefab.name);

            return null;
        }
        #endif

        return dictionary[prefab].PreparedObject(position);
    }

    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        #if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab: " + prefab.name);

            return null;
        }
        #endif

        return dictionary[prefab].PreparedObject(position, rotation);
    }

    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation, Vector3 localScale)
    {
        #if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could NOT find prefab: " + prefab.name);

            return null;
        }
        #endif

        return dictionary[prefab].PreparedObject(position, rotation, localScale);
    }
}
