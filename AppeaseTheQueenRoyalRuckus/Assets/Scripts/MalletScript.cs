using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalletScript : MonoBehaviour
{
    public int extraImpulseForce;

    //public int delayTime;

    //float collisionTriggerTime;

    //bool onCooldown;

    void Start() {
        //onCooldown = false;
        //collisionTriggerTime = 0;
    }


    [SerializeField] private float speed = 2f;

    private void Update()
    {
        transform.Rotate(360 * speed * Time.deltaTime, 0, 0); 
    }

    void OnCollisionEnter(Collision other) {
        /**
        if(onCooldown) {
            print("On cooldown!\n");
            if(Time.time - collisionTriggerTime >= delayTime) {
                onCooldown = false;
                print("Cooldown over!\n");
            }
        }
        **/
        if (other.gameObject.CompareTag("Pinball")) {
            /**
            if(!onCooldown) {
                    onCooldown = true;
                    collisionTriggerTime = Time.time;
            }
            **/
            other.gameObject.GetComponent<Rigidbody>().AddForce(other.impulse * extraImpulseForce);
            //other.impulse.x *= 5;
        }
    }
}