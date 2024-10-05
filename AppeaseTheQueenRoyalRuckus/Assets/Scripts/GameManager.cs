using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int score;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private TMP_Text numAttemptsText;
    [SerializeField] private int scoreThreshhold1;
    [SerializeField] private int scoreThreshhold2;

    [SerializeField] private Image queenState1;
    [SerializeField] private Image queenState2;
    [SerializeField] private Image queenState3;
    [SerializeField] private bool queen1Active;
    [SerializeField] private bool queen2Active;
    [SerializeField] private bool queen3Active;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private string[] posStatements;
    [SerializeField] private string[] neutralStatements;
    // negStatements currently unused - revisit on adding third state of appeasement to queen
    //public string [] negStatements;
    [SerializeField] private TMP_Text dialogueText;
    private bool dialogueActive;
    [SerializeField] private float dialogueUptime;
    private float dialogueStart;
    private float dialogueEnd;

    [SerializeField] private int numAttempts;
    [SerializeField] private GameObject myLauncher;
    [SerializeField] private GameObject myLauncherDoor;
    [SerializeField] private string gameOverScene;

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
        updateNumAttempts();
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

    public void resetPinball () {
        //numAttempts--;
        //updateNumAttempts();
        if(numAttempts <= 0) {
            print("Got here 0.\n");
            SceneManager.LoadScene(gameOverScene);
        }
        else {
            print("Got here 1.\n");
            myLauncher.GetComponent<LauncherScript>().newAttempt();
            print("Got here 2.\n");
            myLauncherDoor.GetComponent<LauncherDoorScript>().openLauncherDoor();
            print("Got here 3.\n");
        }
    }

    public void updateNumAttempts() {
        numAttemptsText.text = "Attempts: " + numAttempts;
    }
    public void reduceNumAttempts(int reduction) {
        numAttempts -= reduction;
        if (numAttempts < 0) {
            numAttempts = 0;
        }
        updateNumAttempts();
    }
    public void addNumAttempts(int addition) {
        numAttempts += addition;

        updateNumAttempts();
    }

}
