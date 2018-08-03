using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public Text cityHealthText;
    public Text scoreText;

    private readonly string healthString = "CITY HEALTH: {0}";
    private readonly string scoreString = "SCORE:  {0}";

    private int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void StoppedEnemyMissile()
    {
        score++;
        scoreText.text = string.Format(scoreString, score);
    }
	
    public void UpdateCityHealth(float newHealth)
    {
        cityHealthText.text = string.Format(healthString, newHealth);
    }
}
