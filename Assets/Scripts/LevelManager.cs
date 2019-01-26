using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    //static LevelManager _instance;
    private int currentLevel = 1;
    //private static bool started = false;
    void Awake()
    { 
        DontDestroyOnLoad( this.gameObject );
    }
    public void LoadLevel( string name )
    {
        SceneManager.LoadScene( name );
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("currentLevel : " + currentLevel);
        //GameObject.FindGameObjectWithTag
        if ( gameObject.name == "StairsDown" )
        {
            --currentLevel;
            Debug.Log("currentLevel : " + currentLevel);
            SceneManager.LoadScene("Level" + currentLevel);
        } else if ( gameObject.name == "StairsUp" )
        {
            ++currentLevel;
            Debug.Log("currentLevel : " + currentLevel);
            SceneManager.LoadScene("Level" + currentLevel);
        }
    }
}
