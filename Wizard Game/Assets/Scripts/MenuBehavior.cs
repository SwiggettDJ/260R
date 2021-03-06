using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{

    public void Pause()
    {
        Time.timeScale = 0f;
    }
    
    public void Resume()
    {
        Time.timeScale = 1f;
    }
    
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Arena");
        Time.timeScale = 1f;
    }

}
