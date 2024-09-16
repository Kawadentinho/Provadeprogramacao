using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject[] applePrefabs;
    float timer;
    const int cooldown = 1;
    
    void Update()
    {
      
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
           
        }
    }

}
