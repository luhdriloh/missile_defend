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
            Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
            if (CanShootMissile())
            {
                FireMissile(position);
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

    /// <summary>
    /// Fire a missile at the specified location on the screen.
    /// Will prepare the direction, speed at the target and 
    /// </summary>
    /// <param name="target">Target.</param>
    public void FireMissile(Vector3 target)
    {
        GameObject missile = playerMissilePool.pool.BorrowFromPool();

        // set position and rotation of the spawned missile
        missile.transform.position = GameConstants.PlayerMissileSpawnLocation;

        Quaternion targetRotation = Quaternion.LookRotation(missile.transform.position - target, Vector3.forward);
        missile.transform.rotation = targetRotation;
        missile.transform.eulerAngles = new Vector3(0, 0, missile.transform.eulerAngles.z);

        // set force vector on missile
        Vector2 force = target - GameConstants.PlayerMissileSpawnLocation;
        Vector2 normalizedForce = GameUtils.NormalizeVector(force, GameConstants.PlayerMissileSpeedPerSecond);
        missile.GetComponent<MissileMovementScript>().SetForceVector(normalizedForce);
    }
}