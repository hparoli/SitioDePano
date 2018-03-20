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
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Mouse is down");

			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.tag == "Doll") 
				{
					acertos = 10;
				}

			}

			ToScore ();
		}
	}

	void ToScore(){



		SceneManager.LoadScene ("Score");
	}
}
