using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;




public class GameManager : MonoBehaviourPun
{

    Vector2 screenBounds;
    float score;
    public Text scoreText;
    int playersInGame;
    public static GameManager Instance;

    public Vector2 ScreenBounds { get => screenBounds; }


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
        photonView.RPC("AddPlayer", RpcTarget.AllBuffered);
    }
    #endregion
    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    void AddPlayer()
    {
        playersInGame++;
        if (playersInGame == PhotonNetwork.PlayerList.Length)
        {
            CreatePlayer();
        }

    }

    void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    void CreatePlayer()
    {
        PhotonNetwork.Instantiate("PlayerPrefab", new Vector3(0, -4, 0), Quaternion.identity);
    }

}   