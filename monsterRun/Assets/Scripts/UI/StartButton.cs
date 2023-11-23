using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnPlayClick()
    {
        //Loads main game scene
        SceneManager.LoadScene("SampleScene");
    }

    public void OnQuitClick()
    {
        //Exits the game
        Application.Quit();
    }
}
