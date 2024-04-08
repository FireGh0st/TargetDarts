using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DartCollider : MonoBehaviour
{
    Rigidbody rb;
    public float wind_strength = 10f;
    void Start() 
    {
        rb = GetComponentInParent<Rigidbody>();
    }
    void OnTriggerEnter(Collider object_hit) 
    {
        //Debug.Log(object_hit.name);
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    void OnTriggerStay(Collider object_hit) 
    {
        if (object_hit.CompareTag("Wind")) 
        {
            rb.AddForce(Vector3.back * wind_strength);
        }
    }

    void OnTriggerExit(Collider object_hit) 
    {
        //Debug.Log("End collision");
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
