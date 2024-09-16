using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviourPun
{

    const int speed = 5;
    [SerializeField] int score;
    Rigidbody2D rb;

    /*public int aplleScore()
    {

    }*/
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void appleStatus()
    {
        rb.velocity = Vector2.down * speed;

       /* if (rb.position.y < "limiteDaTela"
        
       
        */
    }

}
