using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject[] applePrefabs;
    float timer;
    const int cooldown = 1;
    Vector2 screenBounds;


    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
      
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

    public void spawn()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            GameObject appleSelected = ChoosenApple();
            timer = cooldown;

            NetworkManager.instance.Instantiate(appleSelected.GetComponent<Apple>.PrefabPath, GeneratePosition(appleSelected), Quaternion.identity);
        }
    }

}
