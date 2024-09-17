using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPun
{
    const int speed = 10;
    Vector2 direction, spriteBounds, screenBounds;
    [SerializeField] Rigidbody2D rigidbody2D;
    bool playerLocal;
    SpriteRenderer spriteRenderer;
    PhotonView photonView;
    [SerializeField] GameObject player;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    void Update()
    {
        Move();
    }

    [PunRPC]
    private void Initialize()
    {

        if (photonView.IsMine)
        {
            playerLocal = true;
            Move();
        }
        else
        {

            Color initialColor = Color.white;


            initialColor.a = 0.2f;


            spriteRenderer.color = initialColor;

        }
    }
    void Move()
    {

        direction.x = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = direction * speed;
        Vector3 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x, screenBounds.x * -1, screenBounds.x);
        playerPosition.y = Mathf.Clamp(playerPosition.y, screenBounds.y * -1, screenBounds.y);
        transform.position = playerPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerLocal)
        {
            if (collision.gameObject.CompareTag("MaçãVermelha"))
            {
                int score = collision.gameObject.GetComponent<Apple>().Score;

                PhotonView photonView = PhotonView.Get(this);

                photonView.RPC("AddScore", RpcTarget.All, score);

                photonView.RPC("DestroyApple", RpcTarget.All, collision.gameObject.GetComponent<PhotonView>().ViewID);
            }
            if (collision.gameObject.CompareTag("MaçãVerde"))
            {

            }
            if (collision.gameObject.CompareTag("MaçãDourada"))
            {

            }


        }
    }
}