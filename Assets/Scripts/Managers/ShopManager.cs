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

    public void ConfirmSell(Item item, InventorySlot inventorySlot)
    {
        confirmPanel.targetSell = inventorySlot;
        confirmPanel.buyOrSell = TransactionType.Sell;
        confirmPanel.ConfirmText.text = "Sell " + item.name + " for " + ((int)(item.goldValue * SellValueMultiplier)).ToString() + " Gold?";
        confirmPanel.gameObject.SetActive(true);
    }

    public void ConfirmBuy(Item item, ShopSlot shopSlot)
    {
        confirmPanel.targetPurchase = shopSlot;
        confirmPanel.buyOrSell = TransactionType.Buy;
        confirmPanel.ConfirmText.text = "Buy " + item.name + " for " + item.goldValue + " Gold?";
        confirmPanel.gameObject.SetActive(true);
    }

    public void OpenCloseShop()
    {
        ShopPanel.SetActive(!ShopPanel.activeSelf);
        myInventoryManager.myInventoryUI.OpenCloseInventory(ShopPanel.activeSelf);
    }
}
