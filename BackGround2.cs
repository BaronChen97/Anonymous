using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround2 : MonoBehaviour {

    private Material material;
    private float runSpeed = 0.2F;
    private float bgSpeed = 3.4F;
    public GameObject backGround;
    Vector3 backGroundPosition;
    Vector3 backGroundSize;
    private int seconds = 0;
    private bool drop = false;

	// Use this for initialization
    void Start () {
        StartCoroutine("secondsIncrease");
        material = transform.GetComponent<Renderer>().material;
        backGroundPosition = backGround.transform.position;
        backGroundSize = backGround.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (seconds % 30 == 0)
            drop = true;
        if (seconds % 60 == 0)
        {
            backGround.transform.position = new Vector3(backGroundPosition.x, backGroundPosition.y, backGroundPosition.z);
            drop = false;
        }
        this.imageControl();     
    }

    //change background image
    void imageControl()
    {
        if (drop)
        {
            transform.Translate(Vector3.down * Time.deltaTime * bgSpeed);

            if (transform.position.z <= backGroundPosition.z-backGroundSize.y)
            {
                transform.position = new Vector3(backGroundPosition.x, backGroundPosition.y, backGroundPosition.z-backGroundSize.y);
                this.imageReset();
            }
        }
    }
    //Background image offset
    void imageReset()
    {
        float offset = Time.time * runSpeed;
        material.mainTextureOffset = new Vector3(0, offset);
    }

    //Create a simple second counter use to change the back groupnd
    IEnumerator secondsIncrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            seconds++;
        }
    }
}
