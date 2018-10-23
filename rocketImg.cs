using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rocketImg : MonoBehaviour {

    public static int spaceShipNum = 0;
    public Image myImage;

    public void imgShow(int index) {
        myImage = GetComponent<Image>();
        switch(index) {
            case 1:
                myImage.sprite = Resources.Load<Sprite>("spaceship png");
                spaceShipNum = 1;
                break;
            case 2:
                myImage.sprite = Resources.Load<Sprite>("spaceship png_2");
                spaceShipNum = 2;
                break;
            case 3:
                myImage.sprite = Resources.Load<Sprite>("spaceship png_3");
                spaceShipNum = 3;
                break;
        }
    }
}
