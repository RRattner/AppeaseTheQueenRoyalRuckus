using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingedPaddleScript : MonoBehaviour
{
public float restingPosition = 0f;
public float activePosition = 45f;
public float paddleStrength = 10000f;

    public float paddleDamper = 150f;

    private bool goneUp;

    public string paddleInputKey;

HingeJoint2D myHinge;

    // Start is called before the first frame update
    void Start()
    {
        myHinge = GetComponent<HingeJoint2D>();
        goneUp = false;
        //myHinge.useSpring = true;
    }

    // Update is called once per frame
    
    void Update()
    {

        if (Input.GetAxis(paddleInputKey) == 1)
        {
            print("Paddle input detected!\n");
            myHinge.GetComponent<Rigidbody2D>().AddTorque(10000);
            goneUp = true;
        }
        else if (goneUp)
        {
            print("Paddle released!\n");
            //myHinge.GetComponent<Rigidbody2D>().AddTorque(-100000);
            goneUp = false;
        }

        //myHinge.GetComponent<Rigidbody2D>().AddTorque(-10000);
        myHinge.useLimits = true;
    }
}
