using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPortalScript : MonoBehaviour
{
    [SerializeField] private GameObject exitPortal;
    [SerializeField] private bool exitPortalOneWay;
    [SerializeField] private float portalDeactivationTimer;
    public bool isTestPortal;
    private Rigidbody2D pinballRigidbody;

    private float exitPortalInactiveTime;

    void Start()
    {
        exitPortalInactiveTime = -1;
    }

    // Update is called once per frame
    void Update()
    {
        /**if (exitPortalInactiveTime < Time.time)
        {
            exitPortal.SetActive(true);
        }
        if (isTestPortal)
        {
            print("Current coordinates to move to are: x:"+exitPortal.transform.position.x+", y: "+exitPortal.transform.position.y+"\n");
        }**/
    }

    void OnTriggerEnter2D(Collider2D pinballCollider)
    {
        if ((pinballCollider.gameObject.tag == "Pinball") && (exitPortalInactiveTime < Time.time))
        {
            print("Collision Detected.");
            GameObject myPinball = pinballCollider.gameObject;
            Transform newLocation = exitPortal.transform;

            pinballRigidbody = myPinball.GetComponent<Rigidbody2D>();
            if (!exitPortalOneWay)
            {
                exitPortal.GetComponent<LocalPortalScript>().portalInactive();
            }
            else
            {
                //Trigger animation of one-way portal opening and closing
            }
            

            //myPinball.transform.position = exitPortal.transform.position;
            myPinball.transform.Translate(exitPortal.transform.position - myPinball.transform.position);
        }
    }
    private void portalInactive()
    {
         exitPortalInactiveTime = Time.time + portalDeactivationTimer;
    }
}
