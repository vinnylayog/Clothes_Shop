using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Item item;

    InventoryManager myInventoryManager;
    ShopManager myShopManager;
    GoldManager myGoldmanager;

    private void Start()
    {
        myInventoryManager = InventoryManager.Instance;
        myShopManager = ShopManager.Instance;
        myGoldmanager = GoldManager.Instance;
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        myInventoryManager.Remove(item, true);
    }

    public void UseItem()
    {
        if (item != null)
        {
            if (myShopManager.ShopPanel.gameObject.activeSelf)
            {
                if (!myShopManager.confirmPanel.gameObject.activeSelf)
                    myShopManager.ConfirmSell(item, this);
            }
            else
            {
                item.Use();
            }
        }
    }

    public void SellItem()
    {
        int sellValue = (int)(item.goldValue * myShopManager.SellValueMultiplier);
        myGoldmanager.AddGold(sellValue);
        myInventoryManager.Remove(item, false);
    }
}
