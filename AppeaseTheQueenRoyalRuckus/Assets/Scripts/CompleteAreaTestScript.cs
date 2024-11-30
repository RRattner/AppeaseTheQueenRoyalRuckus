using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class CompleteAreaTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject myGameDataTracker;
    [SerializeField] private int entryPortalIndex;

    void Start()
    {
        myGameDataTracker = GameObject.FindGameObjectsWithTag("InterSceneData")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collided) {
        if(collided.gameObject.tag == "Pinball") {
            myGameDataTracker.GetComponent<GameDataTracker>().updateSublevelsCompleted(entryPortalIndex);
            this.gameObject.SetActive(false);
        }
    }
}
