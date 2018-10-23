using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public void play_Button_Change_Scene(int changeScene){
        SceneManager.LoadScene(changeScene);
        ScoreDisplay.scoreNumber = 0;
    }

    public void restart_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreDisplay.scoreNumber = 0;
        AudioListener.volume = AudioControl.tempVolume;
    }

    public void back_to_Menu()
    {
        Mute.firstStart = false;
    }

    public void quit_Button_Leave_App()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
