using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void newGame(){
        SceneManager.LoadScene(1);
    }
    public void settingsMenu(){

    }
    public void quitGame()
    {
        Application.Quit();
    }
}

