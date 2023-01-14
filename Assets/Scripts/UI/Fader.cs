using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    #region Singleton
    public static Fader Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    Animator myAnimator;

    public float loadDelay;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();

        StartCoroutine(DelayLoading());
    }

    //Fades to or from black depending on bool
    public void FadeToBlack(bool fade)
    {
        if(fade)
            myAnimator.Play("FadeToBlack");
        else
            myAnimator.Play("FadeFromBlack");
    }

    //Delay display of game scene to give a bit of time for loading assets, menus, etc
    IEnumerator DelayLoading()
    {
        yield return new WaitForSeconds(loadDelay);

        Fader.Instance.FadeToBlack(false);
    }
}
