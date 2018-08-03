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

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.name.Equals("EnemyMissile"))
        {
            health -= 20f;
            GameController.instance.UpdateCityHealth(health);
        }
	}
}
