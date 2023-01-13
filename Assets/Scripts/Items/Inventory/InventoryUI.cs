using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject inventoryButton;
    public Transform itemsParent;

    Inventory myInventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        myInventory = Inventory.Instance;
        myInventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        inventoryUI.SetActive(true);
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
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
        //inventoryButton.SetActive(!inventoryButton.activeSelf);
    }

    public void OpenCloseInventory(bool open)
    {
        inventoryUI.SetActive(open);
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < myInventory.items.Count)
            {
                slots[i].AddItem(myInventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
