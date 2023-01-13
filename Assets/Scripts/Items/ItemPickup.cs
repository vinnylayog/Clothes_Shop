using UnityEngine;

public class ItemPickup : Interactable
{
    private SpriteRenderer mySpriteRenderer;
    public Item item;

    InventoryManager myInventoryManager;
    NotificationManager myNotificationManager;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myInventoryManager = InventoryManager.Instance;
        myNotificationManager = NotificationManager.Instance;
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        myNotificationManager.ShowNotification("You picked up a " + item.name + ".", Color.green);
        bool wasPickedUp = myInventoryManager.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }

    public void OnSpawn(Item newItem)
    {
        item = newItem;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = item.icon;
        gameObject.name = item.name;
    }
}
