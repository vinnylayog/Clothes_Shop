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

    public List<AudioClip> notificationSounds = new List<AudioClip>();
    AudioManager myAudioManager;

    private void Start()
    {
        myAudioManager = AudioManager.Instance;    
    }

    //Other scripts can call this function to show a generic notification
    //Plays an animation of text displaying and fading out after 0.35 seconds
    //Plays sound effect
    //0 - pickup coin
    //1 - buzz, for negative
    //2 - nice effect, for acquiring something
    public void ShowNotification(string newText, Color color, int sfxID)
    {
        myAudioManager.PlaySFX(notificationSounds[sfxID]);
        notifText.text = newText;
        notifText.color = color;
        notifAnim.Play("FadeOut");
    }
}
