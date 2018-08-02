﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private Animator animator;
    private bool inUse;

    void Start()
    {
        inUse = false;
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inUse)
        {
            Debug.Log("Collided with another object: " + collision.gameObject.name);
        }
    }

    public void Explode(Vector3 position)
    {
        inUse = true;
        transform.position = position;
        animator.Play("Explosion");
        Invoke("MoveBackToPool", .8f);
    }

    private void MoveBackToPool()
    {
        inUse = false;
        transform.position = GameConstants.PoolStartPosition;
    }

}
