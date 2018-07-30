using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovementScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    // Use this for initialization
    void Start()
    {
        Debug.Log("missile movement");
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(new Vector2(0, 10f));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
