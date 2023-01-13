using UnityEngine;
using TMPro;

public class ConfirmPurchase : MonoBehaviour
{
    public TMP_Text ConfirmText;
    private ShopSlot targetPurchase;

    public void Confirm()
    {
        targetPurchase.BuyItem();
        Close();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        ConfirmText.text = " ";
    }
}
