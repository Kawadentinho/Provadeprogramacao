using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviourPun
{

    const int speed = 5;
    [SerializeField] int score;
    Rigidbody2D rigidbody2D;
    [SerializeField] string prefabPath;

    public string PrefabPath { get => prefabPath; }
    public int Score { get => score; set => score = value; }



    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void AppleScore()
    {

    }


    private void Update()
    {
        rigidbody2D.velocity = Vector2.down * speed;

        if (transform.position.y < -GameManager.instance.ScreenBounds.y)
        {
            photonView.RPC("Destroy", RpcTarget.All);
        }
    }

    [PunRPC]

    void Destroy()
    {
        Destroy(gameObject);
    }

}
