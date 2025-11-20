using UnityEngine;
using System.Collections;
using TMPro; //Load in all the libraries 

public class GameManager : MonoBehaviour
{
    public int lemons;
    public int Lemonade;
    // Void Start is Event Begin Play
    void Start()
    {
        
    }

    // Update is EventTick
    void Update()
    {
        // Debug.Log("Hello World"); //Print String
        //BuyLemons();
    }

    public void BuyLemons()
    {
        lemons++;
        Debug.Log(lemons.ToString());
    }

}
