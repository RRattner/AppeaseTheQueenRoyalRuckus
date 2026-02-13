using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchCollectibleScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject myEntryPortal;
    [SerializeField] private GameObject sublevelManager;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Pinball"))
        {
            sublevelManager.GetComponent<SublevelManagerScript>().incrementCollectibles();
            //myEntryPortal.SetActive(false);
            this.gameObject.SetActive(false);
        }
        
    }
}
