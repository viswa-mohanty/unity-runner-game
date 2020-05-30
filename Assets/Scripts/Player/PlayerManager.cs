using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool tagged;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;
    public static int numberOfFries;
    public static int numberOfCoins;
    public Text friesText;
    public Text coinsText;
    public Text finalScore;
    public Text highestScore;

    public static float score = 0.0f;

    void Start()
    {
        gameOver = false;
        tagged = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfFries = 0;
        numberOfCoins = 0;
        score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;

            if(tagged)
            {
                Destroy(startingText);
            }

            gameOverPanel.SetActive(true);
            finalScore.text = "Score: " + ((int)score).ToString();

            float previousHighScore = PlayerPrefs.GetFloat("highScore");
            if(previousHighScore < score)
            {
                PlayerPrefs.SetFloat("highScore", score);
                highestScore.text = "Highest Score: " + ((int)score).ToString();
            }
            else
            {
                highestScore.text = "Highest Score: " + ((int)previousHighScore).ToString();
            }
        }

        // friesText.text = "Fries: " + numberOfFries;
        friesText.text = ((int)numberOfFries).ToString();
        coinsText.text = ((int)numberOfCoins).ToString();
        //coinsText.text = "Coins: " + numberOfCoins;
        //coinsText.text = ((int)numberOfCoins).ToString();

        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }

        if(score > 40 && score < 65)
        {
            FindObjectOfType<AudioManager>().PlaySound("SiaKeepGoing");
        }

        if (score > 200 && score < 225)
        {
            FindObjectOfType<AudioManager>().PlaySound("SiaGoodJob");
        }


    }
}
