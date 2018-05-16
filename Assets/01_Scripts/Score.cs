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
	public GameObject star4;
	public GameObject effect;

	private int notaFinal;
	private int acertos;


	public Animator[]    Stars;
	public static string infoValue;

	// Use this for initialization
	void Start () {

		star1.SetActive (false);
		star2.SetActive (false);
		star3.SetActive (false);
		star4.SetActive (false);

		idTema = PlayerPrefs.GetInt ("idTema");
		notaFinal = PlayerPrefs.GetInt ("notaFinalTemp" + idTema.ToString ());
		acertos = PlayerPrefs.GetInt ("acertosTemp" + idTema.ToString ());


		txtInfotema.text = infoValue;



		if (notaFinal >= 20) {

			star4.SetActive (true);

		
		}

		if (notaFinal >= 10){

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
		addEffect ();
		
	}
	void Update () {

	}

	public void addEffect (){

		GameObject.Instantiate (effect);

	}

	public void GoToMenu(){
		SceneManager.LoadScene (0);
	}

	public void restart(){

		SceneManager.LoadScene(idTema);
	}
}
	
	// Update is called once per frame

