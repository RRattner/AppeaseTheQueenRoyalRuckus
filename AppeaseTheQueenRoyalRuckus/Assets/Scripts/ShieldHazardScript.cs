using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ShieldHazardScript : MonoBehaviour
{
    private Vector3 shieldDirection;
    private BoxCollider myCollider;
    [SerializeField] private GameManager myGameManager;
    [SerializeField] private float triggerScale = 1.25f;
    
    private BoxCollider collisionCheckTrigger;
    void Start()
    {
        shieldDirection = transform.TransformDirection(Vector3.up);
        myCollider = GetComponent<BoxCollider>();
        myCollider.isTrigger = false;
        collisionCheckTrigger = gameObject.AddComponent<BoxCollider>();
        collisionCheckTrigger.size = myCollider.size * triggerScale;
        collisionCheckTrigger.center = myCollider.center;
        collisionCheckTrigger.isTrigger = true;
    }


    private void OnTriggerStay(Collider thisCollider) {
        if(thisCollider.gameObject.CompareTag("Pinball")) {
        if(Physics.ComputePenetration(collisionCheckTrigger, transform.position, transform.rotation,
         thisCollider, thisCollider.transform.position, thisCollider.transform.rotation,
          out Vector3 collisionDirection, out float penetrationDepth)) {
            float dot = Vector3.Dot(shieldDirection.normalized, collisionDirection.normalized);
            print("Current collision dot is: "+dot+"\n");
            if(dot >= 0) {
                Physics.IgnoreCollision(myCollider, thisCollider, false);
            }
            else {
                Physics.IgnoreCollision(myCollider, thisCollider, true);
            }
          }

        }
    }
    private void OnCollisionStay(Collision thisCollision) {

    }

    void OnDrawGizmosSelected() {
        Vector3 myDirection;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, shieldDirection);
        //Gizmos.DrawRay(transform.position, Vector3.up);

    }
}
