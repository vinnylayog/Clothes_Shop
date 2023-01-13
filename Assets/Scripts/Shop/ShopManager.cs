using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    #region Singleton
    public static ShopManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject ShopPanel;

    // Start is called before the first frame update
    void Start()
    {
        ShopPanel.SetActive(true);
        ShopPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCloseShop()
    {
        ShopPanel.SetActive(!ShopPanel.activeSelf);
        Inventory.Instance.myInventoryUI.OpenCloseInventory(ShopPanel.activeSelf);
    }
}
