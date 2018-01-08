using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cloning a prefab (preconfigured object in assets folder)

public class RotateVert : MonoBehaviour
{
    public float speed = 10f;
 
    void Update()
    {
        transform.Rotate( new Vector3(-90, 90, 0) , speed*Time.deltaTime, Space.Self);
 
    }
}
