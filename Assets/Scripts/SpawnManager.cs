using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor.PackageManager;
using System;

public class SpawnManager : MonoBehaviour
{

    Array stringApples;
    float timer;
    const int cooldown = 1;
    
    void Update()
    {
      
    }

    public void spawn()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            float appleindex;
            appleindex = Random.Range(0, 1);
            string appleSelected;

            switch (appleindex)
            {
                case <= 0.5f:
                    appleSelected = appleList(0);
                    break;

                    
            }

        }
    }

}
