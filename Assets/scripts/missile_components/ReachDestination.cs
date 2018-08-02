using UnityEngine;
using System.Collections;

public class ReachDestination : MonoBehaviour
{
    public GameObject explosion;

    public GameObject explosionToUse;

    private Vector2 target = Vector2.zero;
    private MissileMovementScript missileMovement;

    private void Start()
    {
        explosionToUse = Instantiate(explosion, transform.position, Quaternion.identity);
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
            Vector2 explosionLocation = transform.position;

            ResetMissile();
            explosionToUse.GetComponent<ExplosionScript>().Explode(explosionLocation);
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

    private void ResetMissile()
    {
        target = Vector2.zero;
        missileMovement.MoveBackToStartPosition();
    }
}
