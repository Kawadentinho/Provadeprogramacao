using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor.PackageManager;

public class SpawnManager : MonoBehaviour
{

    ArrayList appleList;
    int timer;
    const int cooldown = 1;
    
    void Update()
    {
      
    }

    public void spawn()
    {
        timer -- Time.deltaTime;
    }

}
