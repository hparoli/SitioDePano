using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSelect : MonoBehaviour {

	private int  idTema;
	public GameObject menuController;

	void Start () {
		idTema = 0;
	}

	public void MiniGameSelected(int i){
		idTema = i;
		PlayerPrefs.SetInt ("idTema", idTema);
	}

	public void StartGame(){
		menuController.GetComponent<MenuController> ().playConfirmation.SetActive (false);
		LoadingScreenManager.LoadScene(idTema);
		PlayerPrefs.SetInt ("NoJogo", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
