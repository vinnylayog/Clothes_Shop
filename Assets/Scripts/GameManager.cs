using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject Player;

    public GameObject ManagersParent;
    public GameObject ActorsParent;
    public GameObject EnvironmentParent;

    Inventory myInventory;

    // Start is called before the first frame update
    void Start()
    {
        myInventory = Inventory.Instance;

        if (Player == null) 
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            myInventory.myInventoryUI.OpenCloseInventory();
        }
    }
}
