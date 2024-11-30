using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private String mainSceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Pinball") {
            Destroy(other.gameObject);
            SceneManager.LoadScene(mainSceneName);
        }
    }
}
