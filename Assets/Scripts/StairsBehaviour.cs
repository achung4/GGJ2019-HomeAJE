using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairsBehaviour : MonoBehaviour
{

    public GameObject levelManager;

    private void Awake()
    {
        if (LevelManager.instance == null)
            Instantiate(levelManager);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.name == "StairsDown")
        {
            --LevelManager.instance.currentLevel;
            SceneManager.LoadScene("Level" + LevelManager.instance.currentLevel);
            if (LevelManager.instance.currentLevel == 1)
            { 
                GameObject.Find("Player").transform.position = new Vector3((float)7.35, (float)-1.25, 0 );
            }
        }
        else if (gameObject.name == "StairsUp")
        {
            ++LevelManager.instance.currentLevel;
            SceneManager.LoadScene("Level" + LevelManager.instance.currentLevel);
        }
    }
}
