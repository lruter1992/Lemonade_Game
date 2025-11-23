using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PriceUI : MonoBehaviour
{
    public TMP_InputField priceInput;
    public TMP_Text currentPriceText;
    public Button setPriceButton;

    private void Start()
    {
        setPriceButton.onClick.AddListener(ApplyPrice);
        Refresh();
    }

    void ApplyPrice()
    {
        if (float.TryParse(priceInput.text, out float p))
        {
            GameManager.I.SetPrice(p);
            Refresh();
        }
        else
        {
            priceInput.text = GameManager.I.PricePerCup.ToString("0.00");
        }

       
    }
    void Refresh()
    {
        currentPriceText.text = $"Price: £{GameManager.I.PricePerCup:0.00}";
        priceInput.text = GameManager.I.PricePerCup.ToString("0.00");
    }
}
