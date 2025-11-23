using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro; //Load in all the libraries 

public class GameManager : MonoBehaviour
{
	public static GameManager I;
	
    [Header("Inventory")]
	public int lemons;
    public int lemonade;
	public int lemonadeCost = 10; //Lemon Cost
	public int lemonMulti = 2; //Multiplier for the lemons
	public float speed = 0.1f;
	public TMP_Text lemonCounterText;
	public TMP_Text lemonadeCounterText;

	[Header("Pricing")] [SerializeField] private float pricePerCup = 1.00f;
	public float PricePerCup => pricePerCup;

	[Header("Sales Tracking")] 
	public List<int> salesHistory = new List<int>(); //Cups sold per day
	public List<float> revenueHistory = new List<float>(); // Money Per Day

	public int currentDay = 0;
	
	private void Awake()
	{
		I = this;
	}

	public void SetPrice(float newPrice)
	{
		pricePerCup = Mathf.Max(0.01f, newPrice); //Avoid Free or Negative
	}

	public void EndDay(int cupsSold)
	{
		cupsSold = Mathf.Clamp(cupsSold, 0, lemonade);
		lemonade -= cupsSold;
		float revenue = cupsSold * pricePerCup;
		salesHistory.Add(cupsSold);
		revenueHistory.Add(revenue);
		currentDay++;
	}
	
	
	
    // Void Start is Event Begin Play
    void Start()
    {
       // InvokeRepeating(nameof(AutoLemon), 0.1f, speed);
    }

    // Update is EventTick
    void Update()
    {
		lemonCounterText.text = "lemons:" + lemons; //Update LemonText
		lemonadeCounterText.text = "lemonade:" + lemonade; //Update LemonText
    }

    public void BuyLemons()
    {
        lemons++;
        Debug.Log(lemons.ToString());
    }
	public void MakeLemonade()
	{
		if(lemons > lemonadeCost)
		{
			lemonade++; //Add 1 Lemonade
			lemons = lemons - lemonadeCost; //Subtract Lemons
		}
	}
	
	void AutoLemon()
	{
		lemons = lemons + lemonMulti;
	}
	public void OnNextDayButtonClicked()
	{
		FindFirstObjectByType<DayController>().RunDay();
	}
	

}
