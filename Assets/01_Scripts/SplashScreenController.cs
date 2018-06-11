using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour {
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
			
	}
	public void StartGame(){
		SceneManager.LoadScene ("Menu");
	}

	public void gotoPreMenu(){
		SceneManager.LoadScene("PreMenu");
	}
}
