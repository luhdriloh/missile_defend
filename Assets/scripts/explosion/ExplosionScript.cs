using System.Collections;
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
            Debug.Log("Explosion hit another object: " + collision.gameObject.name);
        }
    }

    public void Explode(Vector3 position)
    {
        transform.position = position;
        inUse = true;
        animator.Play("Explosion");
        Invoke("MoveBackToPool", .8f);
    }

    private void MoveBackToPool()
    {
        inUse = false;
        transform.position = GameConstants.PoolStartPosition;
    }

}
