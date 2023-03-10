using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject inventoryButton;
    public Transform itemsParent;

    InventoryManager myInventoryManager;
    ShopManager myShopManager;
    AudioManager myAudioManager;

    InventorySlot[] slots;

    public AudioClip pageSound;

    void Start()
    {
        myInventoryManager = InventoryManager.Instance;
        myShopManager = ShopManager.Instance;
        myAudioManager = AudioManager.Instance;

        //Listens to changes made to List of Inventory Items
        myInventoryManager.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        //inventoryUI.SetActive(false);
    }

    void Update()
    {
        //Opens Inventory when Player presses Space or I
        if (Input.GetButtonDown("Inventory"))
        {
            OpenCloseInventory();
        }
    }

    //Opens Inventory if it's closed.
    //Closes Inventory if it's open.
    public void OpenCloseInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        myAudioManager.PlaySFX(pageSound);
    }

    //Opens and Closes Inventory simultaneously with Shop Menu
    public void OpenCloseInventory(bool open)
    {
        inventoryUI.SetActive(open);
        myAudioManager.PlaySFX(pageSound);

        //If Shop Menu is open, Items in Inventory display their Sell Price
        foreach (InventorySlot slot in slots)
        {
            if(slot.item != null)
                slot.sellPriceBox.SetActive(open);
        }
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
        myAudioManager.PlaySFX(pageSound);
    }

    //Updates the Inventory Display if an item is added or removed from Inventory
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
