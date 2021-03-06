using UnityEngine;
using System.Collections;

public class EnemyMissileCommandScript : MonoBehaviour
{
    private MissileObjectPool enemyMissilePool;
    private ReachDestination destination;
    private MissileMovementScript missileMovement;
    private float timeSinceLastLaunch;
    private float timeLeftForNextLaunch;

    public float minX;
    public float maxX;

	// Use this for initialization
	void Start()
	{
        timeSinceLastLaunch = 0f;
        timeLeftForNextLaunch = 5f;
        enemyMissilePool = GetComponent<MissileObjectPool>();
	}

	// Update is called once per frame
	void Update()
	{
        timeSinceLastLaunch += Time.deltaTime;

        if (TimeToFire() && !GameController.instance.gameover)
        {
            Vector3 target = FindTarget();

            GameObject missile = enemyMissilePool.pool.BorrowFromPool();
            missile.GetComponent<ReachDestination>().SetMissileTarget(target);
            missile.GetComponent<MissileMovementScript>().FireMissile(GetMissileStartPosition(), target, GameConstants.EnemyMissileSpeedPerSecond);
            timeSinceLastLaunch = 0f;
        }
	}

    /// <summary>
    /// Checks if you can fire a missile
    /// </summary>
    /// <returns><c>true</c>, if missile shot, <c>false</c> otherwise.</returns>
    private bool TimeToFire()
    {
        if (timeSinceLastLaunch >= timeLeftForNextLaunch)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Finds a target down in the city
    /// </summary>
    /// <returns>The target.</returns>
    private Vector3 FindTarget()
    {
        // it seems you need -10f for Quaternion.LookRotation to work correctly
        return new Vector3(Random.Range(minX, maxX), GameConstants.GameFloorYPosition, -10f);
    }

    private Vector2 GetMissileStartPosition()
    {
        return new Vector2(Random.Range(minX, maxX), 10f);
    }

}
