using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	private int idTema;

	public Text txtnota;
	public Text txtInfotema;

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;

	private int notaFinal;
	private int acertos;

	// Use this for initialization
	void Start () {
		
		star1.SetActive (false);
		star2.SetActive (false);
		star3.SetActive (false);

		idTema = PlayerPrefs.GetInt ("idTema");
		notaFinal = PlayerPrefs.GetInt ("notaFinalTemp" + idTema.ToString ());
		acertos = PlayerPrefs.GetInt ("acertosTemp" + idTema.ToString ());

		txtnota.text = notaFinal.ToString ();
		txtInfotema.text = "Você acertou " + acertos.ToString () + " de 20 perguntas";

		if (notaFinal == 10){

			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (true);
	
		}

		else if (notaFinal >= 7){

			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (false);
		}

		else if (notaFinal >= 5){

			star1.SetActive (true);
			star2.SetActive (false);
			star3.SetActive (false);
		}
		
	}

	public void restart(){

		SceneManager.LoadScene(idTema);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
