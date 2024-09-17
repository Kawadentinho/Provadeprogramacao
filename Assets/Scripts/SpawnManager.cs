using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject[] applePrefabs;
    string[] prefabsPaths = {"Prefabs/Red Apple", "Prefabs/Green Apple", "Prefabs/Golden Apple"};
    float timer;
    const int cooldown = 1;
    Vector2 screenBounds;


    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
      if (PhotonNetwork.IsMasterClient)
        {
            Spawn();
        }
    }


    void Spawn()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            float appleIndex = Random.Range(0, 1);

            string appleSelected;

            

            switch(appleIndex)
            {
                case < 0.5f:
                    appleSelected = prefabsPaths[0];

                    break;
                case < 0.8f:
                    appleSelected= prefabsPaths[1];

                    break;
                default:
                    appleSelected = prefabsPaths[2];
                    break;
            }


            NetworkManager.instance.Instantiate(appleSelected, new Vector2(Random.Range(-GameManager.instance.ScreenBounds.x, GameManager.instance.ScreenBounds.x)), GameManager.instance.ScreenBounds.y, Quaternion.identity);
            timer = cooldown;
        }
    }

    Vector2 GeneratePosition(GameObject objectSelected)
    {
        Vector2 spriteBounds = objectSelected.GetComponent<SpriteRenderer>().bounds.size / 2;

        Vector2 bounds = new Vector2(screenBounds.x - spriteBounds.x, screenBounds.y + spriteBounds.y);

        Debug.Log(spriteBounds);
        Debug.Log(bounds);
        return new Vector2(Random.Range(-bounds.x, bounds.x), bounds.y);
    }
    
    GameObject ChoosenApple()
    {
        int appleSelected = Random.Range(0, applePrefabs.Length);

        return applePrefabs[appleSelected];
    }

    

}
