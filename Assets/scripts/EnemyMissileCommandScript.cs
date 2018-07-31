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
        timeLeftForNextLaunch = 1f;
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
        if (timeLeftForNextLaunch >= timeSinceLastLaunch) {
            return true;
        }

        return false;
    }

    public void FireMissile()
    {
        // Pick a random spot in the sky

        // Pick a random place on the city

        // Fire
    }
}
