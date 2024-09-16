using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviourPun
{

    Vector2 screenBounds;
    float Score;
    int playersInGame;
    public Vector2 ScreeenBounds1 { get => screenBounds; }


    #region Singleton

    public static GameManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    #endregion
    private void Start()
    {
        Score = 0;

    }
    void AddPlayer()
    {
        playersInGame++;

    }

    void AddScore()
    {
        Score++;
    }


}