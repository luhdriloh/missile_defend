using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovementScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private ReachDestination destination;
    public bool inPlay;


    private void Awake()
    {
        inPlay = false;
        rigidBody = GetComponent<Rigidbody2D>();
        destination = GetComponent<ReachDestination>();
    }

    private void FixedUpdate()
    {
        if (!inPlay)
        {
            rigidBody.velocity = Vector3.zero;
            return;
        }
    }

    /// <summary>
    /// This is for when the enemy missile gets hit by a player missile or an explosion
    /// </summary>
    /// <param name="collision">The collision.</param>
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (inPlay && !collision.name.Equals("City"))
        {
            if (collision.name.Equals("PlayerMissile") || collision.name.Equals("Explosion"))
            {
                GameController.instance.StoppedEnemyMissile();
            }

            destination.CreateExplosion();           
        }
	}

	/// <summary>
	/// Fire a missile at the specified location on the screen.
	/// Will prepare the direction, speed at the target and 
	/// </summary>
	/// <param name="fromPosition">The position from which to fire from.</param>
	/// <param name="target">Target.</param>
	public void FireMissile(Vector2 fromPosition, Vector2 target, float speed)
    {
        // set position and rotation of the spawned missile
        transform.position = fromPosition;

        Vector2 direction = target - fromPosition;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        rigidBody.angularVelocity = 0f;

        // set force vector on missile
        Vector2 force = target - fromPosition;

        // I found out that vector has a normalize force alread :(
        rigidBody.AddForce(gameObject.transform.up * speed);
        inPlay = true;
    }

    /// <summary>
    /// Set the missile back into the default off screen pool position
    /// </summary>
    public void MoveBackToStartPosition()
    {
        transform.position = GameConstants.PoolStartPosition;
        rigidBody.velocity = Vector3.zero;
        inPlay = false;
    }
}