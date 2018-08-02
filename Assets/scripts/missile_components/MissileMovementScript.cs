using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovementScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 forceVector;
    public bool inPlay;

    // called when a prefab is instantiated
    private void Awake()
    {
        inPlay = false;
        rigidBody = GetComponent<Rigidbody2D>();
        forceVector = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (!inPlay)
        {
            rigidBody.velocity = Vector2.zero;
            return;
        }

        rigidBody.AddForce(forceVector * Time.fixedDeltaTime);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// when the missile get hit by an explosion we need to move it back to the start position
	}

	/// <summary>
	/// Fire a missile at the specified location on the screen.
	/// Will prepare the direction, speed at the target and 
	/// </summary>
	/// <param name="fromPosition">The position from which to fire from.</param>
	/// <param name="target">Target.</param>
	public void FireMissile(Vector2 fromPosition, Vector3 target, float speed)
    {
        // set position and rotation of the spawned missile
        transform.position = fromPosition;

        Quaternion targetRotation = Quaternion.LookRotation(transform.position - target, Vector3.forward);
        transform.rotation = targetRotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        // set force vector on missile
        Vector2 force = (Vector2)target - fromPosition;

        // I found out that vector has a normalize force alread :(
        rigidBody.velocity = Vector2.zero;
        Vector2 normalizedForce = force.normalized * speed;
        forceVector = normalizedForce;
        inPlay = true;
    }

    /// <summary>
    /// Set the missile back into the default off screen pool position
    /// </summary>
    public void MoveBackToStartPosition()
    {
        transform.position = GameConstants.PoolStartPosition;
        rigidBody.velocity = Vector2.zero;
        forceVector = Vector2.zero;
        inPlay = false;
    }
}