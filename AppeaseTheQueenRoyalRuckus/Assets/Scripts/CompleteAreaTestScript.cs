using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class CompleteAreaTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject EntryPortal;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collided) {
        if(collided.gameObject.tag == "Pinball") {
            EntryPortal.GetComponent<PortalScript>().TestPortalResolved();
        }
    }
}
