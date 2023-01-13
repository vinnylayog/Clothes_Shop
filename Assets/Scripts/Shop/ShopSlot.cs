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
    NotificationManager myNotificationManager;

    public int priceOfItem = 10;
    public TMP_Text priceDisplay;

    private void Start()
    {
        myInventoryManager = InventoryManager.Instance;
        myGoldManager = GoldManager.Instance;
        myShopManager = ShopManager.Instance;
        myNotificationManager = NotificationManager.Instance;
    }

    //Assigns Item data to the slot
    public void SetUpSlot(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        priceOfItem = item.goldValue;
        priceDisplay.text = priceOfItem.ToString();
    }

    //Pulls up Confirmation Window to make sure player wants to buy the item
    public void AttemptBuy()
    {
        if(!myShopManager.confirmPanel.gameObject.activeSelf)
            myShopManager.ConfirmBuy(item, this);
    }

    //After confirmation, checks if player can buy the item
    public void BuyItem()
    {
        //Check if there is inventory space
        if (myInventoryManager.items.Count >= myInventoryManager.inventorySpace)
        {
            myNotificationManager.ShowNotification("Not enough space in your inventory!", Color.red);
            return;
        }

        //Check if player has enough gold
        if (!myGoldManager.SubGold(priceOfItem))
        {
            myNotificationManager.ShowNotification("Not enough gold!", Color.red);
            return;
        }

        //Notifies and adds the item to player's inventory
        myNotificationManager.ShowNotification("You bought a " + item.name + ".", Color.red);
        myInventoryManager.Add(item);
    }
}
