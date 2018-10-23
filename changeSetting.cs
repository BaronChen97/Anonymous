using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class changeSetting : MonoBehaviour {
    
    void Update()
    {
        AudioControl.volume = GameObject.Find("VolumeSlider").GetComponent<Slider>().value;
    }
}
