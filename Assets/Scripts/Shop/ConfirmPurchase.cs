using UnityEngine;
using TMPro;

public class ConfirmPurchase : MonoBehaviour
{
    public TMP_Text ConfirmText;
    public ShopSlot targetPurchase;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Confirm()
    {
        targetPurchase.BuyItem();
        Close();
    }

    public void Close()
    {
        targetPurchase = null;
        gameObject.SetActive(false);
        ConfirmText.text = " ";
    }
}
