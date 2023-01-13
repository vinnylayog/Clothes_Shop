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

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.position, ShopNPC.position) > 3.0f)
        {
            ShopManager.Instance.OpenCloseShop();
        }
    }
}
