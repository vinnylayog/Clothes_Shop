using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        Instance = this;
    }

    #endregion

    NotificationManager myNotificationManager;

    public InventoryUI myInventoryUI;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int inventorySpace = 16;

    public List<Item> items = new List<Item>();

    public GameObject DefaultItem;

    private void Start()
    {
        myNotificationManager = NotificationManager.Instance;
    }

    //Add Item to Inventory List
    public bool Add(Item item)
    {
        //Check if Item is Default Item (Generic item with no data)
        if (!item.isDefaultItem)
        {
            //Check if the Inventory is full
            if (items.Count >= inventorySpace)
            {
                myNotificationManager.ShowNotification("Not enough space in your inventory!", Color.red, 1);
                return false;
            }

            //Adds Item to Inventory List
            items.Add(item);

            //Invoke Item Changed Callback to update Inventory UI
            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    //Remove Item from Inventory List
    public void Remove(Item item, bool drop)
    {
        //Check if Item will be dropped on the floor / overworld
        if (drop)
        {
            Transform playerTransform = GameManager.Instance.Player.transform;

            //Spawn a Default Item object
            ItemPickup removeItem = Instantiate(DefaultItem, playerTransform.position, Quaternion.identity).GetComponent<ItemPickup>();
            //Set parent of newly spawned item as Actors Parent (for cleanliness in Hierarchy)
            removeItem.transform.SetParent(GameManager.Instance.ActorsParent.transform);
            //Initialize Default Item with data of Item
            removeItem.OnSpawn(item);
        }

        //Removes Item from Inventory List
        items.Remove(item);

        //Invoke Item Changed Callback to update Inventory UI
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
