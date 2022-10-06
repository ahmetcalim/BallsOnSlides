using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public Rigidbody rampRb;
    public float money;
    public int level;
    public bool onPlatform;
    public bool onCenter;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onPlatform = true;
            rb.constraints = RigidbodyConstraints.None;
        }
        if (collision.gameObject.CompareTag("Ramp"))
        {
            onPlatform = false;
            onCenter = false;
            rb.constraints = rampRb.constraints;
            
        }
    }
}
