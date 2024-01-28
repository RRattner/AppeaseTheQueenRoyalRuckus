using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    private bool paddleSwingingUp;
    private bool paddleSwingingDown;
    private float curRotation;
    public GameObject myPaddle;

    public GameObject myPinball;

    private Vector2 startPosition;
    public float speed;

   

    // Start is called before the first frame update
    void Start()
    {
        paddleSwingingUp = false;
        paddleSwingingDown = false;
        curRotation = 0f;
        startPosition = myPinball.transform.position;
        //myPaddle = myPaddle.GetComponent<RigidBody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space)) {
            myPinball.transform.position = startPosition;
        }
        if(Input.GetKeyDown(KeyCode.CapsLock) && !paddleSwingingUp && !paddleSwingingDown) {
            paddleSwingingUp = true;
        }
        if(paddleSwingingUp) {
            if(curRotation >= 45.0f) {
                paddleSwingingUp = false;
                paddleSwingingDown = true;
            }
            curRotation += 0.1f * speed * Time.deltaTime;
             myPaddle.transform.Rotate(0.0f, 0.0f, 0.1f * speed * Time.deltaTime);
            //this.GetComponent<Rigidbody2D>().rotation = curRotation;         
        }
        if(paddleSwingingDown) {
            curRotation -= 0.1f * speed * Time.deltaTime;
             myPaddle.transform.Rotate(0.0f, 0.0f, -0.1f * speed * Time.deltaTime);
            //this.GetComponent<Rigidbody2D>().rotation = curRotation; 
            if(curRotation <= 0f) {
                paddleSwingingDown = false;
            }
        }
    }

    void swingPaddle() {
        print("Paddle Swing Registered.\n");
        // if(paddleSwingingUp) {
        //     myPaddle.GetComponent<Rigidbody2D>().MoveRotation(new Vector3(0, 0, 45.0f * Time.fixedDeltaTime) );
        // }
            //print("Current Rotation: "+curRotation+"\n");
        // while(curRotation > 0f) {
        //     curRotation -= 1.0f;
        //     myPaddle.transform.Rotate(0.0f, 0.0f, -1.0f);
        //     print("Current Rotation: "+curRotation+"\n");
        // }
        
        //paddleSwinging = false;
    }
    void onKeyPress() {

    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Pinball"))
        {
            print("Ball Detected.\n");
            //other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0.0f, 10.0f);
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Pinball"))
        {
            print("Ball Gone.\n");
        }
    }
}
