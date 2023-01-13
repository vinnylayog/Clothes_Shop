using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    EquipmentSlot[] equipmentSlots;
    EquipmentSprite[] equippedSprite;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public Transform equipmentParent;
    public Transform equipmentDisplayParent;

    InventoryManager myInventoryManager;

    private int direction;

    private void Start()
    {
        myInventoryManager = InventoryManager.Instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentIndex)).Length;
        currentEquipment = new Equipment[numSlots];
        equipmentSlots = equipmentParent.GetComponentsInChildren<EquipmentSlot>();
        equippedSprite = equipmentDisplayParent.GetComponentsInChildren<EquipmentSprite>();
    }

    //Equips newItem
    public void Equip(Equipment newItem)
    {
        //Check which item slot new equip will take
        int slotIndex = (int)newItem.equipIndex;

        Equipment oldItem = null;

        //Clears the slot that the new item will take
        equipmentSlots[slotIndex].ClearSlot();

        //If there is another item in the slot, removes that item
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            myInventoryManager.Add(oldItem);
        }

        //!!! Implement if have extra time !!!
        //If item is replaced, invokes onEquipmentChanged
        //For changing stats associated with the equipment
        //Can be implemented after Player Stats, etc.
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        //Assigns the newItem to the equipment slot, updates the sprite
        currentEquipment[slotIndex] = newItem;
        equipmentSlots[slotIndex].AddEquip(newItem);
        equippedSprite[slotIndex].equipSpriteRenderer.sprite = currentEquipment[slotIndex].sides[direction];
    }

    //Unequips the item at the specified slot
    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            //Adds the unequipped item to the Inventory
            Equipment oldItem = currentEquipment[slotIndex];
            InventoryManager.Instance.Add(oldItem);

            //Clears all equipment data from slot
            currentEquipment[slotIndex] = null;
            equipmentSlots[slotIndex].ClearSlot();

            //!!! Implement if have extra time !!!
            //If item is removed, invokes onEquipmentChanged
            //For changing stats associated with the equipment
            //Can be implemented after Player Stats, etc.
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            //Removes Equipment display
            equippedSprite[slotIndex].equipSpriteRenderer.sprite = null;
        }
    }

    //Update the direction that the equipped item's sprite is facing
    public void UpdateFacing(int facing)
    {
        direction = facing;
        for (int i = 0; i < 5; i++)
        {
            if (currentEquipment[i] != null)
            {
                if (currentEquipment[i].sides.Length > 1)
                {
                    equippedSprite[i].equipSpriteRenderer.sprite = currentEquipment[i].sides[direction];
                }
            }
        }
    }
}
