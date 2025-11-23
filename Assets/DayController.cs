using UnityEngine;
using TMPro;

public class DayController : MonoBehaviour
{
    
    public int minCustomers = 10;
    public int maxCustomers = 40;
    public GameObject panel;
    public TMP_Text soldText;
    public int CalculateCupsSold(float price, int maxCustomer)
    {
        float demandFactor = Mathf.Clamp01(1.5f - price * 0.3f);
        float noise = Random.Range(0.85f, 1.15f);
        int sold = Mathf.RoundToInt(maxCustomer * demandFactor * noise);
        return sold;
    }
    
    
    public void RunDay()
    {
        panel.SetActive(true);
        int customersToday = Random.Range(minCustomers, maxCustomers);

        int cupsSold = CalculateCupsSold(
            GameManager.I.PricePerCup,
            customersToday
        );
        GameManager.I.EndDay(cupsSold);
        soldText.text = cupsSold.ToString();

    }
}
