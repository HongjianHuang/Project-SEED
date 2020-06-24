using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMangers : MonoBehaviour
{

    private GameObject startPoint;
    private GameObject endPoint;

    private GameObject player;

    public void Start()
    {
        startPoint = GameObject.Find("Start Point");
        endPoint = GameObject.Find("End Point");
        player = GameObject.Find("Player");
        player.transform.position = startPoint.transform.position;

    }
    public void backToCheckPoint()
    {

    }
    public void restartLevel()
    {

    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void gameOver()
    {

    }
    public void nextScene()
    {

    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void Update()
    {
        if (Input.GetKey("escape"))
        {
            quitGame();
        }

    }
}
