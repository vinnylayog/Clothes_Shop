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

    public void Close()
    {
        targetPurchase = null;
        targetSell = null;
        gameObject.SetActive(false);
        ConfirmText.text = " ";
    }
}

public enum TransactionType { Buy, Sell }
