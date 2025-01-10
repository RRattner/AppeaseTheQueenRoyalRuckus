using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinballDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject myGameManager;
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
            Destroy(other.gameObject);
            //Reset pinball set to false because this method is used when pinball is lost due to hitting the gutter, not due to the level being reset
            myGameManager.GetComponent<GameManager>().resetPinball(false);
            print("Ball Detected.\n");
            //SceneManager.LoadScene("Menu");
        }
    }
}
