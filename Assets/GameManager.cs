using UnityEngine;
using System.Collections;
using TMPro; //Load in all the libraries 

public class GameManager : MonoBehaviour
{
    [SerializeField]
	public int lemons;
    public int lemonade;
	public int lemonadeCost = 10; //Lemon Cost
	public int lemonMulti = 2; //Multiplier for the lemons
	public float speed = 0.1f;
	public TMP_Text lemonCounterText;
	public TMP_Text lemonadeCounterText;
    // Void Start is Event Begin Play
    void Start()
    {
        InvokeRepeating(nameof(AutoLemon), 0.1f, speed);
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
	

}
