using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    int currentTrackNum = 0;
    public AudioSource BGM;
    public AudioSource SFX;

    public List<AudioClip> BGMList = new List<AudioClip>();

    private void Start()
    {
        PlayStartBGM();
    }

    public void PlayStartBGM()
    {
        StartCoroutine(playBGM());
    }

    public void PlayBGM(AudioClip newBGM)
    {
        BGM.PlayOneShot(newBGM);
    }

    public void PlaySFX(AudioClip newSfx)
    {
        SFX.PlayOneShot(newSfx);
    }

    void NextTrack()
    {
        currentTrackNum++;
        if (currentTrackNum >= BGMList.Count) currentTrackNum = 0;
        StartCoroutine(playBGM());
    }

    IEnumerator playBGM()
    {
        AudioClip playTrack = BGMList[currentTrackNum];
        PlayBGM(playTrack);
        yield return new WaitForSeconds(playTrack.length);
        NextTrack();
    }
}
