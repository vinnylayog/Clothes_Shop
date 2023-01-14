using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public Vector2 OverworldDimensions;

    public int goldValue = 10;

    public Vector3 overworldPositionOffset;
    public Vector3 overworldScaleOffset;

    public virtual void Use()
    {
        // Use the item

        //Debug.Log("Using " + name);
    }

    //Removes the item from the Player's Inventory
    public void RemoveFromInventory()
    {
        InventoryManager.Instance.Remove(this, false);
    }
}
