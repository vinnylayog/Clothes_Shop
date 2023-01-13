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

    public GameObject Player;

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

    IEnumerator DelayLoading()
    {
        yield return new WaitForSeconds(loadDelay);

        Fader.Instance.FadeToBlack(false);
    }
}
