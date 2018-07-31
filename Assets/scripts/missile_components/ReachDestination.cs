using UnityEngine;
using System.Collections;

public class ReachDestination : MonoBehaviour
{
    private Vector2 target = Vector2.zero;
    private MissileInPlay missileInPlay;
    private MissileMovementScript missileMovement;

	private void Start()
	{
        missileInPlay = GetComponent<MissileInPlay>();
        missileMovement = GetComponent<MissileMovementScript>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
        if (!missileInPlay.inPlay)
        {
            return;
        }

        if (ReachedTarget())
        {
            target = Vector2.zero;
            missileMovement.MoveBackToStartPosition();
        }
	}

    public void SetMissileTarget(Vector2 targetPosition)
    {
        target = targetPosition;
    }

    public bool ReachedTarget()
    {
        Vector2 distance = target - (Vector2)transform.position;
        return Mathf.Abs(distance.magnitude) <= .3;
    }
}
