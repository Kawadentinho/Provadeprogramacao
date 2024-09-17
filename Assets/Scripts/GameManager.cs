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


    [PunRPC]
    void AddPlayer()
    {
        playersInGame++;
        if (playersInGame == PhotonNetwork.PlayerList.Length)
        {
            CreatePlayer();
        }

    }


    [PunRPC]
    void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();
    }


    [PunRPC]
    void CreatePlayer()
    {
        NetworkManager.instance.Instantiate("Resources/Player", new Vector2(0, -4), Quaternion.identity);
    }

}   