using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairsBehaviour : MonoBehaviour
{

    public GameObject levelManager;

    private void Awake()
    {
        if (LevelManager1.instance == null)
            Instantiate(levelManager);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        savePlayerPosition();
        if (gameObject.name == "StairsDown")
        {
            --LevelManager1.instance.currentLevel;

            SceneManager.LoadScene("Level" + LevelManager1.instance.currentLevel);
        }
        else if (gameObject.name == "StairsUp")
        {
            ++LevelManager1.instance.currentLevel;
            SceneManager.LoadScene("Level" + LevelManager1.instance.currentLevel);
        }
    }

    private void savePlayerPosition()
    {
        GameObject player = GameObject.Find("Player");
        PlayerPrefs.SetFloat("p_x", player.transform.position.x);
        PlayerPrefs.Save();
    }
}
