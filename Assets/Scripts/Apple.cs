using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviourPun
{

    const int speed = 5;
    [SerializeField] int score;
    Rigidbody2D rb;
    [SerializeField] string prefabPath;

    public string PrefabPath { get => prefabPath; }

    public void AppleScore()
    {

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void appleStatus()
    {
        rb.velocity = Vector2.down * speed;

       /* if (rb.position.y < "limiteDaTela"
        destroy();
       
        */
    }

    [PunRPC]
    public void destroy()
    {
        Destroy(gameObject);
    }

}
