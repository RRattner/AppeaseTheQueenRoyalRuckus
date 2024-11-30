using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScriptSceneMove : MonoBehaviour
{
    // Start is called before the first frame update
    private bool portalResolved;
    private GameObject myGameDataTracker;
    [SerializeField] private int portalIndex;
    [SerializeField] private string levelName;
    void Start()
    {
        myGameDataTracker = GameObject.FindGameObjectsWithTag("InterSceneData")[0];
        //Close the portal if it has yet to be opened or has been completed
        if(myGameDataTracker.GetComponent<GameDataTracker>().checkSublevelOpen(portalIndex) || myGameDataTracker.GetComponent<GameDataTracker>().checkSublevelComplete(portalIndex)) {
            portalResolved = true;
            //this.gameObject.SetActive(false);
        }
        else {
            portalResolved = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collided) {
        if(collided.gameObject.tag == "Pinball" /**&& !portalResolved && collided.gameObject.GetComponent<PinballScript>().AbleToEnter()**/) {
            SceneManager.LoadScene(levelName);
        }
    }

    //Checking to make sure portal resolution script functions as intended.
    public void TestPortalResolved() {
        portalResolved = true;
        //this.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        myGameDataTracker.GetComponent<GameDataTracker>().updateSublevelsCompleted(portalIndex);
    }
}
