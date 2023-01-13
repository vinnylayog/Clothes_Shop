using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlot : MonoBehaviour
{
    public Image icon;

    Item item;

    InventoryManager myInventoryManager;
    GoldManager myGoldManager;
    ShopManager myShopManager;

    public int priceOfItem = 10;
    public TMP_Text priceDisplay;

    private void Start()
    {
        myInventoryManager = InventoryManager.Instance;
        myGoldManager = GoldManager.Instance;
        myShopManager = ShopManager.Instance;
        //priceDisplay.text = item.goldValue.ToString();
        //icon.sprite = item.icon;
    }

    public void SetUpSlot(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        priceOfItem = item.goldValue;
        priceDisplay.text = priceOfItem.ToString();
    }

    public void AttemptBuy()
    {
        if(!myShopManager.confirmPurchase.gameObject.activeSelf)
            myShopManager.ConfirmBuy(item, this);
    }

    public void BuyItem()
    {
        //Check if there is inventory space
        if (myInventoryManager.items.Count >= myInventoryManager.inventorySpace)
        {
            Debug.Log("Not enough space.");
            return;
        }

        //Check if player has enough gold
        if (!myGoldManager.SubGold(priceOfItem))
        {
            Debug.Log("Not enough Gold.");
            return;
        }

        myInventoryManager.Add(item);
        Debug.Log("You bought a " + item.name + "!");
    }
}
