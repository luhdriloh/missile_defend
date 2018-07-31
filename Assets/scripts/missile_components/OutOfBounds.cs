using UnityEngine;
using System.Collections;

/// <summary>
/// Missile out of bound.
/// For when the missile go 
/// </summary>
public class OutOfBounds : MonoBehaviour
{
    public bool outOfBounds = true;

    void OnBecameInvisible()
    {
        GetComponent<MissileMovementScript>().SetForceVector(Vector2.zero);

        outOfBounds = false;
        Debug.Log("Putting away missile");
        transform.position = GameConstants.PoolStartPosition;
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.zero;
    }

	private void OnBecameVisible()
	{
        outOfBounds = true;
	}
}
