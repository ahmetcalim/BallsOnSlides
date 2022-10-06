using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeManager : MonoBehaviour
{
    public static float incomeCoefficient;
    public static float baseCoefficient = 1.04f;
    public static float numberOfOwned = 1;
    private void Start()
    {
        numberOfOwned = PlayerPrefs.GetInt("numberOfOwned" + 2);
        if (PlayerPrefs.GetFloat("incomeCoefficient") == 0)
        {

            incomeCoefficient = 1f;
            PlayerPrefs.SetFloat("incomeCoefficient", incomeCoefficient);
        }
        else
        {
            incomeCoefficient = PlayerPrefs.GetFloat("incomeCoefficient");
        }
        
    }
    public void IncreaseIncome()
    {
        numberOfOwned++;
        incomeCoefficient = Mathf.Pow(baseCoefficient, numberOfOwned);
        PlayerPrefs.SetFloat("incomeCoefficient", incomeCoefficient);
        Debug.Log(incomeCoefficient);
    }
}
