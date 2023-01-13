using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject inventoryButton;
    public Transform itemsParent;

    InventoryManager myInventoryManager;
    ShopManager myShopManager;

    InventorySlot[] slots;

    void Start()
    {
        myInventoryManager = InventoryManager.Instance;
        myShopManager = ShopManager.Instance;
        myInventoryManager.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        inventoryUI.SetActive(true);
        inventoryUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            OpenCloseInventory();
        }
    }

    public void OpenCloseInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void OpenCloseInventory(bool open)
    {
        inventoryUI.SetActive(open);
        foreach (InventorySlot slot in slots)
        {
            if(slot.item != null)
                slot.sellPriceBox.SetActive(open);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < myInventoryManager.items.Count)
            {
                slots[i].AddItem(myInventoryManager.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
