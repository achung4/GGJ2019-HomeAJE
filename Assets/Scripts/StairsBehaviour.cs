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
        Debug.Log("currentLevel : " + LevelManager.instance.currentLevel);
        //GameObject.FindGameObjectWithTag
        if (gameObject.name == "StairsDown")
        {
            --LevelManager.instance.currentLevel;
            Debug.Log("currentLevel : " + LevelManager.instance.currentLevel);
            SceneManager.LoadScene("Level" + LevelManager.instance.currentLevel);
        }
        else if (gameObject.name == "StairsUp")
        {
            ++LevelManager.instance.currentLevel;
            Debug.Log("currentLevel : " + LevelManager.instance.currentLevel);
            SceneManager.LoadScene("Level" + LevelManager.instance.currentLevel);
        }
    }
}
