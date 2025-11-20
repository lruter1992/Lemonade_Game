using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public int Lemons;
    public float LemonCost;
    public List<ItemData> items;
    public TMP_Text itemNameDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var firstItem = items[0];
        DisplayItem.name.itemName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayItem(string name)
    {
        itemNameDisplay.text = name;
    }
}
