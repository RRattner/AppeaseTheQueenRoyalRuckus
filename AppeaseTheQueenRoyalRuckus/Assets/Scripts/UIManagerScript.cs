using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private TMP_Text numAttemptsText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScoreText(int newScore) {
        scoreText.text = "Score: "+newScore;
    }

    public void updateNumAttemptsText(int newNumAttempts) {
        numAttemptsText.text = "Attempts: " + newNumAttempts;
    }
}
