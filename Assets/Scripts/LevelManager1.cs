using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager1 : MonoBehaviour
{
    public static LevelManager1 instance = null;
    public int currentLevel;
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

    public void LoadLevel( string name, bool isGoingUp )
    {
        SceneManager.LoadScene( name );
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

}
