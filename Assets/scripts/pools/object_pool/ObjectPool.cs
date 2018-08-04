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

    /// <summary>
    /// Instantiates the pool using the configuration that was passed in
    /// </summary>
    private void InstantiatePool()
    {
        indexOfNextBorrowedObject = 0;
        pool = new List<GameObject>();

        for (int i = 0; i < poolConfig.poolSize; i++)
        {
            GameObject toAdd = (GameObject)Instantiate(poolConfig.prefab, poolConfig.initialPosition, Quaternion.identity);
            toAdd.name = poolConfig.prefabTagName;
            pool.Add(toAdd);
        }
    }

    /// <summary>
    /// Borrows an object from the pool
    /// </summary>
    /// <returns>A game object from the</returns>
    public GameObject BorrowFromPool()
    {
        int index = indexOfNextBorrowedObject;
        indexOfNextBorrowedObject = (indexOfNextBorrowedObject + 1) % poolConfig.poolSize;
        return pool[index];

    }

    /// <summary>
    /// Returns an object to the pool, although I'm not using it
    /// </summary>
    /// <param name="obj">The object to return</param>
    public void ReturnToPool(GameObject obj)
    {
        obj.transform.position = poolConfig.initialPosition;
    }
}
