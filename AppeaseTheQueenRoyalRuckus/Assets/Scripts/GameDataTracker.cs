using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataTracker : MonoBehaviour
{
    [SerializeField] private int Score;
    [SerializeField] private int Attempts;
    [SerializeField] private bool[] SublevelsOpen;
    [SerializeField] private bool[] SublevelsCompleted;
    [SerializeField] private string InitLevelName;

    [SerializeField]private GameObject MainLevelRoot;
    //Keep updated as additional subelevels are added
    [SerializeField] private GameObject SubLevel1Root;



    [SerializeField] private GameObject myUIManager;
    // Start is called before the first frame update
    void Awake() {
        //Commented our for ease of editing, re-enable when launching from main menu
        //SceneManager.LoadScene(InitLevelName, LoadSceneMode.Additive);
    }
    void Start()
    {
        MainLevelRoot = GameObject.FindGameObjectsWithTag("MainLevelRoot")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int myScore) {
        Score = myScore;
        myUIManager.GetComponent<UIManagerScript>().updateScoreText(myScore);
    }
    public void updateAttempts(int myAttempts) {
        Attempts = myAttempts;
        myUIManager.GetComponent<UIManagerScript>().updateNumAttemptsText(myAttempts);
    }
    public void updateSublevelsOpen(int sublevelIndex) {
            SublevelsOpen[sublevelIndex] = true;
            //Keep updated as additional subelevels are added
            if(sublevelIndex == 0) {
                SubLevel1Root = GameObject.FindGameObjectsWithTag("SubLevel1Root")[0];
                SubLevel1Root.SetActive(false);
                //toggleLevel(false, 0);
            }
    }
    public void updateSublevelsCompleted(int sublevelIndex) {
            SublevelsCompleted[sublevelIndex] = true;

    }
    public void toggleLevel (bool enabled, int levelIndex) {
        //Keep updated as additional subelevels are added
        //Main level can always be safely enabled / disabled when loading sublevel
        if (levelIndex == 0) {
            if(enabled) {
                SubLevel1Root.SetActive(true);
                MainLevelRoot.SetActive(false);
                SubLevel1Root.GetComponent<GameManager>().updateGameData();
            }
            else {
                MainLevelRoot.SetActive(true);
                SubLevel1Root.SetActive(false);
                MainLevelRoot.GetComponent<GameManager>().updateGameData();
            }
        }
    }
    
    public int getScore() {
        return Score;
    }
    public int getAttempts() {
        return Attempts;
    }
    public bool checkSublevelOpen(int sublevel) {
        return SublevelsOpen[sublevel];
    }
    public bool checkSublevelComplete(int sublevel) {
        return SublevelsCompleted[sublevel];
    }
}
