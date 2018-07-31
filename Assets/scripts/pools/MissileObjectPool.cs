using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileObjectPool : MonoBehaviour
{
    public GameObject protoTypeObject;
    public string prefabName;
    public int poolSize;

    public ObjectPool pool;

    void Start()
    {
        ObjectPoolConfiguration poolConfiguration = new ObjectPoolConfiguration
        {
            prefab = protoTypeObject,
            prefabTagName = prefabName,
            poolSize = poolSize,
            initialPosition = GameConstants.PoolStartPosition
        };

        pool = new ObjectPool(poolConfiguration);
    }
}
