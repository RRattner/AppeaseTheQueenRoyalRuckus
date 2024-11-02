using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool justExitedPortal;
    [SerializeField] private float portalEntryBuffer;
    private float timeElapsedSincePortal;
    void Start()
    {   
        justExitedPortal = false;
        timeElapsedSincePortal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(justExitedPortal) {
            if(timeElapsedSincePortal < portalEntryBuffer) {
                timeElapsedSincePortal += Time.deltaTime;
            }
            else {
                justExitedPortal = false;
                timeElapsedSincePortal = 0;
                print("cooldown over!\n");
            }
        }
    }
    public void SetJustExitedPortal() {
        justExitedPortal = true;
    }
    public bool AbleToEnter() {
        return !justExitedPortal;
    }
}
