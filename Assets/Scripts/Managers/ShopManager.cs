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

    InventoryManager myInventoryManager;

    public GameObject ShopPanel;

    // Start is called before the first frame update
    void Start()
    {
        myInventoryManager = InventoryManager.Instance;
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
        myInventoryManager.myInventoryUI.OpenCloseInventory(ShopPanel.activeSelf);
    }
}
