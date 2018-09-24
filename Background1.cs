using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background1 : MonoBehaviour {
    
    private Material material;
    private float runSpeed = 0.3F;
	// Use this for initialization
	void Start () {
        material = transform.GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        this.imageReset();
	}

    //Background image offset
    void imageReset()
    {
        if (transform.position == new Vector3(0F, -1F, 2.7F))
        {
            float offset = -Time.time * runSpeed;
            material.mainTextureOffset = new Vector3(0, offset);
        }
    }
}
