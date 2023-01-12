using UnityEngine;

public class ItemPickup : Interactable
{
    private SpriteRenderer spriteRenderer;
    public Item item;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    public void OnSpawn()
    {
        
    }
}
