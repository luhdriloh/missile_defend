using UnityEngine;
using System.Collections;

/// <summary>
/// Checks to see if the missile is in play
/// </summary>
public class MissileInPlay : MonoBehaviour
{
    public bool inPlay;
    private MissileMovementScript missileMovement;

	private void Start()
	{
        inPlay = false;
        missileMovement = GetComponent<MissileMovementScript>();
	}

	void OnBecameInvisible()
    {
        missileMovement.MoveBackToStartPosition();
        inPlay = false;
    }

	private void OnBecameVisible()
	{
        inPlay = true;
	}
}
