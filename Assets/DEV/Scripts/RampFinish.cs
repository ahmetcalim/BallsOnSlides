using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampFinish : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
         
            other.GetComponent<Rigidbody>().AddForce(transform.forward.normalized * speed, ForceMode.Impulse);
        }
    }
}
