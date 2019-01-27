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
        savePlayerPosition();
        if (gameObject.name == "StairsDown")
        {
            --LevelManager.instance.currentLevel;

            SceneManager.LoadScene("Level" + LevelManager.instance.currentLevel);
        }
        else if (gameObject.name == "StairsUp")
        {
            ++LevelManager.instance.currentLevel;
            SceneManager.LoadScene("Level" + LevelManager.instance.currentLevel);
        }
    }

    private void savePlayerPosition()
    {
        GameObject player = GameObject.Find("Player");

        PlayerPrefs.SetFloat("p_x", player.transform.position.x);
        PlayerPrefs.Save();
    }
}
