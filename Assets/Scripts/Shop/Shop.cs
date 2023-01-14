using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
    //Opens Shop Panel when ShopNPC is interacted with
    public override void Interact()
    {
        base.Interact();

        if(!ShopManager.Instance.ShopPanel.activeSelf)
            ShopManager.Instance.OpenCloseShop();
    }
}
