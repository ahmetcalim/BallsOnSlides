using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public float basePrice;
    public float coefficient = 1.15f;
    public float numberOfOwned = 1;
    public float currentPrice;
    public TMPro.TextMeshProUGUI priceText;
    public bool disabled;
    public int upgradeIndex;
    private void Start()
    {
        currentPrice = PlayerPrefs.GetFloat("currentPrice" + upgradeIndex);
        numberOfOwned = PlayerPrefs.GetInt("numberOfOwned" + upgradeIndex);
        if (currentPrice == 0)
        {
            currentPrice = basePrice;
            PlayerPrefs.SetFloat("currentPrice" + upgradeIndex, currentPrice);
        }
       
        if (currentPrice < 1000f)
        {

            priceText.text = "$" + currentPrice.ToString("F1");
        }
        else if (currentPrice >= 1000f && currentPrice < 1000000f)
        {
            float mod = currentPrice % 1000f;

            priceText.text = "$" + ((int)(currentPrice / 1000f)).ToString() + "." + ((int)(mod / 100f)).ToString("F0") + "k";
        }
        else
        {
            float mod = currentPrice % 1000000f;

            priceText.text = "$" + ((int)(currentPrice / 1000000f)).ToString() + "." + ((int)(mod / 100000f)).ToString("F0") + "mn";
        }
        
    }
    private void Update()
    {
        if (!disabled)
        {

            Enabled(MoneyManager.money >= currentPrice);
        }
        else
        {
            Enabled(false);
        }
        
    }
    public void Enabled(bool enabled)
    {
        GetComponent<Button>().enabled = enabled;
        if (enabled)
        {
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<Image>().color = Color.gray;
        }
    }
    public void CalculateCurrentPrice() 
    {
        MoneyManager.money -= currentPrice;
        PlayerPrefs.SetFloat("money", MoneyManager.money);
        numberOfOwned++;
        currentPrice = basePrice * Mathf.Pow(coefficient, numberOfOwned);
        PlayerPrefs.SetInt("numberOfOwned" + upgradeIndex, (int)numberOfOwned);
        PlayerPrefs.SetFloat("currentPrice" + upgradeIndex, currentPrice);
        if (currentPrice < 1000f)
        {

            priceText.text = "$" + currentPrice.ToString("F1");
        }
        else
        {
            float mod = currentPrice % 1000f;

            priceText.text = "$" + ((int)(currentPrice / 1000f)).ToString() + "." + ((int)(mod / 100f)).ToString("F0") + "k";
        }
    }
}
