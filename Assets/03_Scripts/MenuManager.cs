﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {



	void Start () 
	{
		
	}
	
	void Update () {
		
	}

	public void SceneControl (string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
