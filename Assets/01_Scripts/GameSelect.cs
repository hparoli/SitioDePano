﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSelect : MonoBehaviour {

	private int  idTema;

	void Start () {
		idTema = 0;
	}

	public void MiniGameSelected(int i){
		idTema = i;
		PlayerPrefs.SetInt ("idTema", idTema);
	}

	public void StartGame(){
		PlayerPrefs.SetInt ("MainMenu", 1);
		LoadingScreenManager.LoadScene(idTema);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
