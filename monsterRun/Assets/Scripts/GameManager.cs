using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score;
    int highscore;
    public static GameManager inst;
    public Player player;

    public TMP_Text scoreText;
    public TMP_Text endScoreText;
    public TMP_Text highscoreText;

    public GameObject deathUI;

    public void IncrementScore()
    {
        //Increments score and updating UI text
        score++;
        scoreText.text = "Score: " + score;
        //Updating endscore and highscore for deathscreen
        endScoreText.text = "Score: " + score;
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        highscoreText.text = "Highscore: " + highscore;

        //Adds Speed vertical and horizontal
        player.speed += player.speedIncrease;
        player.horizontalSpeed += player.speedIncrease / 100;
    }

    //Creates a singleton of this script
    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        //Find Player script
        player = FindObjectOfType<Player>();

        //Get Highscore from saved file
        highscore = PlayerPrefs.GetInt("highscore");
    }

    private void Update()
    {
        //Checks in Player script if player is dead
        if(player.isDead)
        {
            //Activate DeathUI gameObject and update final scores
            PlayerPrefs.SetInt("highscore", highscore);
            highscoreText.text = "Highscore: " + highscore;
            endScoreText.text = "Score: " + score;
            deathUI.SetActive(true);
            //Deactivate score ui text
            scoreText.enabled = false;
        }
    }
}
