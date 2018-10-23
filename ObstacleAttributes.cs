using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAttributes : MonoBehaviour {

    public int scoreCount;
    public float speed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.up * speed;
	}
}
