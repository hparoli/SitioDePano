using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitConfirmation : MonoBehaviour {


	[SerializeField]
	GameObject ExitGameObject;

	void Start () {
		ExitGameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void openExit(){
		ExitGameObject.SetActive(true);
		ColetaOvos.work = false;
		Time.timeScale = 0;
	}
	public void yesExit(){
		ExitGameObject.SetActive (false);
		Time.timeScale = 1;
		SceneManager.LoadScene("newMenu");
	}
	public void noExit(){
		ExitGameObject.SetActive (false);
		ColetaOvos.work = true;
        Time.timeScale = 1;
    }
}
