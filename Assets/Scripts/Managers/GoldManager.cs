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

    [SerializeField]
    private int playerGold;

    public void AddGold(int addGold)
    {
        playerGold += addGold;
        UpdateGoldDisplay();
    }

    public bool SubGold(int subGold)
    {
        if((playerGold - subGold) < 0)
        {
            Debug.Log("Not enough Gold.");
            return false;
        }

        playerGold -= subGold;
        UpdateGoldDisplay();

        return true;
    }

    private void UpdateGoldDisplay()
    {
        goldDisplay.text = playerGold.ToString();
    }

}
