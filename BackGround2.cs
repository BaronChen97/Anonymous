using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround2 : MonoBehaviour {

    private Material material;
    private float runSpeed = 0.3F;
    private float bgSpeed = 3.0F;

	// Use this for initialization
	void Start () {

        material = transform.GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        this.imageControl();
	}

    //change background image
    void imageControl()
    {

        if (Time.time > 3)
        {
            transform.Translate(Vector3.back * Time.deltaTime * bgSpeed);

            if (transform.position.z <= 2.7F)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 2.7F);
                this.imageReset();
            }
        }
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
