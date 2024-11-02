using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAreaScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject myGameManager;
    [SerializeField] private Vector3 pinballOriginLoc;
    [SerializeField] private Vector3 cameraOriginLoc;
    [SerializeField] private GameObject myCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Pinball"))
        {
            other.gameObject.transform.position = pinballOriginLoc;
            myCamera.gameObject.transform.position = cameraOriginLoc;
            other.gameObject.GetComponent<PinballScript>().SetJustExitedPortal();
        }
    }
}
