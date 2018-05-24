using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	}
	public void yesExit(){
		Application.LoadLevel (0);
	}
	public void noExit(){
		ExitGameObject.SetActive (false);
	}
}
