using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissileCommandScript : MonoBehaviour
{
    private MissileObjectPool playerMissilePool;

    private Camera cam;
    private float timeSinceLastFired;

    // Use this for initialization
    void Start()
    {
        timeSinceLastFired = 0f;
        playerMissilePool = GetComponent<MissileObjectPool>();

        cam = Camera.main;
        Debug.Log("Camera width: " + cam.pixelWidth);
        Debug.Log("Camera height " + cam.pixelHeight);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastFired += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 target = cam.ScreenToWorldPoint(Input.mousePosition);
            if (CanShootMissile())
            {
                GameObject missile = playerMissilePool.pool.BorrowFromPool();
                missile.GetComponent<ReachDestination>().SetMissileTarget(target);
                missile.GetComponent<MissileMovementScript>().FireMissile(GameConstants.PlayerMissileSpawnLocation, target);
                timeSinceLastFired = 0;
            }
        }
    }

    /// <summary>
    /// Checks if you can fire a missile
    /// </summary>
    /// <returns><c>true</c>, if missile shot, <c>false</c> otherwise.</returns>
    public bool CanShootMissile()
    {
        return timeSinceLastFired >= 1.5f;
    }
}