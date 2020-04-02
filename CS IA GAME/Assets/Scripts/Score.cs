using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{

    public Text ScoreText;
    public int score;

    public void setScore(int points)
    {
        score += points;
    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score " + score;
    }

}
