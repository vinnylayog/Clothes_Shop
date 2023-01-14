using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    public Item item;

    InventoryManager myInventoryManager;
    ShopManager myShopManager;
    GoldManager myGoldmanager;
    NotificationManager myNotificationManager;

    public TMP_Text sellPrice;
    public GameObject sellPriceBox;

    private void Start()
    {
        myInventoryManager = InventoryManager.Instance;
        myShopManager = ShopManager.Instance;
        myGoldmanager = GoldManager.Instance;
        myNotificationManager = NotificationManager.Instance;
    }

    //Adds Item data to Slot
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        sellPrice.text = ((int)(item.goldValue * myShopManager.SellValueMultiplier)).ToString();

        removeButton.interactable = true;
    }

    //Removes Item data from Slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        sellPrice.text = "";
        sellPriceBox.SetActive(false);

        removeButton.interactable = false;
    }

    //Removes Item from Inventory
    public void OnRemoveButton()
    {
        myInventoryManager.Remove(item, true);
    }

    public void UseItem()
    {
        if (item != null)
        {
            //If the shop menu is open, attempt to sell the item
            if (myShopManager.ShopPanel.gameObject.activeSelf)
            {
                if (!myShopManager.confirmPanel.gameObject.activeSelf)
                    myShopManager.ConfirmSell(item, this);
            }
            //If shop menu is not open, uses the item
            else
            {
                item.Use();
            }
        }
    }

    public void SellItem()
    {
        //Adds gold to the Player's wallet equivalent to the Item's Gold Value * The Shop sell multiplier
        int sellValue = (int)(item.goldValue * myShopManager.SellValueMultiplier);
        myNotificationManager.ShowNotification("You sold " + item.name + " for " + sellValue.ToString() + " Gold.", Color.white, 0);
        myGoldmanager.AddGold(sellValue);

        //Removes the item from the Player's Inventory
        myInventoryManager.Remove(item, false);
    }
}
