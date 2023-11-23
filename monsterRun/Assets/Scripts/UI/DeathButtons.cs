using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathButtons : MonoBehaviour
{   
    public void OnRestartClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void OnBackClick()
    {
        SceneManager.LoadScene("Start");
    }
}
