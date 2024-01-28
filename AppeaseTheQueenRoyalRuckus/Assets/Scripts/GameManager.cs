using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public TMP_Text scoreText;

    public int scoreThreshhold1;
    public int scoreThreshhold2;

    public Image queenState1;
    public Image queenState2;
    public Image queenState3;
    public bool queen1Active;
    public bool queen2Active;
    public bool queen3Active;






    void Start()
    {
        score = 0;
        queen1Active = true;
        queen2Active = false;
        queen3Active = false;
        queenState2.enabled = false;
        queenState3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int addedScore) {
        score += addedScore;
        scoreText.text = "Score: "+score;
        if(queen1Active && score >= scoreThreshhold1) {
            queen1Active = false;
            queen2Active = true;
            queenState1.enabled = false;
            queenState2.enabled = true;
        }
        if(queen2Active && score >= scoreThreshhold2) {
            queen2Active = false;
            queenState2.enabled = false;
            queenState3.enabled = true;
        }


    }
}
