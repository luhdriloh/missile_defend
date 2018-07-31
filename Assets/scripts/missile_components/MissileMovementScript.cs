using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovementScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 forceVector;

    // called when a prefab is instantiated
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        forceVector = Vector2.zero;
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(forceVector * Time.fixedDeltaTime);
    }

    public void SetForceVector(Vector2 vector)
    {
        this.forceVector = vector;
    }
}