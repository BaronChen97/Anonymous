using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour {
    public GameObject rocket;               // Refer to the object that we are going to drag

    public float xMin, xMax, zMin, zMax;    // Set up xm z Minimum and Maximun
    public Vector3 rocketCenter;            // The rocket object center point
    public Vector3 touchPoint;              // The touch point
    public Vector3 offset;                  // Vector between touch point to the rocket center
    Vector3 newRocketCenter;                // New center position for the gameOBject
    RaycastHit hit;                         // Store hit object information
    public bool touching = false;           // Will be used to detect user touching the screen or not      

    public void BoundaryConstructor(float aMin, float aMax, float bMin, float bMax)
    {
        xMin = aMin;
        xMax = aMax;
        zMin = bMin;
        zMax = bMax;
    }

    // Update is called once per frame
    void FixedUpdate () {

#if UNITY_EDITOR    // Added [UNITY_EDITOR] will let the inside code only work on Unity editor
                    // Adding this will help the developer who donot have android phone
                    // By moving the rocket by holding the left mouse, to be easier test the program

        // Holding the left mouse to moving the rocket
        // Every frame when player click the left mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Convert mouse click position to a ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // If the ray hit a collider
            if (Physics.SphereCast(ray, 0.2f, out hit))
            {
                rocket = hit.collider.gameObject;

                // To check the object name equal to "Rocket" or not
                if (VerifyObjectName(rocket))
                {
                    rocketCenter = rocket.transform.position;
                    touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    offset = touchPoint - rocketCenter;
                    touching = true;
                }
            }
        }

        // Every frame when player hold on the left mouse
        if (Input.GetMouseButton(0))
        {
            // If the player currently holding the left mouse and move it
            if (touching)
            {
                touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newRocketCenter = NewRocketCenterPosition(touchPoint, offset);
                rocket.transform.position = new Vector3(
                    SafeZoneRestrict(newRocketCenter.x, xMin, xMax),
                    rocketCenter.y,
                    SafeZoneRestrict(newRocketCenter.z, zMin, zMax));
            }
        }

        // When player released the left mouse
        if (Input.GetMouseButtonUp(0))
        {
            touching = false;
        }
#endif

        // Moving the rocket by touch the phone screen to moving it
        if (Input.touchCount > 0)
        {
            // GetTouch(0) is mean the first finger that touch the screen
            // When player pressed down on the phone screen
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Convert touch position to a ray
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                // If the ray hit a collider
                if (Physics.SphereCast(ray, 0.2f, out hit))
                {
                    rocket = hit.collider.gameObject;

                    // To check the object name equal to "Rocket" or not
                    if (VerifyObjectName(rocket))
                    {
                        rocketCenter = rocket.transform.position;
                        touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        offset = touchPoint - rocketCenter;
                        touching = true;
                    }
                }
            }
            // When player holding the finger and moving on the screen
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && rocket)
            {
                if (touching)
                {
                    touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    newRocketCenter = NewRocketCenterPosition(touchPoint, offset);
                    rocket.transform.position = new Vector3(
                        SafeZoneRestrict(newRocketCenter.x, xMin, xMax),
                        rocketCenter.y,
                        SafeZoneRestrict(newRocketCenter.z, zMin, zMax));
                }
            }
            // When player released the finger and moving on the screen
            else if (Input.GetTouch(0).phase == TouchPhase.Ended && rocket)
            {
                touching = false;
            }
        }
    }

    // To check the object name equal to "Rocket" or not
    public bool VerifyObjectName(GameObject rocket)
    {
        if (rocket.name == "Rocket")
            return true;
        else
            return false;
    }

    // Set boundary to restrict rocket do not out of the safe area
    // Return the edge of the boundary if the userInput less than min or greater than max
    public float SafeZoneRestrict(float userInput, float min, float max)
    {
        if (userInput >= min && userInput <= max)
            return userInput;
        else
            return Mathf.Clamp(userInput, min, max);
    }

    //Base on touch point and offset to set up a new rocket center position
    public Vector3 NewRocketCenterPosition(Vector3 touchPoint, Vector3 offset)
    {
        Vector3 newRocketCenterPosition;
        newRocketCenterPosition = touchPoint - offset;
        
        return newRocketCenterPosition;
    }
}