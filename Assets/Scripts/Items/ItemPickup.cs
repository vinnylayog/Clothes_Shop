using UnityEngine;

public class ItemPickup : Interactable
{
    private SpriteRenderer mySpriteRenderer;
    public Item item;

    InventoryManager myInventoryManager;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myInventoryManager = InventoryManager.Instance;
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
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
