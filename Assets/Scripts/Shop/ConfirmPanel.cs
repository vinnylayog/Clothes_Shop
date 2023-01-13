using UnityEngine;
using TMPro;

public class ConfirmPanel : MonoBehaviour
{
    public TMP_Text ConfirmText;
    public ShopSlot targetPurchase;
    public InventorySlot targetSell;
    public TransactionType buyOrSell;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    //Confirms purchase or sale of item
    public void Confirm()
    {
        if (buyOrSell == TransactionType.Buy)
        {
            targetPurchase.BuyItem();
        }
        else if (buyOrSell == TransactionType.Sell)
        {
            targetSell.SellItem();
        }

        Close();
    }

    //Closes the Confirmation window and clears data
    public void Close()
    {
        targetPurchase = null;
        targetSell = null;
        gameObject.SetActive(false);
        ConfirmText.text = " ";
    }
}

public enum TransactionType { Buy, Sell }
