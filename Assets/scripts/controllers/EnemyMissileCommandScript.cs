using UnityEngine;
using System.Collections;

public class EnemyMissileCommandScript : MonoBehaviour
{
    private MissileObjectPool enemyMissileObjectPool;
    private float timeSinceLastLaunch;
    private float timeLeftForNextLaunch;

	// Use this for initialization
	void Start()
	{
        timeSinceLastLaunch = 0f;
        timeLeftForNextLaunch = 5f;
        enemyMissileObjectPool = GetComponent<MissileObjectPool>();
	}

	// Update is called once per frame
	void Update()
	{
        timeSinceLastLaunch += Time.deltaTime;

        if (TimeToFire())
        {
            FireMissile();
            timeSinceLastLaunch = 0f;
            // todo: change time left for next launch here
        }

	}

    private bool TimeToFire()
    {
        if (timeSinceLastLaunch >= timeLeftForNextLaunch) {
            return true;
        }

        return false;
    }

    public void FireMissile()
    {
        GameObject enemyMissile = enemyMissileObjectPool.pool.BorrowFromPool();
        enemyMissile.transform.position = new Vector2(0, 10f);

        Quaternion rotationTarget = Quaternion.Euler(0, 0, 180f);
        enemyMissile.transform.rotation = rotationTarget;

        // Pick a random spot in the sky

        // Pick a random place on the city

        // Fire
        enemyMissile.GetComponent<MissileMovementScript>().SetForceVector(new Vector2(0, -120f));
    }
}
