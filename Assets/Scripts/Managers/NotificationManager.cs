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

    //Other scripts can call this function to show a generic notification
    //Plays an animation of text displaying and fading out after 0.35 seconds
    public void ShowNotification(string newText, Color color)
    {
        notifText.text = newText;
        notifText.color = color;
        notifAnim.Play("FadeOut");
    }
}
