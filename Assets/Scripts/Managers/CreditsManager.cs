using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    public GameObject creditsPanel;

    public void OpenCloseCredits()
    {
        creditsPanel.SetActive(!creditsPanel.gameObject.activeSelf);
    }
}
