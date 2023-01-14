using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    #region Singleton
    public static GoldManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public TMP_Text goldDisplay;

    public int playerGold = 100;

    private void Start()
    {
        UpdateGoldDisplay();
    }

    //Adds gold to the player's wallet
    public void AddGold(int addGold)
    {
        playerGold += addGold;
        UpdateGoldDisplay();
    }

    //Removes gold from the player's wallet
    public bool SubGold(int subGold)
    {
        if((playerGold - subGold) < 0)
        {
            //Debug.Log("Not enough Gold.");
            return false;
        }

        playerGold -= subGold;
        UpdateGoldDisplay();

        return true;
    }

    //Update the amount of gold displayed
    private void UpdateGoldDisplay()
    {
        goldDisplay.text = playerGold.ToString();
    }

}
