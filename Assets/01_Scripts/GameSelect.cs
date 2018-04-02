using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSelect : MonoBehaviour {

	public Button btnPlay;
	public Text infoTema;
	public string [] miniGame;

	private int  idTema;

	void Start () {

		idTema = 0;
		infoTema.text = miniGame [idTema];
		btnPlay.interactable = false;

	}

	public void MiniGameSelected(int i){
		
		idTema = i;
		PlayerPrefs.SetInt ("idTema", idTema);
		infoTema.text = miniGame [idTema];
		btnPlay.interactable = true;

	}

	public void StartGame(){
		SceneManager.LoadScene(idTema);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
