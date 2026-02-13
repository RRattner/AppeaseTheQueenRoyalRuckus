using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SublevelManagerScript : MonoBehaviour
{
    [SerializeField] private int numObjectsToCollect;
    [SerializeField] private int numObjectsCollected;
    private bool levelObjectiveComplete;

    // Start is called before the first frame update
    void Start()
    {
        numObjectsCollected = 0;
        levelObjectiveComplete = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void incrementCollectibles()
    {
        numObjectsCollected++;
        if (numObjectsCollected >= numObjectsToCollect)
        {
            levelObjectiveComplete = true;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pinball"))
        {
            if (levelObjectiveComplete) {
                print("level complete!\n");
            }
            else {
                print("level incomplete!\n");
            }
        }
    }
}
