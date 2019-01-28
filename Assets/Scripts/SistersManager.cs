using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistersManager : MonoBehaviour
{
    //public static SistersManager instance = null;

    public static int sistersFound = 0;

    private void Start()
    {
        //sistersFound = 0;
    }

    public void ResetGame()
    {
        sistersFound = 0;
    }
    //void Awake()
    //{
    //    if (instance == null)
    //        instance = this;

    //    else if (instance != this)
    //        Destroy(gameObject);

    //    DontDestroyOnLoad(gameObject);
    //}


}
