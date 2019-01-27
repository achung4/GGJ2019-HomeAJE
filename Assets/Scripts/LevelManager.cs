using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    public static int currentLevel;
	public static Vector2 characterInitPosition = new Vector2(3f,2.66f);

	static string levelPreName = "story_level";
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

	public static void LoadLevel(bool isGoingUp) {
		
		int index = currentLevel;
		if (isGoingUp)
			index++;
		else
			index--;

		index = Mathf.Clamp(index, 0, 2);

		CalPlayerInitLocation(isGoingUp);

		string targetLevelName = levelPreName + index;
		SceneManager.LoadScene(targetLevelName);
	}

	static void CalPlayerInitLocation(bool isGoingUp) {
		switch (currentLevel) {
			case 0:
				characterInitPosition = new Vector2(10.57f, 3.55f);
				return;

			case 1:
				if (isGoingUp) {
					characterInitPosition = new Vector2(10.57f, 3.55f);
				}
				else {
					characterInitPosition = new Vector2(8.57f, 3.55f);
				}
				return;

			case 2:
				characterInitPosition = new Vector2(10.57f, 3.55f);
				return;

			default:
				return;
		}
	}

	public void QuitRequest()
    {
        Application.Quit();
    }

}
