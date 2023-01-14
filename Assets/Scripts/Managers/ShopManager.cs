using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    #region Singleton
    public static ShopManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    InventoryManager myInventoryManager;

    public GameObject ShopPanel;
    public Transform ShopParent;
    public List<Item> shopItems;

    public GameObject ShopSlotPrefab;
    public ConfirmPanel confirmPanel;

    public float SellValueMultiplier = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        myInventoryManager = InventoryManager.Instance;

        InitializeShop();
    }

    //On load, reads the ShopItems list and spawns a ShopSlot for each item in the List
    //Assigns item data to each slot
    private void InitializeShop()
    {
        foreach (Item item in shopItems)
        {
            if (item != null)
            {
                ShopSlot newShopSlot = Instantiate(ShopSlotPrefab).GetComponent<ShopSlot>();
                newShopSlot.transform.SetParent(ShopParent, false);
                newShopSlot.SetUpSlot(item);
            }
        }
    }

    //Pulls up and updates the Confirmation Panel with Sell Information
    public void ConfirmSell(Item item, InventorySlot inventorySlot)
    {
        confirmPanel.targetSell = inventorySlot;
        confirmPanel.buyOrSell = TransactionType.Sell;
        confirmPanel.ConfirmText.text = "Sell " + item.name + " for " + ((int)(item.goldValue * SellValueMultiplier)).ToString() + " Gold?";
        confirmPanel.gameObject.SetActive(true);
    }

    //Pulls up and updates the Confirmation Panel with Buy Information
    public void ConfirmBuy(Item item, ShopSlot shopSlot)
    {
        confirmPanel.targetPurchase = shopSlot;
        confirmPanel.buyOrSell = TransactionType.Buy;
        confirmPanel.ConfirmText.text = "Buy " + item.name + " for " + item.goldValue + " Gold?";
        confirmPanel.gameObject.SetActive(true);
    }

    //Opens the Shop if it's closed.
    //Closes the Shop if it's open.
    //Syncs with Inventory Panel
    public void OpenCloseShop()
    {
        ShopPanel.SetActive(!ShopPanel.activeSelf);
        myInventoryManager.myInventoryUI.OpenCloseInventory(ShopPanel.activeSelf);
    }

    public void CloseShop()
    {
        ShopPanel.SetActive(false);
        confirmPanel.Close();
        myInventoryManager.CloseInventory();
    }

    public void RefreshShopDisplay()
    {
        List<GameObject> childrenList = new List<GameObject>();

        for (int i = 0; i < ShopParent.childCount; i++)
        {
            Destroy(ShopParent.GetChild(i).gameObject);
        }

        foreach (Item item in shopItems)
        {
            if (item != null)
            {
                ShopSlot newShopSlot = Instantiate(ShopSlotPrefab).GetComponent<ShopSlot>();
                newShopSlot.transform.SetParent(ShopParent, false);
                newShopSlot.SetUpSlot(item);
            }
        }
    }
}
