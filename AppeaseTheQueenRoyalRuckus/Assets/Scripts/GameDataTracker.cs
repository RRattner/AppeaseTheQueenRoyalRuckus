using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataTracker : MonoBehaviour
{
    public static GameDataTracker Instance;
    [SerializeField] private int Score;
    [SerializeField] private int Attempts;
    [SerializeField] private bool[] SublevelsOpen;
    [SerializeField] private bool[] SublevelsCompleted;
    // Start is called before the first frame update
    
    void Awake() {
    //Should allow for persistant game manager across levels without needing to do special tricks to save game state data
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
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
    }
    public void updateAttempts(int myAttempts) {
        Attempts = myAttempts;
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
