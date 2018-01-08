using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform[] Location;
    public GameObject[] Cube;
    public GameObject[] Clone;
    
    void Start(){

        Spawn();
        
    }

    void Spawn()
    {
        Clone[0] = Instantiate(Cube[0], Location[0].transform.position, Quaternion.Euler(-90, 90, 0)) as GameObject;

    }

    
}


