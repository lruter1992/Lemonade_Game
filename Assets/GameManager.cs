using UnityEngine;
using System.Collections;
using TMPro; //Load in all the libraries 
using UnityEngine.UI; //Make sure to add

public class GameManager : MonoBehaviour
{
    [SerializeField]
	public int lemons;
    public int lemonade;
	public int lemonadeCost = 10; //Lemon Cost
	public int lemonMulti = 2; //Multiplier for the lemons
	public int cost; // Add me 
	public int customers; // Add Me
	public TMP_InputField priceInputField;
	public float speed = 0.1f;
	public TMP_Text lemonCounterText;
	public TMP_Text lemonadeCounterText;
	public TMP_Text EODSales;
	public TMP_Text EODCustomers;
	public GameObject EODPanel;
	private CustomerScript customerscript;
    // Void Start is Event Begin Play

    void Awake()
    {
	    customers = Random.Range(0, 100);
    }
    void Start()
    {
        InvokeRepeating(nameof(AutoLemon), 0.1f, speed);
        customerscript = GetComponent<CustomerScript>();

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
		//lemons = lemons + lemonMulti;
	}

	public void UpdatePriceFromInput()
	{
		if (int.TryParse(priceInputField.text, out int result))
		{
			cost = result;
			Debug.Log("Price updated: " + cost);
		}
		else
		{
			Debug.LogWarning("Invalid price input!");
		}
	}

	public void StartDay()
	{
		EODPanel.SetActive(true);
		EODSales.text = "Sales:" + customerscript.CalculateSales(); 
		EODCustomers.text = "Customers:" + customers; //Customers Num
	}

}
