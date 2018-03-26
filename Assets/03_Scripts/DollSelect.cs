using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DollSelect : MonoBehaviour {

	private int idTema;

	private float acertos;
	private float notaFinal;
	private float media;


	void Start(){
		idTema = PlayerPrefs.GetInt ("idTema");
	}

	void Update()
	{
		DollSelected ();
	}


	void DollSelected(){

		if (Input.GetMouseButtonDown (0)) {

			Debug.Log ("Mouse");

			RaycastHit Doll = new RaycastHit();
			bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out Doll);
			if (hit) {

				if (Doll.transform.gameObject.tag == "Doll") {
					ToScore ();
				}

			}

		}

	}

	void ToScore(){

		SceneManager.LoadScene ("Score");
	}
}

