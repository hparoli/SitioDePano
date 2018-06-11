using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	private int idTema;

	[Header("Celeiro")]
	public Animator[] barnAnims;

//	public Text txtnota;
//	public Text txtInfotema;

	[Header("Array Collections and Aninha")]
	public GameObject[] stars;
	public Animator[] starAnims;
	public Animator aninha;
	public int[] scoresTargets;

	[Space(10)]
	private int notaFinal;
	private int acertos;

	[Header("Debug Values")]
	[SerializeField]
	int debug_score;
	[SerializeField]
	bool useDebug;


	public static string infoValue;

	// Use this for initialization
	void Start () 
	{

		for (int i = 0; i < stars.Length ; i++) 
		{
			stars [i].SetActive (false);
		}

		idTema = PlayerPrefs.GetInt ("idTema");
		notaFinal = PlayerPrefs.GetInt ("notaFinalTemp" + idTema.ToString ());
		acertos = PlayerPrefs.GetInt ("acertosTemp" + idTema.ToString ());
//		txtInfotema.text = infoValue;
		#if UNITY_EDITOR
		if (useDebug)
		notaFinal = debug_score;
		#endif
		BarnAnin ();
		Punctuation ();
	}

	void Update () {

	}


	public void Punctuation (){
		StartCoroutine ("SetPunctuation");
	}

	public IEnumerator SetPunctuation ()
	{
		aninha.SetBool ("Active", true);
		yield return new WaitForSeconds (1);

		for (int i = scoresTargets.Length - 1; i >= 0; i--) 
		{
			if (notaFinal == scoresTargets [i]) 
			{
				if (i >= 3) 
				{
					stars [0].SetActive (true);
					starAnims [0].SetBool ("MasterPoint", true);
					starAnims [1].SetBool ("MasterPoint", true);
					starAnims [2].SetBool ("MasterPoint", true);
					starAnims [3].SetBool ("MasterPoint", true);
				} 
				else 
				{

					stars [0].SetActive (false);
					starAnims [0].SetBool ("NormalPoint", i >= 0);
					starAnims [1].SetBool ("NormalPoint", i >= 1);
					starAnims [2].SetBool ("NormalPoint", i >= 2);
				}

				break;
			}
		}
	}

	public void BarnAnin(){
		for (int i = 0; i < barnAnims.Length; i++) {
			barnAnims [i].SetBool ("Open", true);
		}
	}

	public void GoToMenu(){
		SceneManager.LoadScene ("Menu");
	}

	public void restart(){

		SceneManager.LoadScene(idTema);
	}
}
	
	// Update is called once per frame

