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



    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        spriteBounds = spriteRenderer.sprite.bounds.size / 2;

    }

    // Update is called once per frame
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
            spriteRenderer.color = Color.white;
            // Ajusta a transparência para 20%.
            // Aplica a cor ao SpriteRenderer do jogador.

        }
    }
    void Move()
    {

        direction.x = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = direction * speed;
        // Obtém a posição atual do jogador.
        // Restringe a posição do jogador dentro dos limites da tela (screenBounds), evitando que ele saia da tela.

        // Aplica a posição restrita ao jogador.
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerLocal)
        {
            if (collision.gameObject.CompareTag("MaçãVermelha"))
            {



                // Obtém o valor de pontuação da maçã.


                // Envia um RPC para todos os clientes para adicionar o valor da maçã à pontuação no GameManager.


                // Envia um RPC para todos os clientes para destruir a maçã após a colisão.
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