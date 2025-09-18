using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript2D : MonoBehaviour
{
    public float motorSpeed;
    public string paddleInputKey;
    [SerializeField] private HingeJoint2D myHinge;
    private JointMotor2D myMotor;
    void Start()
    {
        myMotor = myHinge.motor;    
    }


    void FixedUpdate()
    {
        if (Input.GetAxis(paddleInputKey) == 1)
        {
            myMotor.motorSpeed = motorSpeed;
        }
        else
        {
            myMotor.motorSpeed = -motorSpeed;
        }
        myHinge.motor = myMotor;
    }
}
