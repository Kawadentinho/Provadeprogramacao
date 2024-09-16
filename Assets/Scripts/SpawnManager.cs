using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor.PackageManager;

public class SpawnManager : MonoBehaviour
{

    public float[] apples;
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
            int appleindex;
            appleindex = Random.Range(0, 1);
            string appleSelected;

            switch (appleindex)
            {
                case 0:
                    appleList = 1;
            }

        }
    }

}
