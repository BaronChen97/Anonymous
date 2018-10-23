using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour {

    public Button button;
    public static bool muted;
    public static bool firstStart;
    public Sprite muteImage;
    public Sprite unMuteImage;

    private void Start()
    {
        if(muted == false)
            button.image.sprite = unMuteImage;
        else
            button.image.sprite = muteImage;
    }

    void Update()
    {
        AudioListener.volume = AudioControl.volume;
    }

    public void muteCheck()
    {
        button = GetComponent<Button>();

        if (!muted)
        {
            if (!firstStart)
            {
                AudioControl.tempVolume = AudioControl.volume;
                firstStart = true;
            }
            AudioControl.volume = 0;
            button.image.sprite = muteImage;
            muted = true;
        }
        else
        {
            AudioControl.volume = AudioControl.tempVolume;
            button.image.sprite = unMuteImage;
            muted = false;
        }
    }
}
