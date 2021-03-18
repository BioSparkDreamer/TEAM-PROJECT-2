using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    Rigidbody rigidbody;
    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    } 
    void Update()
    {

    }
    
    void OnCollisionEnter(Collision other)
    {
        SnakeController e = other.collider.GetComponent<SnakeController>();
        if (e != null)
        {
            e.Freeze();
        }
        Destroy(gameObject);
    }
}