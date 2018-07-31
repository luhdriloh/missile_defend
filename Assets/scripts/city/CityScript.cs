using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityScript : MonoBehaviour
{
    public float health;

	private void Start()
	{
        health = 100f;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log("The city got hit");
		
	}
}
