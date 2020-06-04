using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    public float projSpeed;

    void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * projSpeed;
    } 
    
}
