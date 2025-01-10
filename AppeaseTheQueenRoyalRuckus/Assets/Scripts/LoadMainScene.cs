using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject myGameDataTracker;
    [SerializeField] private int portalIndex;
    [SerializeField] private GameObject myGameManager;
    void Start()
    {
        myGameDataTracker = GameObject.FindGameObjectsWithTag("InterSceneData")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Pinball") {
            Destroy(other.gameObject);
            //SceneManager.LoadScene(mainSceneName);
            myGameManager.GetComponent<GameManager>().resetPinball(true);
            myGameDataTracker.GetComponent<GameDataTracker>().toggleLevel(false, portalIndex);
        }
    }
}
