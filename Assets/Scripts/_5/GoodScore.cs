using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodScore : MonoBehaviour
{
    public Text scoreText;
    public Text scoreDisplayText;
    private int score = 99999;
    private int oldScore;
    private string scoreStr = "Score : ";

    private void Start()
    {
        oldScore = score;
        scoreText.text = "Score : ";
    }

    private void Update()
    {
        if(score != oldScore)
        {
            scoreStr = score.ToString();
            scoreDisplayText.text = scoreStr;
            oldScore = score;
            //scoreText.text = scoreStr;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            score -= 100;
        }
    }
}
