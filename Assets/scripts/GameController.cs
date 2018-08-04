using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public bool gameover;
    public Text cityHealthText;
    public Text scoreText;
    public GameObject gameoverText;

    private Camera camera;
    private readonly string healthString = "CITY HEALTH: {0}";
    private readonly string scoreString = "SCORE:  {0}";

    private int score;

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

	private void Start()
	{
        gameover = false;
        score = 0;
        camera = Camera.main;
	}

	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
	}

	/// <summary>
	/// Stoppeds the enemy missile. Update the score
	/// </summary>
	public void StoppedEnemyMissile()
    {
        score++;
        scoreText.text = string.Format(scoreString, score);
    }
	
    /// <summary>
    /// Updates the city health.
    /// </summary>
    /// <param name="cityHealth">New health score.</param>
    public void UpdateCityHealth(float cityHealth)
    {
        camera.backgroundColor = Color.red;
        Invoke("ReturnBackgroundColorToBlack", 1f);
        cityHealthText.text = string.Format(healthString, cityHealth);
        CheckGameOver(cityHealth);
    }

    /// <summary>
    /// A little extra pizaz
    /// </summary>
    private void ReturnBackgroundColorToBlack()
    {
        camera.backgroundColor = Color.black;
    }

    /// <summary>
    /// Checks if the game is over.
    /// </summary>
    /// <param name="cityHealth">City health to check</param>
    private void CheckGameOver(float cityHealth)
    {
        if (cityHealth <= 0)
        {
            gameover = true;
            gameoverText.SetActive(true);
        }
    }
}
