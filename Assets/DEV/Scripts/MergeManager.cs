using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public List<Ball> balls;
    public int levelCount;
    public List<GameObject> ballPrefabs;
    public BallAddingManager addingManager;
    int level = 0;
    public static bool allowMerge = false;
    public Upgrade upgrade;
    private void Start()
    {
        if (PlayerPrefs.GetInt("ballList_count") == 0 )
        {
            addingManager.InstantiateBall(ballPrefabs[0]);
        }
        else
        {
            for (int i = 0; i < PlayerPrefs.GetInt("ballList_count"); i++)
            {
                addingManager.InstantiateBall(ballPrefabs[PlayerPrefs.GetInt("ballList_" + i) - 1]);
            }
        }
       
       

        allowMerge = AllowMerge();
        upgrade.disabled = !allowMerge;
    }
    public void Merge()
    {
        balls = FindObjectsOfType<Ball>().ToList();

        

        if (AllowMerge())
        {
            Ball[] ballArray = balls.Where(t => t.level == level).Take(3).ToArray();
            for (int i = 0; i < ballArray.Length; i++)
            {
                ballArray[i].transform.parent.GetComponent<BallParent>().Explosion();
                Destroy(ballArray[i].transform.parent.gameObject);
            }
            addingManager.InstantiateBall(ballPrefabs[level]);

            balls = FindObjectsOfType<Ball>().ToList();
           
            Debug.Log("Can merge");
        }

        allowMerge = AllowMerge();
        upgrade.disabled = !allowMerge;
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("ballList_count", balls.Count);

        for (int i = 0; i < balls.Count; i++)
            PlayerPrefs.SetInt("ballList_" + i, balls[i].level);
    }
    public bool AllowMerge() 
    {
        balls = FindObjectsOfType<Ball>().ToList();
        int count = 0;
        level = 0;
        
        for (int i = 0; i < levelCount; i++)
        {
            Ball[] ballArray = balls.Where(t => t.level == i).ToArray();
            count = ballArray.Length;

            if (count >= 3)
            {
                level = ballArray[0].level;
                break;
            }
        }
        return level != 0;
    }
}
