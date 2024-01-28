using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndScoreScript : MonoBehaviour
{
    public GameObject GameManager;

    public int scoreToAdd;

    public int extraImpulseForce;

    public float delayTime;

    float collisionTriggerTime;

    bool onCooldown;

    public GameObject mySound;

    void Start() {
        onCooldown = false;
        collisionTriggerTime = 0;
    }

    private void Update()
    {
    }

    void OnCollisionEnter(Collision other) {
        if(onCooldown) {
            print("On cooldown!\n");
            if(Time.time - collisionTriggerTime >= delayTime) {
                onCooldown = false;
                print("Cooldown over!\n");
            }
        }
        if (other.gameObject.CompareTag("Pinball")) {
            if(!onCooldown) {
                    onCooldown = true;
                    collisionTriggerTime = Time.time;
                    GameManager.GetComponent<GameManager>().updateScore(scoreToAdd);
                    mySound.GetComponent<AudioSource>().Play();
            }
        }
    }
}

