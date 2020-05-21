using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
    public void gameOver()
    {

    }
    public void nextScene()
    {

    }
    public void LateUpdate()
    {

    }
}
