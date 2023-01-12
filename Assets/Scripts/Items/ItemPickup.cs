using UnityEngine;

public class ItemPickup : Interactable
{
    private SpriteRenderer mySpriteRenderer;
    public Item item;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.Instance.Add(item);

        if (wasPickedUp)
            Destroy(gameObject);
    }

    public void OnSpawn(Item newItem)
    {
        item = newItem;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = item.icon;
    }
}
