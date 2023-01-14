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

    //Give other scripts easy access to Player object
    public GameObject Player;

    //For organization of Hierarchy in Editor
    //Allows other scripts to attach objects to the appropriate parent transform
    public GameObject ManagersParent;
    public GameObject ActorsParent;
    public GameObject EnvironmentParent;

    AudioManager myAudioManager;

    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (Player == null) 
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        myAudioManager = AudioManager.Instance;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenClosePauseMenu();
            ShopManager.Instance.CloseShop();
            InventoryManager.Instance.CloseInventory();
        }
    }

    public void OpenClosePauseMenu()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
    }
}
