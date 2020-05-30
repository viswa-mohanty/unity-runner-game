using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //private float score = 0.0f;
    //public static float score = 0.0f;
    public Text scoreText;
    void Start()
    {
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        PlayerManager.score += Time.deltaTime * 25;
        scoreText.text = "Score: " + ((int)PlayerManager.score).ToString();
    }
}
