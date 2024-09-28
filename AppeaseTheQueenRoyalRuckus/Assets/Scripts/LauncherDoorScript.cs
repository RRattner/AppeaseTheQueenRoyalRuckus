using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LauncherDoorScript : MonoBehaviour
{
    [SerializeField] private GameObject launcherDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    public void OnTriggerEnter(Collider collided) {
        if(collided.gameObject.tag == "Pinball") {
            shutLauncherDoor();
        }
    }

    public void shutLauncherDoor() {
        launcherDoor.SetActive(true);
    }
}
