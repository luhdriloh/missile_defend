using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityScript : MonoBehaviour
{
    public float health;

	private void Start()
	{
        health = 100f;
	}

    /// <summary>
    /// Checks if the city was hit by an enemy missile
    /// </summary>
    /// <param name="collision">The collision</param>
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.name.Equals("EnemyMissile"))
        {
            health -= 20f;
            GameController.instance.UpdateCityHealth(Mathf.Max(health, 0));
        }
	}
}
