using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentLevel;
    void Start()
    {
        currentLevel = 1;
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
        if( gameObject.name == "StairsDown" )
        {
            --currentLevel;
            SceneManager.LoadScene("Level" + currentLevel);
        } else if ( gameObject.name == "StairsUp" )
        {
            ++currentLevel;
            SceneManager.LoadScene("Level" + currentLevel);
        }
    }
}
