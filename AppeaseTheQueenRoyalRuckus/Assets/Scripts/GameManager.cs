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

    public GameObject dialogueBox;
    public string[] posStatements;
    public string[] neutralStatements;
    // negStatements currently unused - revisit on adding third state of appeasement to queen
    //public string [] negStatements;
    public TMP_Text dialogueText;
    private bool dialogueActive;
    public float dialogueUptime;
    private float dialogueStart;
    private float dialogueEnd;

    void Start()
    {
        score = 0;
        queen1Active = true;
        queen2Active = false;
        queen3Active = false;
        queenState2.enabled = false;
        queenState3.enabled = false;
        dialogueActive = false;
        dialogueStart = 0;
        dialogueEnd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueActive) {
            if(Time.time > dialogueEnd) {
                print("Ending dialogue.\n");
                dialogueBox.SetActive(false);
                dialogueActive = false;
            }
        }
    }

    public void updateScore(int addedScore) {
        score += addedScore;
        scoreText.text = "Score: "+score;
        if(queen1Active && score >= scoreThreshhold1) {
            queen1Active = false;
            queen2Active = true;
            queenState1.enabled = false;
            queenState2.enabled = true;
            updateDialogueNeutral();
        }
        if(queen2Active && score >= scoreThreshhold2) {
            queen2Active = false;
            queenState2.enabled = false;
            queenState3.enabled = true;
            updateDialoguePositive();
        }
    }

    public void updateDialoguePositive() {
        int selectedDialogue = (int)Random.Range(0, posStatements.Length);
        dialogueText.text = posStatements[selectedDialogue];
        dialogueActive = true;
        dialogueStart = Time.time;
        dialogueEnd = dialogueStart + dialogueUptime;
        dialogueBox.SetActive(true);
    }

    public void updateDialogueNeutral() {
        int selectedDialogue = (int)Random.Range(0, neutralStatements.Length);
        dialogueText.text = neutralStatements[selectedDialogue];
        dialogueActive = true;
        dialogueStart = Time.time;
        dialogueEnd = dialogueStart + dialogueUptime;
        dialogueBox.SetActive(true);
    }
}
