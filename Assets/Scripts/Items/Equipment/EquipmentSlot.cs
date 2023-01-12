using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Equipment equip;

    public void AddEquip(Equipment newEquip)
    {
        equip = newEquip;

        icon.sprite = equip.icon;
        icon.enabled = true;

        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        equip = null;

        icon.sprite = null;
        icon.enabled = false;

        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        EquipmentManager.Instance.Unequip((int)equip.equipIndex);
    }
}
