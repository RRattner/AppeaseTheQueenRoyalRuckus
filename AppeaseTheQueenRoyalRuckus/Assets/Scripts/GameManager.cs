using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject myGameDataTracker;
    private int score;
    private int numAttempts;
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
    [SerializeField] private GameObject myLauncher;
    [SerializeField] private GameObject myLauncherDoor;
    [SerializeField] private string gameOverScene;
    [SerializeField] private GameObject[] subLevelPortals;
    [SerializeField] private String[] subLevelSceneNames;

    [SerializeField] private GameObject[] paddles;
    private Transform[] paddleTransforms;

    private HingeJoint[] paddleHinges;

    
    void Start()
    {
        myGameDataTracker = GameObject.FindGameObjectsWithTag("InterSceneData")[0];
        paddleTransforms = new Transform[paddles.Length];
        paddleHinges = new HingeJoint[paddles.Length];
        for(int i = 0; i < paddles.Length; i++) {
            paddleTransforms[i] = paddles[i].transform;
            paddleHinges[i] = paddles[i].GetComponent<HingeJoint>();
        }
        updateGameData();
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
    //Using IEnumerator to make sure that scene is fully loaded before being hidden
    IEnumerator FullyLoadAdditiveScene(int sceneIndex){
        SceneManager.LoadScene(subLevelSceneNames[sceneIndex], LoadSceneMode.Additive);
        yield return new WaitUntil(()=>SceneManager.GetSceneByName(subLevelSceneNames[sceneIndex]).isLoaded);
        myGameDataTracker.GetComponent<GameDataTracker>().updateSublevelsOpen(sceneIndex);
    }

    public void updateGameData() {
        score = myGameDataTracker.GetComponent<GameDataTracker>().getScore();
        print("Current score is: "+score+"\n");
        numAttempts = myGameDataTracker.GetComponent<GameDataTracker>().getAttempts();
        //Set correct sublevels to open up on scene load
        
        for(int i = 0; i< subLevelPortals.Length; i++) {
            if(myGameDataTracker.GetComponent<GameDataTracker>().checkSublevelOpen(i) && !myGameDataTracker.GetComponent<GameDataTracker>().checkSublevelComplete(i)) {
                subLevelPortals[i].SetActive(true);
                if( !SceneManager.GetSceneByName(subLevelSceneNames[i]).isLoaded) {
                    StartCoroutine(FullyLoadAdditiveScene(i));
                }
            }
            else {
                subLevelPortals[i].SetActive(false);
            }
        }
        /**
        queen1Active = true;
        queen2Active = false;
        queen3Active = false;
        queenState2.enabled = false;
        queenState3.enabled = false;
        dialogueActive = false;
        dialogueStart = 0;
        dialogueEnd = 0;
        **/
        myGameDataTracker.GetComponent<GameDataTracker>().updateAttempts(numAttempts);
        updateScore(0);
        //Reset paddles to correct positions
        for(int i = 0; i < paddles.Length; i++) {
            paddles[i].transform.localRotation = paddleTransforms[i].localRotation;
            paddles[i].transform.position = paddleTransforms[i].position;
            paddles[i].GetComponent<HingeJoint>().axis = paddleHinges[i].axis;  
        }
    }
    public void updateScore(int addedScore) {
        score += addedScore;
        myGameDataTracker.GetComponent<GameDataTracker>().updateScore(score);
        /**
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
        **/
    }

    public void updateDialoguePositive() {
        int selectedDialogue = (int)UnityEngine.Random.Range(0, posStatements.Length); //Consider different method of randomization
        dialogueText.text = posStatements[selectedDialogue];
        dialogueActive = true;
        dialogueStart = Time.time;
        dialogueEnd = dialogueStart + dialogueUptime;
        dialogueBox.SetActive(true);
    }

    public void updateDialogueNeutral() {
        int selectedDialogue = (int)UnityEngine.Random.Range(0, neutralStatements.Length); //Consider different method of randomization
        dialogueText.text = neutralStatements[selectedDialogue];
        dialogueActive = true;
        dialogueStart = Time.time;
        dialogueEnd = dialogueStart + dialogueUptime;
        dialogueBox.SetActive(true);
    }

    public void resetPinball (bool levelReset) {
        if(!levelReset) {
            reduceNumAttempts(1);
            if(numAttempts <= 0) {
                SceneManager.LoadScene(gameOverScene);
                //Should remove the game data when game has ended for clean slate
                Destroy(myGameDataTracker);
            }
        }
        myLauncher.GetComponent<LauncherScript>().newAttempt();
        myLauncherDoor.GetComponent<LauncherDoorScript>().openLauncherDoor();
        myGameDataTracker.GetComponent<GameDataTracker>().updateAttempts(numAttempts);
    }

    public void reduceNumAttempts(int reduction) {
        numAttempts -= reduction;
        if (numAttempts < 0) {
            numAttempts = 0;
        }
        myGameDataTracker.GetComponent<GameDataTracker>().updateAttempts(numAttempts);
    }
    public void addNumAttempts(int addition) {
        numAttempts += addition;

        myGameDataTracker.GetComponent<GameDataTracker>().updateAttempts(numAttempts);
    }
    public int returnScore() {
        return score;
    }
    public int returnNumAttempts() {
        return numAttempts;
    }

}
