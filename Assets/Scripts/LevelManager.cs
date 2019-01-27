using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    public int currentLevel;
    //private static bool started = false;
    private void Start()
    {
        currentLevel = 1;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
            
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel( string name )
    {
        SceneManager.LoadScene( name );
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

}
