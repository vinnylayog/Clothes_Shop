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

    public Transform equipmentParent;

    Inventory myInventory;

    private void Start()
    {
        myInventory = Inventory.Instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentIndex)).Length;
        currentEquipment = new Equipment[numSlots];
        equipmentSlots = equipmentParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipIndex;

        Equipment oldItem = null;
        equipmentSlots[slotIndex].ClearSlot();

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            myInventory.Add(oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        equipmentSlots[slotIndex].AddEquip(newItem);
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            Inventory.Instance.Add(oldItem);

            currentEquipment[slotIndex] = null;
            equipmentSlots[slotIndex].ClearSlot();
        }
    }
}
