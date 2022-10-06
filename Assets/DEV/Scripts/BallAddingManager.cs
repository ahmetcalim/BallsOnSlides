using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallAddingManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public MergeManager mergeManager;
    public void Add() 
    {
       
        InstantiateBall(ballPrefab);
    }
    public void InstantiateBall(GameObject ballPref) 
    {
        GameObject copy = Instantiate(ballPref, spawnPoint.position, Quaternion.identity);
        copy.transform.position += new Vector3(Random.Range(-.75f,.75f), 0f, Random.Range(-.75f, .75f));
      
        mergeManager.balls.Add(copy.GetComponent<BallParent>().ball);
        
       
        
    }
}
