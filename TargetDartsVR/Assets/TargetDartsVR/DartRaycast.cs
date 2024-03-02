using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DartRaycast : MonoBehaviour
{
    private bool hasHit;
    private Rigidbody rb;

    void Start()
    {
        var theKnife = transform.parent;
        rb = theKnife.GetComponent<Rigidbody>();
    }

    void Update()
    {
        hasHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 0.09f);
        if (hasHit)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        //else
        //{
        //    rb.isKinematic = false;
        //    rb.useGravity = true;
        //}
    }
}