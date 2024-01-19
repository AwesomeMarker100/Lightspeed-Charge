using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] int scoreForHit = 1;

    int score = 0;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();

    }

    // Update is called once per frame
    public void AddScore(int scoreForHit)
    {

        score += scoreForHit;
        scoreText.text = score.ToString();
            
    }
}
