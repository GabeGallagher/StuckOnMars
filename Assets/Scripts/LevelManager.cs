﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float autoLoadNextLevelAfter;

    void Start()
    {
    	if (autoLoadNextLevelAfter==0)
        {
    		Debug.Log("Level auto load disabled");
    	}
        else
        {
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
    }

    public void LoadLevel(string name)
    {
		Debug.Log("New level load:" + name);
		SceneManager.LoadScene(name);
    }

	public void Quit()
    {
		Application.Quit();
    }

    public void LoadNextLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}