using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

	public void Explode(Vector3 position)
    {
        transform.position = position;
        animator.Play("Explosion");
        Invoke("MoveBackToPool", .8f);
    }

    private void MoveBackToPool()
    {
        transform.position = GameConstants.PoolStartPosition;
    }
}
