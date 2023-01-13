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

    public float loadDelay;

    //Give other scripts easy access to Player object
    public GameObject Player;

    //For organization of Hierarchy in Editor
    //Allows other scripts to attach objects to the appropriate parent transform
    public GameObject ManagersParent;
    public GameObject ActorsParent;
    public GameObject EnvironmentParent;

    // Start is called before the first frame update
    void Start()
    {
        if (Player == null) 
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        StartCoroutine(DelayLoading());
    }

    //Delay display of game scene to give a bit of time for loading assets, menus, etc
    IEnumerator DelayLoading()
    {
        yield return new WaitForSeconds(loadDelay);

        Fader.Instance.FadeToBlack(false);
    }
}
