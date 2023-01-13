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

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipIndex;

        Equipment oldItem = null;
        equipmentSlots[slotIndex].ClearSlot();

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            myInventoryManager.Add(oldItem);
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        equipmentSlots[slotIndex].AddEquip(newItem);
        equippedSprite[slotIndex].equipSpriteRenderer.sprite = currentEquipment[slotIndex].sides[direction];
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            InventoryManager.Instance.Add(oldItem);

            currentEquipment[slotIndex] = null;
            equipmentSlots[slotIndex].ClearSlot();

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            equippedSprite[slotIndex].equipSpriteRenderer.sprite = null;
        }
    }

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
