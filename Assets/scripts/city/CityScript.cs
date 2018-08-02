using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityScript : MonoBehaviour
{
    public Text healthText;
    public float health;

    private readonly string healthString = "CITY HEALTH: {0}";

	private void Start()
	{
        health = 100f;
        Debug.Log("Health: " + health);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.name.Equals("EnemyMissile"))
        {
            Debug.Log("The city got hit by an enemy missile!");
            health -= 20f;
            Debug.Log("Health: " + health);
            UpdateCityHealth();
        }
	}

    private void UpdateCityHealth()
    {
        healthText.text = string.Format(healthString, health);
    }
}
