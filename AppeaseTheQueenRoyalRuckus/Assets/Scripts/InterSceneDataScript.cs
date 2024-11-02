using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterSceneDataScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool exitedThroughAreaOne;
    private int score;
    private int numAttempts;

    private Vector3 pinballExitEntryLoc;
 
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        exitedThroughAreaOne = false;
        score = 0;
        numAttempts = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setScore(int storedScore) {
        score = storedScore;
    }
    public int returnScore() {
        return score;
    }
    public void setNumAttempts(int storedNumAttempts) {
        numAttempts = storedNumAttempts;;
    }
    public int returnNumAttempts() {
        return numAttempts;
    }
    public void setEntryExitLoc(Vector3 entryExitLoc) {
        pinballExitEntryLoc.x = entryExitLoc.x;
        pinballExitEntryLoc.y = entryExitLoc.y;
        pinballExitEntryLoc.z = entryExitLoc.z;
    }
    public Vector3 returnEntryExitLoc() {
        return pinballExitEntryLoc;
    }
    public void areaOneExit() {
        exitedThroughAreaOne = true;
    }
    public int checkSceneReEntry() {
        if (exitedThroughAreaOne) {
            return 1;
        }
        else {
            return -1;
        }

    }
}
