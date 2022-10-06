using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static float money;
    public TMPro.TextMeshProUGUI text;
    public float moneyPerSeconds;
    public float moneyStart;
    public float moneyDifference;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public TMPro.TextMeshProUGUI moneyPerSecondsTxt;
    public MergeManager mergeManager;
    private void Start()
    {
        money = PlayerPrefs.GetFloat("money");
        moneyStart = money;
    }
    void Update()
    {
        if (money < 1000f)
        {

            text.text = "$" + money.ToString("F1");
        }
        else if(money >= 1000f && money < 1000000f)
        {
            float mod = money % 1000f;

            text.text = "$" + ((int)(money / 1000f)).ToString() + "." + ((int)(mod / 100f)).ToString("F0") + "k";
        }
        else
        {
            float mod = money % 1000000f;

            text.text = "$" + ((int)(money / 1000000f)).ToString() + "." + ((int)(mod / 100000f)).ToString("F0") + "mn";
        }

        if (Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime += period;
            moneyDifference = money - moneyStart;
            moneyPerSeconds = moneyDifference / period;
            if (moneyPerSeconds > 0)
            {
                moneyPerSecondsTxt.text ="$"+ moneyPerSeconds.ToString("F2") + "/sec";

            }
            moneyStart = money; 

            // execute block of code here
        }
       
    }
    public void AddMoney(float moneyAmount) 
    {
        money += moneyAmount;

        PlayerPrefs.SetFloat("money",money);
        MergeManager.allowMerge = mergeManager.AllowMerge();
        mergeManager.upgrade.disabled = !MergeManager.allowMerge;
    }
}
