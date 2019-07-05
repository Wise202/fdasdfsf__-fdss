using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{

    public static int score;

    public int savedScore;

    public Text scoreText;

    void Start()
    {
        savedScore = PlayerPrefs.GetInt("HighScore", savedScore);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
