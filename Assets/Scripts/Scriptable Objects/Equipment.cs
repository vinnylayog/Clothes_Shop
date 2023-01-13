using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentIndex equipIndex;

    public int moveSpeedModifier;

    public Sprite[] sides;

    //Equips item and removes it from Player's inventory
    public override void Use()
    {
        base.Use();

        EquipmentManager.Instance.Equip(this);
        RemoveFromInventory();
    }
}


public enum EquipmentIndex { Head, Chest, Legs, Hands, Feet }