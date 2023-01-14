using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    private Transform Player;

    [SerializeField]
    private Transform ShopNPC;

    void Start()
    {
        Player = GameManager.Instance.Player.transform;
    }

    void Update()
    {
        //If Player is too far from NPC, the Shop Panel closes
        if (Vector2.Distance(Player.position, ShopNPC.position) > 3.0f)
        {
            ShopManager.Instance.OpenCloseShop();
            ShopManager.Instance.confirmPanel.Close();
        }

        //If Player presses the Inventory button (Tab or I), the shop is also closed
        if (Input.GetButtonDown("Inventory"))
        {
            ShopManager.Instance.OpenCloseShop();
        }
    }
}
