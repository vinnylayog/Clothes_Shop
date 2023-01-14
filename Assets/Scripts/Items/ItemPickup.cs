using UnityEngine;

public class ItemPickup : Interactable
{
    public SpriteRenderer mySpriteRenderer;
    public Item item;

    InventoryManager myInventoryManager;
    NotificationManager myNotificationManager;

    private void Start()
    {
        myInventoryManager = InventoryManager.Instance;
        myNotificationManager = NotificationManager.Instance;

        //If Item already has an Assigned Item, load data
        if (item != null) OnSpawn(item);
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    //Add Item to inventory and destroy item in the overworld
    void PickUp()
    {
        bool wasPickedUp = myInventoryManager.Add(item);

        if (wasPickedUp)
        {
            if (!item.isDefaultItem) myNotificationManager.ShowNotification("You picked up a " + item.name + ".", Color.white, 2);
            Destroy(gameObject);
        }
    }

    //On Item's creation in the overworld, assign sprite and name data
    public void OnSpawn(Item newItem)
    {
        item = newItem;
        mySpriteRenderer.sprite = item.icon;
        gameObject.name = item.name;
    }
}
