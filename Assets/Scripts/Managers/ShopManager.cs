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
    public ConfirmPurchase confirmPurchase;

    // Start is called before the first frame update
    void Start()
    {
        myInventoryManager = InventoryManager.Instance;
        //ShopPanel.SetActive(true);
        //ShopPanel.SetActive(false);

        InitializeShop();
    }

    private void InitializeShop()
    {
        foreach (Item item in shopItems)
        {
            ShopSlot newShopSlot = Instantiate(ShopSlotPrefab).GetComponent<ShopSlot>();
            newShopSlot.transform.SetParent(ShopParent);
            newShopSlot.transform.localScale = Vector3.one;
            newShopSlot.SetUpSlot(item);
        }
    }

    public void ConfirmBuy(Item item, ShopSlot shopSlot)
    {
        confirmPurchase.ConfirmText.text = "Buy " + item.name + " for " + item.goldValue + " Gold?";
        confirmPurchase.gameObject.SetActive(true);
    }

    public void OpenCloseShop()
    {
        ShopPanel.SetActive(!ShopPanel.activeSelf);
        myInventoryManager.myInventoryUI.OpenCloseInventory(ShopPanel.activeSelf);
    }
}
