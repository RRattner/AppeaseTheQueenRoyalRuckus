using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    //Used to store how long the button should be inactive after the ball makes contact with it.
    [SerializeField] private float inactiveTimer;
    //Tracks the timestamp of when the button was last interacted with.
    private float lastButtonHitTime;
    
    //Unique script used for each button.  Each will have a function called "activateButtonFunction"
    [SerializeField] private GameObject toggleableWall;
    [SerializeField] private Animator buttonAnimatior;
    [SerializeField] private String buttonAnimationName;
    void Start()
    {
        lastButtonHitTime = inactiveTimer * -1;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pinball") {
            print("Collision detected!\n");
            float curTime = Time.time;
            if ((curTime - lastButtonHitTime) >= inactiveTimer)
            {
                lastButtonHitTime = curTime;
                buttonAnimatior.Play(buttonAnimationName, 0, 0);
                if (toggleableWall.activeSelf)
                {
                    toggleableWall.SetActive(false);
                }
                else
                {
                    toggleableWall.SetActive(true);
                }
            }
            else
            {
                print("Too soon, button hit before cooldown has ended.  Need to wait "+(curTime - lastButtonHitTime)+" of "+inactiveTimer+" seconds\n");
            }
        }
    }
    void Update()
    {
        
    }
}
