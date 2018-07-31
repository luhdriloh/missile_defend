using UnityEngine;
using System.Collections;

public class ReachDestination : MonoBehaviour
{
    private Vector2 target = Vector2.zero;
    private MissileMovementScript missileMovement;

    private void Start()
    {
        missileMovement = GetComponent<MissileMovementScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!missileMovement.inPlay)
        {
            return;
        }

        if (ReachedTarget())
        {
            ResetMissile();
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

        // instantiate an explosion and see if there are any nearby missiles
    }

    private void ResetMissile()
    {
        target = Vector2.zero;
        missileMovement.MoveBackToStartPosition();
    }
}
