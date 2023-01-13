using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image icon;

    Item item;

    InventoryManager myInventoryManager;

    private void Start()
    {
        myInventoryManager = InventoryManager.Instance;
    }

    public void BuyItem()
    {
        //Check if there is inventory space
        if (myInventoryManager.items.Count >= myInventoryManager.inventorySpace)
        {
            Debug.Log("Not enough space.");
            return;
        }
        //Check if gold is enough
        //Ch

        //myInventory.Add()
    }
}
