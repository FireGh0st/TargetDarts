using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DartRaycast : MonoBehaviour
{
    private bool hasHit;
    private Rigidbody rb;
    private RaycastHit hit;

    void Start()
    {
        var theKnife = transform.parent;
        rb = theKnife.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //rb.AddForce(new Vector3(0f, 1f, 0f));

        hasHit = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 0.09f);
        if (hasHit)
        {
            if (!rb.isKinematic && rb.useGravity) { Hit(hit); }
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        else
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

    void Hit(RaycastHit impact) 
    {
        Transform target_attempt = impact.collider.transform;

        Debug.Log(target_attempt.name);
        if (target_attempt.name.Contains("Thick")) 
        {
            Debug.Log("Thick");
            TargetHandler th = target_attempt.GetComponent<TargetHandler>();
            //th.RegisterHitOn(target_attempt.name);
        } 
    }
}