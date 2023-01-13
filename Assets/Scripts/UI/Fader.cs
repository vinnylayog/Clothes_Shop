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

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    //Fades to or from black depending on bool
    public void FadeToBlack(bool fade)
    {
        if(fade)
            myAnimator.Play("FadeToBlack");
        else
            myAnimator.Play("FadeFromBlack");
    }
}
