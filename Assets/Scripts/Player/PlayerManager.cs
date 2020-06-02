using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool tagged;
    public GameObject gameOverPanel;
    public GameObject HighestScoreGameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;
    public static int numberOfFries;
    public static int numberOfCoins;
    public static int numberOfChoco;
    public static int numberOfCupcake;
    public Text friesText;
    public Text coinsText;
    public Text chocoText;
    public Text cupcakeText;
    public Text finalScore;
    public Text finalScore2;
    public Text highestScore;
    public Text highestScore2;
    private float previousHighScore;

    public static float score = 0.0f;


    void Start()
    {
        gameOver = false;
        tagged = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfFries = 0;
        numberOfCoins = 0;
        numberOfCupcake = 0;
        numberOfChoco = 0;
        score = 0.0f;
        previousHighScore = PlayerPrefs.GetFloat("highScore");
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

            //float previousHighScore = PlayerPrefs.GetFloat("highScore");

            if (score > previousHighScore)
            {
                HighestScoreGameOverPanel.SetActive(true);
                finalScore2.text = "Score: " + ((int)score).ToString();
                highestScore2.text = "Previous Highest Score: " + ((int)previousHighScore).ToString();
                PlayerPrefs.SetFloat("highScore", score);
            } else if(score < previousHighScore)
            {
                gameOverPanel.SetActive(true);
                finalScore.text = "Score: " + ((int)score).ToString();
                highestScore.text = "Previous Highest Score: " + ((int)previousHighScore).ToString();
            }





            //gameOverPanel.SetActive(true);
            //finalScore.text = "Score: " + ((int)score).ToString();

            //float previousHighScore = PlayerPrefs.GetFloat("highScore");
            /*if(previousHighScore < score)
            {
                PlayerPrefs.SetFloat("highScore", score);
                highestScore.text = "Highest Score: " + ((int)score).ToString();
            }
            else
            {
                highestScore.text = "Highest Score: " + ((int)previousHighScore).ToString();
            }*/
        }

        // friesText.text = "Fries: " + numberOfFries;
        friesText.text = ((int)numberOfFries).ToString();
        coinsText.text = ((int)numberOfCoins).ToString();
        chocoText.text = ((int)numberOfChoco).ToString();
        cupcakeText.text = ((int)numberOfCupcake).ToString();
        //coinsText.text = "Coins: " + numberOfCoins;
        //coinsText.text = ((int)numberOfCoins).ToString();

        if (SwipeManager.tap)
        {
            isGameStarted = true;
            
            Destroy(startingText);
        }

        /*if(score > 40 && score < 65)
        {
            FindObjectOfType<AudioManager>().PlaySound("SiaKeepGoing");
        }*/

        /*if (score > 200 && score < 225)
        {
            FindObjectOfType<AudioManager>().PlaySound("SiaGoodJob");
        }

        if (score > 300 && score < 325)
        {
            FindObjectOfType<AudioManager>().PlaySound("SiaKeepGoing");
        }

        if (score > 400 && score < 425)
        {
            FindObjectOfType<AudioManager>().PlaySound("SiaGoodJob");
        }*/

        if ((score > 0) && (score < 25))
        {
            FindObjectOfType<AudioManager>().PlaySound("SiaStartRunning");
        }

        if ((score > 250) && (score % 250) > 0 && (score % 250) < 25)
        {
            FindObjectOfType<AudioManager>().PlaySound("SiaKeepGoing");
        }

        if ((score > 500) &&  (score % 500) > 0 && (score % 500) < 25)
        {
            FindObjectOfType<AudioManager>().PlaySound("SiaGoodJob");
        }

       

    }

}
