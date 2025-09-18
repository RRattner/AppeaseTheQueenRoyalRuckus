using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int ballCreationOffsetX;
    [SerializeField] private int ballCreationOffsetY;
    [SerializeField] private GameObject pinball;
    [SerializeField] private float maxPower;
    [SerializeField] private float minPower;
    [SerializeField] private float power;
    private Vector3 instantiationLocation;
    private GameObject createdPinball;
    private bool pinballLaunched;
    void Start()
    {
        instantiationLocation = new Vector3(this.transform.position.x + ballCreationOffsetX, this.transform.position.y + ballCreationOffsetY, this.transform.position.z);
        createdPinball = null;
        pinballLaunched = false;
    }

    // Update is called once per frame
    void Update()
    {
    
        if(!pinballLaunched) {
            //USe GetKey instead of GetKeyDown, as GetKeyDown only tracks the initial press, not the hold, and GetKey tracks the hold
            if(Input.GetKey(KeyCode.W)) {
                //print("Key A read as being pressed.\n");
                power += 500 * Time.deltaTime;
                if(power > maxPower) {
                    power = maxPower;
                }
            }
            else{
                power -= 500 * Time.deltaTime;
                if(power < minPower) {
                    power = minPower;
                }
            }
            if(Input.GetKeyDown("space") && power > minPower) {
                launchPinball();
            }
        }
    }

    //Method that handles closing off the launcher area after ball has entered main board


    public void launchPinball() {
        if(pinballLaunched == false) {
            createdPinball = Instantiate(pinball, instantiationLocation, Quaternion.identity);
            createdPinball.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, power, 0));
            pinballLaunched = true;
        }
    }
    public void OnCollisionEnter2D(Collision2D collided) {
        if(collided.gameObject.tag == "Pinball") {
            //print("Pinball Collision detected.\n");
            Destroy(collided.gameObject);
            pinballLaunched = false;
            createdPinball = null;
        }
    }

    public void newAttempt() {
        pinballLaunched = false;
    }

    //Used when loading in from a sublevel
    public void manualSetPinballLaunched() {
        pinballLaunched = true;
    }
    
}
