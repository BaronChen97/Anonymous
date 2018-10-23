using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStart : MonoBehaviour {

    public static bool gameFirstTimeOpen;

	void Start () {
        FindObjectOfType<AudioControl>().Play("menuBG");
    }
}
