using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingedPaddleScript : MonoBehaviour
{
public float restingPosition = 0f;
public float activePosition = 45f;
public float paddleStrength = 10000f;

public float paddleDamper = 150f;

public string paddleInputKey;

HingeJoint myHinge;

    // Start is called before the first frame update
    void Start()
    {
        myHinge = GetComponent<HingeJoint>();
        myHinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {  
        JointSpring mySpring = new JointSpring();
        mySpring.spring = paddleStrength;
        mySpring.damper = paddleDamper;

        if(Input.GetAxis(paddleInputKey) == 1) {
            mySpring.targetPosition = activePosition;
        }
        else {
            mySpring.targetPosition = restingPosition;
        }
        myHinge.spring = mySpring;
        myHinge.useLimits = true;
    }
}
