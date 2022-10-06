using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public Animator speedUpAnimator;
    public MergeManager mergeManager;
    public float force;
    public Transform center;
    public void SpeedUp() 
    {
        foreach (var item in mergeManager.balls)
        {
            if (item.onPlatform)
            {

                Vector3 direction = (center.position - item.transform.position).normalized;
                item.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Force);
            }
        }
        speedUpAnimator.SetTrigger("SpeedUp");
        
    }
}
