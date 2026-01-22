using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPortalScript : MonoBehaviour
{
    [SerializeField] private GameObject exitPortal;
    [SerializeField] private bool exitPortalOneWay;
    [SerializeField] private float portalDeactivationTimer;
    [SerializeField] private GameObject myCamera;
    //The index of the camera that should be used after this portal is passed through.
    [SerializeField] private int cameraIndex;
    public bool isTestPortal;
    private Rigidbody2D pinballRigidbody;
    private Vector2 savedPinballVelocity;

    private float exitPortalInactiveTime;

    private float pinballGravityScale;

    void Start()
    {
        exitPortalInactiveTime = -1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator portalCameraMove(GameObject myPinball)
    {
        savedPinballVelocity = pinballRigidbody.velocity;
        pinballGravityScale = myPinball.GetComponent<Rigidbody2D>().gravityScale;
        pinballRigidbody.velocity = Vector2.zero;
        pinballRigidbody.gravityScale = 0;
        myPinball.transform.Translate(exitPortal.transform.position - myPinball.transform.position);
        myCamera.GetComponent<CameraMove>().moveCamera(cameraIndex);
        yield return new WaitForSeconds(myCamera.GetComponent<CameraMove>().cameraMoveDuration());
        

        pinballRigidbody.gravityScale = pinballGravityScale;
        myPinball.GetComponent<Rigidbody2D>().velocity = savedPinballVelocity;
    }

    void OnTriggerEnter2D(Collider2D pinballCollider)
    {
        if ((pinballCollider.gameObject.tag == "Pinball") && (exitPortalInactiveTime < Time.time))
        {
            print("Collision Detected.");
            GameObject myPinball = pinballCollider.gameObject;
            Transform newLocation = exitPortal.transform;

            pinballRigidbody = myPinball.GetComponent<Rigidbody2D>();

            //StartCoroutine(portalCameraMove(myPinball));
            if (!exitPortalOneWay)
            {
                exitPortal.GetComponent<LocalPortalScript>().portalInactive();
            }
            else
            {
                //Trigger animation of one-way portal opening and closing
            }
            StartCoroutine(portalCameraMove(myPinball));

            //myPinball.transform.position = exitPortal.transform.position;
            

        }
    }
    private void portalInactive()
    {
        exitPortalInactiveTime = Time.time + portalDeactivationTimer;
    }
}
