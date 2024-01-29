using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinballDestroy : MonoBehaviour
{
    // Start is called before the first frame update
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
            print("Ball Detected.\n");
            SceneManager.LoadScene("Menu");
        }
    }
}
