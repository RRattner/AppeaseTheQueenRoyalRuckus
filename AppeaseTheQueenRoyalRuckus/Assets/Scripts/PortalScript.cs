using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool portalResolved;
    [SerializeField] private Vector3 newPinballLoc;
    [SerializeField] private Vector3 newCameraLoc;
    [SerializeField] private GameObject myCamera;
    void Start()
    {
        portalResolved = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collided) {
        if(collided.gameObject.tag == "Pinball" && !portalResolved && collided.gameObject.GetComponent<PinballScript>().AbleToEnter()) {
            collided.gameObject.transform.position = newPinballLoc;
            myCamera.gameObject.transform.position = newCameraLoc;
        }
    }

    //Checking to make sure portal resolution script functions as intended.
    public void TestPortalResolved() {
        portalResolved = true;
        //this.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
