using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LauncherDoorScript : MonoBehaviour
{
    [SerializeField] private GameObject launcherDoor;
    [SerializeField] private GameObject myManager;

    private bool pinballInPlay;
    // Start is called before the first frame update
    void Start()
    {
        pinballInPlay = false;
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    public void OnTriggerEnter2D(Collider2D collided) {
        if(collided.gameObject.tag == "Pinball" && !pinballInPlay) {
            shutLauncherDoor();
        }
    }

    public void shutLauncherDoor() {
        launcherDoor.SetActive(true);
        pinballInPlay = true;
    }
    public void openLauncherDoor() {
        launcherDoor.SetActive(false);
        pinballInPlay = false;
    }
}
