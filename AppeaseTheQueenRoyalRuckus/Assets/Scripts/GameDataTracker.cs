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


    [SerializeField] private GameObject myUIManager;
    // Start is called before the first frame update
    void Awake() {
        SceneManager.LoadScene(InitLevelName, LoadSceneMode.Additive);
    }
    void Start()
    {
        
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
    }
    public void updateSublevelsCompleted(int sublevelIndex) {
            SublevelsCompleted[sublevelIndex] = true;

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
