using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    //Camera method will be moving
    [SerializeField] private GameObject myCamera;
    //An array of game objects representing the points the camera will move to
    [SerializeField] private GameObject[] myCameraPoints;
    //An array of Vector2s storing the actual locations to move to
    private Vector2[] myCameraLocs;
    //The distance the camera will move on the x axis per frame
    private float xMovement;
    //The distance the camera will move on the y axis per frame
    private float yMovement;
    //The amount of time it will take for the camera to move to the next location
    [SerializeField] private float cameraMoveTime;
    //The current location of the camera.
    private Vector2 currentCameraLoc;
    //The current destination point of the camera.  Updated whenever a move begins.
    private Vector2 currentCameraDestination;
    //Used to track whether or not the camera is currently moving.
    private bool cameraMoveEngaged;
    // Start is called before the first frame update
    private float timeMoved;
    void Start() {
        if (myCameraPoints.Length != 0) {
            myCameraLocs = new Vector2[myCameraPoints.Length];
            for (int i = 0; i < myCameraPoints.Length; i++) {
                myCameraLocs[i] = new Vector2(myCameraPoints[i].transform.position.x, myCameraPoints[i].transform.position.y);
            }
            currentCameraLoc = myCameraLocs[0];
        }
        else {
            print("Error, camera locations not set.\n");
        }
        xMovement = 0;
        yMovement = 0;
        currentCameraDestination = currentCameraLoc;
        cameraMoveEngaged = false;
        timeMoved = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraMoveEngaged && timeMoved < cameraMoveTime)
        {
            float distToMoveX;
            float distToMoveY;
            if (Time.deltaTime + timeMoved > cameraMoveTime)
            {
                distToMoveX = xMovement * (cameraMoveTime - timeMoved);
                distToMoveY = yMovement * (cameraMoveTime - timeMoved);
            }
            else
            {
                distToMoveX = xMovement * Time.deltaTime;
                distToMoveY = yMovement * Time.deltaTime;
            }
            timeMoved += Time.deltaTime;
            myCamera.transform.Translate(distToMoveX, distToMoveY, 0f);
            if (timeMoved >= cameraMoveTime)
            {
                cameraMoveEngaged = false;
                timeMoved = 0;
                //Failsafe to get position exactly correct
                myCamera.transform.Translate(currentCameraDestination.x - myCamera.transform.position.x, currentCameraDestination.y - myCamera.transform.position.y, 0);
                currentCameraLoc = currentCameraDestination;
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            moveCamera(1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            moveCamera(0);
        }

    }

    public void moveCamera(int cameraPointIndex) {
        if(!cameraMoveEngaged) {
            float distToMoveX =  myCameraLocs[cameraPointIndex].x - currentCameraLoc.x;
            float distToMoveY = myCameraLocs[cameraPointIndex].y - currentCameraLoc.y;
            if (distToMoveX != 0 || distToMoveY != 0) {
                cameraMoveEngaged = true;
                currentCameraDestination = myCameraLocs[cameraPointIndex];
                xMovement = distToMoveX / cameraMoveTime;
                yMovement = distToMoveY / cameraMoveTime;
            }
        }
    }
}
