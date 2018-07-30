using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovementScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 forceVector;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(new Vector2(0, 10f));
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.AddForce(forceVector);
    }

    public void SetForceVector(Vector2 vector)
    {
        this.forceVector = vector;
    }
}