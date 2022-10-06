using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            other.GetComponent<Ball>().onCenter = true;
            other.GetComponent<Rigidbody>().velocity = new Vector3(0f, other.GetComponent<Rigidbody>().velocity.y, 0f);
        }
    }
}
