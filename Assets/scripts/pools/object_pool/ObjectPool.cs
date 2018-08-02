using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public ObjectPoolConfiguration poolConfig;
    public List<GameObject> pool;
    public int indexOfNextBorrowedObject;

    public ObjectPool(ObjectPoolConfiguration config)
    {
        poolConfig = config;
        InstantiatePool();
    }

    private void InstantiatePool()
    {
        indexOfNextBorrowedObject = 0;
        pool = new List<GameObject>();

        for (int i = 0; i < poolConfig.poolSize; i++)
        {
            pool.Add((GameObject)Instantiate(poolConfig.prefab, poolConfig.initialPosition, Quaternion.identity));
            pool[i].name = poolConfig.prefabTagName;
        }
    }

    public GameObject BorrowFromPool()
    {
        int index = indexOfNextBorrowedObject;
        indexOfNextBorrowedObject = (indexOfNextBorrowedObject + 1) % poolConfig.poolSize;
        return pool[index];

    }

    // maybe take a delegate as a parameter and see what needs to be done
    public void ReturnToPool(GameObject obj)
    {
        obj.transform.position = poolConfig.initialPosition;
    }
}
