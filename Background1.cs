using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background1 : MonoBehaviour {
    
    private Material material;
    private float runSpeed = 0.2F;
    public GameObject backGround;
    Vector3 backGroundPosition;

	// Use this for initialization
	void Start () {
        material = transform.GetComponent<Renderer>().material;
        backGroundPosition = backGround.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.imageReset();
	}

    //Background image offset
    void imageReset()
    {
        if (transform.position == new Vector3(backGroundPosition.x, backGroundPosition.y, backGroundPosition.z))
        {
            float offset = Time.time * runSpeed;

            // Return to the initial background position
            material.mainTextureOffset = new Vector3(0, offset);
        }
    }
}
