using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{

    private void OnEnable()
    {
        DisableRagdoll();
    }

    private void Update()
    {
      
    }


    void EnableRagdoll()
    {
        var bodies = GetComponentsInChildren<Rigidbody>();

        foreach (var body in bodies)
        {
            body.isKinematic = false;
        }
        var anim = GetComponent<Animator>();
        anim.enabled = false;

    }

    void DisableRagdoll()
    {
        var bodies = GetComponentsInChildren<Rigidbody>();

        foreach (var body in bodies)
        {
            body.isKinematic = true;
        }
        var anim = GetComponent<Animator>();
        anim.enabled = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag($"Ball"))
        {
            EnableRagdoll();
        }
    }
    
}
