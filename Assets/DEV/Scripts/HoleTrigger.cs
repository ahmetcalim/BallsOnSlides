using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public MoneyManager moneyManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            moneyManager.AddMoney(other.GetComponent<Ball>().money * IncomeManager.incomeCoefficient);
        }
    }
}
