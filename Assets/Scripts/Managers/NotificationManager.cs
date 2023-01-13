using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    #region Singleton
    public static NotificationManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public Animator notifAnim;
    public TMP_Text notifText;

    public void ShowNotification(string newText, Color color)
    {
        notifText.text = newText;
        notifText.color = color;
        notifAnim.Play("FadeOut");
    }
}
