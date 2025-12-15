using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    public GameManager gameManager; //Link to the gamemanager
    private int LemonadeCost; //Int of Lemonade Cost
    private int customers; //Int of Customer Numbers


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GetComponent<GameManager>(); //Automatically get the Component of GameManager
        LemonadeCost = gameManager.cost; //Get Int from Game Manager
        customers = gameManager.customers;
        Debug.Log(CalculateSales());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int CalculateSales()
    {
        int sales = Mathf.Max(customers - LemonadeCost,0);
        return sales;
      
    }
}