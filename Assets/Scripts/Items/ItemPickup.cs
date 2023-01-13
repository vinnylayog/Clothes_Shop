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

        if (item != null) OnSpawn(item);
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        bool wasPickedUp = myInventoryManager.Add(item);

        if (wasPickedUp)
        {
            if (!item.isDefaultItem) myNotificationManager.ShowNotification("You picked up a " + item.name + ".", Color.white);
            Destroy(gameObject);
        }
    }

    public void OnSpawn(Item newItem)
    {
        item = newItem;
        mySpriteRenderer.sprite = item.icon;
        gameObject.name = item.name;
    }
}
